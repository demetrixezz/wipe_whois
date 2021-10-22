using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
//========================================================= добавляем юзинги 
using EliteJournalReader;
using EliteJournalReader.Events;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using CSCore;
using CSCore.SoundIn;
using CSCore.CoreAudioAPI;
using CSCore.Streams;
using CSCore.Streams.Effects;
using CSCore.SoundOut;
using CSCore.Codecs.WAV;

namespace WhoIs
{
    public partial class FormMain : FormBase
    {
        // PathToLogs - путь к папке логов программы
        string path;
        string PathToLogs => path ?? (path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Saved Games\Frontier Developments\Elite Dangerous\");
        // Флаг успешной авторизации
        bool   Authorized;

        // Объявляем экземпляры вотчера событий, игрока и голосового ассистента
        JournalWatcher          edWatcher = null;
        edPlayer                Player = null;
        VoiceActorsCollection   VoiceActors = null;
        
        public FormMain()
        {
            InitializeComponent();
            // Проверка уже запущенного экземпляра программы и выход если это второй
            if(!InstanceChecker.TakeMemory())
            {
                // интересно, как развернуть окно, если программа в трее?
                Process[] processes = Process.GetProcessesByName("WhoIs");
                if(processes.Length > 0)
                {
                    //MessageBox.Show("Length: "+processes.Length.ToString());
                }
                this.Close();
            }

            // Построение внешнего вида формы
            #region
            // Устанавливаем контролам формы (в заголовке) свойства перемещения
            new List<Control> { panelHeader, panelLogoWIPE, labelHeader }.ForEach(x =>
            {
                x.MouseDown += (s, e) =>
                {
                    x.Capture = false;
                    Capture = false;
                    Message m = Message.Create(Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
                    base.WndProc(ref m);
                };
            });
            // Рисуем фон формы
            #region
            Color clr1 = Color.FromArgb(32, 34, 37);
            Color clr2 = Color.FromArgb(54, 57, 63);
            Color clr3 = Color.FromArgb(54, 57, 63);
            Color clr4 = Color.FromArgb(54, 57, 63);
            FormPaint(clr1, clr2, clr3, clr4);
            #endregion
           // Обработка нажатий кнопок в заголовке формы
            #region
            buttonClose.Click += (s, e) => Close();
            buttonClose.MouseEnter += (s, e) => buttonClose.BackgroundImage = Properties.Resources.CrossCloseOver;
            buttonClose.MouseDown += (s, e) => buttonClose.BackgroundImage = Properties.Resources.CrossCloseDown;
            buttonClose.MouseLeave += (s, e) => buttonClose.BackgroundImage = Properties.Resources.CrossClose;

            buttonToTray.Click += (s, e) => { };
            buttonToTray.MouseEnter += (s, e) => buttonToTray.BackgroundImage = Properties.Resources.ToTrayOver;
            buttonToTray.MouseDown += (s, e) => buttonToTray.BackgroundImage = Properties.Resources.ToTrayDown;
            buttonToTray.MouseLeave += (s, e) => buttonToTray.BackgroundImage = Properties.Resources.ToTray;
            // Обработка событий мышки для всех текстовых меток панели главной формы (panelFormMain)
            foreach(Label lbl in panelFormMain.Controls.OfType<Label>())
            {
                lbl.MouseLeave += (s, a) => { lbl.ForeColor = Color.FromArgb(171, 171, 171); };
                lbl.MouseEnter += (s, a) => { lbl.ForeColor = Color.FromArgb(201, 201, 201); };
                lbl.MouseDown += (s, a) => { lbl.ForeColor = Color.FromArgb(221, 221, 221); };
                lbl.MouseUp += (s, a) => { lbl.ForeColor = Color.FromArgb(171, 171, 171); };
            }
            #endregion

            // Цвет контекстного меню и определение нового рендера
            #region
            contextMenuStrip.BackColor = Color.FromArgb(54, 57, 63);
            contextMenuStrip.ForeColor = Color.FromArgb(171, 171, 171);
            contextMenuStrip.Renderer = new CMSRenderer();
            #endregion
            #endregion

            // Панели авторизации, информации и настроек - координаты за пределами формы
            #region
            panelMenuAutorize.Location = new Point(panelMenuLeft.Location.X - panelMenuAutorize.Width, panelMenuLeft.Location.Y + 37);
            panelMenuAutorize.Hide();
            panelMenuInfoDB.Location = new Point(panelMenuLeft.Location.X - panelMenuInfoDB.Width, panelMenuLeft.Location.Y + 37);
            panelMenuInfoDB.Hide();
            panelMenuLeftPanelButtonSettings.Location = new Point(-panelMenuLeftPanelButtonSettings.Width, panelMenuLeftPanelButtonSettings.Location.Y);
            panelMenuLeftPanelButtonSettings.Hide();
            #endregion

            // Устанавливаем реакции на мышку контролам панелей авторизации и информации
            #region
            new List<Control> { panelLogin, labelLogin, textBoxLogin }.ForEach(x =>
            {
                x.MouseEnter += (s, e) => { labelLoginDescription.Text = "Логин должен совпадать с игровым"; };
            });
            new List<Control> { panelPass, labelPass, textBoxPass }.ForEach(x =>
            {
                x.MouseEnter += (s, e) => { labelLoginDescription.Text = "Пароль для входа в программу"; };
            });
            new List<Control> { buttonLogin, buttonInfoAdmin, buttonCheckRegistryData }.ForEach(x =>
            {
                x.MouseEnter += (s, e) => { labelLoginDescription.Text = "Данные будут проверены на сервере"; };
            });
            new List<Control> { panelLogin, labelLogin, textBoxLogin, panelPass, labelPass, textBoxPass, buttonLogin }.ForEach(x =>
            {
                x.MouseLeave += (s, e) => { labelLoginDescription.Text = ""; };
            });
            #endregion

            // Создаём коллекцию стандартных голосовых ассистентов
            VoiceActors = new VoiceActorsCollection();
            
            // Загружаем настройки программы из реестра
            SettingsLoad();
            // Создаём экземпляр класса игрока
            this.Player = new edPlayer();
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            // Инициализация вотчера ED-событий
            this.InitWatcher();
            // Авторизация в программе и базе данных
            this.Authorized = Authorization();
            this.WaitHistoryDone();
        }

        /// <summary>
        /// Инициализация вотчера ED-событий 
        /// </summary>
        private void InitWatcher()
        {
            // указываем вотчеру на папку с логами и подписываемся на его события
            this.edWatcher = new JournalWatcher(PathToLogs);
            this.edWatcher.Changed += Watcher_Changed;
            this.edWatcher.GetEvent<ShipTargetedEvent>()?.AddHandler((s, e) => {
                if(e.ScanStage == 1)
                {
                    if(!string.IsNullOrWhiteSpace(e.PilotName))
                        this.CheckPilot(e.PilotName);
                }
            });
            this.edWatcher.GetEvent<InterdictedEvent>()?.AddHandler((s, e) => {
                if(e.IsPlayer)
                {
                    if(!string.IsNullOrWhiteSpace(e.Interdictor))
                        this.CheckPilot(e.Interdictor);
                }
            });
            // стартуем вотчер ED-событий
            this.edWatcher.StartWatching();
        }


        /// <summary>
        /// Ожидание сигнала о завершении чтения и сохранения лог-файлов в список
        /// </summary>
        async public void WaitHistoryDone()
        {
            await Task.Run(async ()=>
            {
                while(!Player.HistoryCompleted)
                    await Task.Delay(500);
            });
            Player.HistoryCompleted = true;
            List<JournalEvent> list = Player.EventsList();
            foreach(JournalEvent evn in list)
            {
                //listBox1.Items.Add(evn.Description()/*+" File: "+evn.FileName()*/);
            }
        }

        // Метод обработки пилотов-игроков
        private void CheckPilot(string pilotName) 
        {
            
        }

        // Обработчик изменения лог-файла - факт произошедшего абстрактного события
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {

        }

        /// <summary>
        /// Обработчик закрытия программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //выключаем читалку логов и записываем параметры в реестр
            this.edWatcher.StopWatching();
            if(this.WindowState != FormWindowState.Minimized)
                SettingsSave();
            InstanceChecker.ReleaseMemory();
        }

        /// <summary>
        /// Запись параметров программы в реестр
        /// </summary>
        void SettingsSave()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
            {
                // Путь к папке логов и последние координаты окна программы
                RegKey.SetValue("LogFolderPath", PathToLogs, RegistryValueKind.String);
                RegKey.SetValue("FormLocationX", Location.X, RegistryValueKind.DWord);
                RegKey.SetValue("FormLocationY", Location.Y, RegistryValueKind.DWord);
            }
        }

        /// <summary>
        /// Загрузка параметров предыдущего запуска программы
        /// </summary>
        void SettingsLoad()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
            {
                int x = Convert.ToInt32(RegKey.GetValue("FormLocationX", 100));
                int y = Convert.ToInt32(RegKey.GetValue("FormLocationY", 100));
                this.Location = new Point(x, y);
            }
        }

        /// <summary>
        /// Сворачивание в трей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonToTray_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                NotifyIcon.Visible = true;
                NotifyIcon.ShowBalloonTip(1000);
            }
            else if(this.WindowState == FormWindowState.Normal)
            {
                NotifyIcon.Visible = false;
            }
        }

        /// <summary>
        /// Двойной клик по значку в трее (разворачиваем из трея)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            NotifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        // Контекстное меню программы в трее - пункт меню "Просмотреть списки"
        private void ToolStripMenuItemViewLists_Click(object sender, EventArgs e)
        {
            if(!Application.OpenForms.OfType<FormData>().Any())
                new FormData().Show();
        }

        // Контекстное меню программы в трее - пункт меню "Справка"
        private void ToolStripMenuItemHelp_Click(object sender, EventArgs e)
        {
            
        }

        // Контекстное меню программы в трее - пункт меню "О программе"
        private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {

        }

        // Контекстное меню программы в трее - пункт меню "Закрыть"
        private void ToolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Возвращает последний файл в папке логов игры по фильтру ("*log" == лог-файл)
        public FileInfo GetLatestJournalFile(string searchPattern)
            {
            DirectoryInfo LogDirectory = new DirectoryInfo(PathToLogs);
            return LogDirectory.GetFiles(searchPattern).OrderByDescending(f => f.LastWriteTime).First();
            }

        // Закрашивает форму
        public void FormPaint(Color color1, Color color2, Color color3, Color color4)
        {
            void OnPaintEventHandler(object s, PaintEventArgs e)
            {
                if(ClientRectangle == Rectangle.Empty)
                    return;
                var lgb = new LinearGradientBrush(ClientRectangle, Color.Empty, Color.Empty, 90);
                var cblend = new ColorBlend { Colors = new[] { color1, color1, color2, color3 }, Positions = new[] { 0, 0.07f, 0.075f, 1} };

                lgb.InterpolationColors = cblend;
                e.Graphics.FillRectangle(lgb, ClientRectangle);
            }
            Paint -= OnPaintEventHandler;
            Paint += OnPaintEventHandler;
            Invalidate();
        }

        // Новый рендерер контекстного меню
        class CMSRenderer : ToolStripProfessionalRenderer
        {
            public CMSRenderer() : base(new CMSColors()) { }
        }
        class CMSColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(64, 67, 73);
            public override Color MenuItemBorder => Color.FromArgb(56, 59, 65);
        }

        // Внешний вид и поведение текстовой метки
        public static class ControlView
        {
            public static void Normal(Label lbl, string text="")
            {
                lbl.ForeColor = Color.FromArgb(171, 171, 171);
                lbl.MouseLeave += (s, a) => { lbl.ForeColor = Color.FromArgb(171, 171, 171); };
                lbl.MouseEnter += (s, a) => { lbl.ForeColor = Color.FromArgb(201, 201, 201); };
                lbl.MouseDown += (s, a) => { lbl.ForeColor = Color.FromArgb(221, 221, 221); };
                lbl.MouseUp += (s, a) => { lbl.ForeColor = Color.FromArgb(171, 171, 171); };
                lbl.Text = text != "" ? text : lbl.Text;
            }
            public static void Warning(Label lbl, string text = "")
            {
                lbl.ForeColor = Color.FromArgb(230, 36, 55);
                lbl.MouseLeave += (s, a) => { lbl.ForeColor = Color.FromArgb(230, 36, 55); };
                lbl.MouseEnter += (s, a) => { lbl.ForeColor = Color.FromArgb(240, 46, 65); };
                lbl.MouseDown += (s, a) => { lbl.ForeColor = Color.FromArgb(250, 56, 75); };
                lbl.MouseUp += (s, a) => { lbl.ForeColor = Color.FromArgb(230, 36, 55); };
                lbl.Text = text != "" ? text : lbl.Text;
            }
        }
    
        // Клик по кнопке "Войти в программу"
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            RegistryData.SaveRegistrationData(textBoxLogin.Text, textBoxPass.Text);
            Authorization();
        }

        // Клик по кнопке "Проверить"
        private void ButtonCheckRegistryData_Click(object sender, EventArgs e)
        {
            // Скрываем информационную панель базы данных
            if(panelMenuInfoDB.Location.X >= panelMenuLeft.Location.X)
                HidePanel(panelMenuInfoDB, 8);
            // Показываем панель авторизации
            if(panelMenuAutorize.Location.X < panelMenuLeft.Location.X)
                ShowPanel(panelMenuAutorize, 4);
            ControlView.Warning(labelStatus, "Требуется авторизация!");
        }

        // Клик по кнопке "Сообщить"
        private void ButtonInfoAdmin_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.com/channels/742092065705558046/763418573879246849");
        }

        /// <summary>
        /// Клик по кнопке "Настройки" левого меню формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMenuLeftSettings_Click(object sender, EventArgs e)
        {
            if(panelMenuLeftPanelButtonSettings.Location.X < 0)
                SlidePanel(panelMenuLeftPanelButtonSettings, 4, 0, ENUM_SLIDE_MODE.SLIDE_MODE_RIGHT, ENUM_VISIBLE_CONTROL.VISIBLE_BEFORE);
            else
                SlidePanel(panelMenuLeftPanelButtonSettings, 8, -panelMenuLeftPanelButtonSettings.Width, ENUM_SLIDE_MODE.SLIDE_MODE_LEFT, ENUM_VISIBLE_CONTROL.UNVISIBLE_AFTER);
        }

        // Авторизация в программе
        private bool Authorization()
        {
            // Загружаем рагистрационные данные из реестра и вписываем их в поля ввода
            RegistryData.LoadRegistrationData();
            textBoxLogin.Text = RegistryData.Login();
            textBoxPass.Text = RegistryData.Password();
            // Кнопка входа неактивна пока не введены данные в поля
            SetButtonLoginState();
            // Если нет логина или пароля в реестре -
            if(RegistryData.Login()=="" || RegistryData.Password() == "" || RegistryData.Login() == null || RegistryData.Password() == null)
            {
                // Делаем неактивными кнопки администрирования и просмотра данных ДБ и смещаем панель с кнопками вниз
                buttonMenuLeftAdministrations.Enabled = false;
                buttonMenuLeftViewDatas.Enabled = false;
                SlidePanel(panelMenuLeftPanelButtons, 8, panelMenuAutorize.Location.Y + panelMenuAutorize.Height, ENUM_SLIDE_MODE.SLIDE_MODE_DOWN,ENUM_VISIBLE_CONTROL.VISIBLE_CONTROL_DISABLE);
                // Выводим панель заполнения формы регистрации
                if(panelMenuAutorize.Location.X < panelMenuLeft.Location.X)
                    ShowPanel(panelMenuAutorize, 4);
                ControlView.Warning(labelStatus, "Требуется авторизация!");
                this.Authorized = false;
                if(textBoxLogin.Text == "")
                {
                    textBoxLogin.Focus();
                    textBoxLogin.SelectionStart = textBoxLogin.Text.Length;
                }
                else if(textBoxPass.Text == "")
                {
                    textBoxPass.Focus();
                    textBoxPass.SelectionStart = textBoxPass.Text.Length;
                }
                return false;
            }
            // Если в реестре есть логин и пароль -
            // проверим их по базе данных
            else
            {
                // Если нет связи с базой
                if(!RegistryData.CheckConnectionOnDB())
                {
                    // Делаем неактивными кнопки администрирования и просмотра данных ДБ и смещаем панель с кнопками вниз
                    buttonMenuLeftAdministrations.Enabled = false;
                    buttonMenuLeftViewDatas.Enabled = false;
                    SlidePanel(panelMenuLeftPanelButtons, 8, panelMenuAutorize.Location.Y + panelMenuAutorize.Height, ENUM_SLIDE_MODE.SLIDE_MODE_DOWN,ENUM_VISIBLE_CONTROL.VISIBLE_CONTROL_DISABLE);
                    // Выводим панель заполнения формы регистрации
                    if(panelMenuAutorize.Location.X < panelMenuLeft.Location.X)
                        ShowPanel(panelMenuAutorize, 4);
                    ControlView.Warning(labelStatus, "Нет связи с базой данных");
                    this.Authorized = false;
                    return false;
                }
                // Если логина или пароля нет в базе, или они не совпадают с базой
                if(!RegistryData.CheckLoginInDB() || !RegistryData.CheckPasswordInDB())
                {
                    // Делаем неактивными кнопки администрирования и просмотра данных ДБ и смещаем панель с кнопками вниз
                    buttonMenuLeftAdministrations.Enabled = false;
                    buttonMenuLeftViewDatas.Enabled = false;
                    SlidePanel(panelMenuLeftPanelButtons, 8, panelMenuAutorize.Location.Y + panelMenuAutorize.Height, ENUM_SLIDE_MODE.SLIDE_MODE_DOWN,ENUM_VISIBLE_CONTROL.VISIBLE_CONTROL_DISABLE);
                    // Скрываем панель авторизации
                    if(panelMenuAutorize.Location.X >= panelMenuLeft.Location.X)
                        HidePanel(panelMenuAutorize, 8);
                    // Показываем информационную панель базы данных
                    if(panelMenuInfoDB.Location.X < panelMenuLeft.Location.X)
                        ShowPanel(panelMenuInfoDB, 4);
                    ControlView.Warning(labelStatus);
                    labelStatus.Text = 
                        !RegistryData.CheckLoginInDB() ? $"Пилот {RegistryData.Login()} отсутствует в базе данных" :
                        $"Не правильный пароль для {RegistryData.Login()}";
                    this.Authorized = false;
                    return false;
                }
                // Если логин и пароль совпадают с базой данных -
                // скрываем все панели и продолжаем работу с программой
                else
                {
                    if(panelMenuInfoDB.Location.X >= panelMenuLeft.Location.X)
                        HidePanel(panelMenuInfoDB, 8);
                    if(panelMenuAutorize.Location.X >= panelMenuLeft.Location.X)
                        HidePanel(panelMenuAutorize, 8);
                    ControlView.Normal(labelStatus, $"Авторизовано для \"{RegistryData.Login()}\"");
                    this.Authorized = true;
                    this.Player.PilotCurrent = RegistryData.Login();
                    this.Player.History(PathToLogs);
                    this.Player.IsAdmin = RegistryData.CheckIsAdmin();
                    // Делаем активными кнопки администрирования и просмотра данных ДБ и смещаем панель с кнопками вверх
                    buttonMenuLeftAdministrations.Enabled = Player.IsAdmin ? true : false;
                    buttonMenuLeftViewDatas.Enabled = true;
                    SlidePanel(panelMenuLeftPanelButtons, 8, 0, ENUM_SLIDE_MODE.SLIDE_MODE_UP,ENUM_VISIBLE_CONTROL.VISIBLE_CONTROL_DISABLE);
                    return true;
                }
            }
        }

        /// <summary>
        /// Перечисление направлений смещения панелей
        /// </summary>
        enum ENUM_SLIDE_MODE
        {
            SLIDE_MODE_UP,
            SLIDE_MODE_DOWN,
            SLIDE_MODE_LEFT,
            SLIDE_MODE_RIGHT,
        }

        /// <summary>
        /// Перечисление флагов, указывающих на момент скрытия/отображения панели
        /// </summary>
        enum ENUM_VISIBLE_CONTROL
        {
            VISIBLE_CONTROL_DISABLE,
            VISIBLE_BEFORE,
            VISIBLE_AFTER,
            UNVISIBLE_BEFORE,
            UNVISIBLE_AFTER,
        }

        /// <summary>
        /// Смещает панель в указанное положение в заданном направлении
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="slowdown"></param>
        /// <param name="destination"></param>
        /// <param name="slide_mode"></param>
        private async void SlidePanel(Panel panel, int slowdown, int destination, ENUM_SLIDE_MODE slide_mode, ENUM_VISIBLE_CONTROL visible_control)
        {
            switch(slide_mode)
            {
                case ENUM_SLIDE_MODE.SLIDE_MODE_UP:
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_BEFORE)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_BEFORE)
                    panel.Hide();
                while(panel.Location.Y > destination)
                {
                    await Task.Delay(1);
                    panel.Location = new Point(panel.Location.X, panel.Location.Y -
                        (Math.Abs(panel.Location.Y - destination) / slowdown > 0 ?
                         Math.Abs(panel.Location.Y - destination) / slowdown : 1));
                }
                if(panel.Location.Y != destination)
                    panel.Location = new Point(panel.Location.X, destination);
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_AFTER)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_AFTER)
                    panel.Hide();
                break;
                
                case ENUM_SLIDE_MODE.SLIDE_MODE_DOWN:
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_BEFORE)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_BEFORE)
                    panel.Hide();
                while(panel.Location.Y < destination)
                {
                    await Task.Delay(1);
                    panel.Location = new Point(panel.Location.X, panel.Location.Y +
                        (Math.Abs(destination - panel.Location.Y) / slowdown > 0 ?
                         Math.Abs(destination - panel.Location.Y) / slowdown : 1));
                }
                if(panel.Location.Y != destination)
                    panel.Location = new Point(panel.Location.X, destination);
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_AFTER)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_AFTER)
                    panel.Hide();
                break;

                case ENUM_SLIDE_MODE.SLIDE_MODE_LEFT:
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_BEFORE)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_BEFORE)
                    panel.Hide();
                while(panel.Location.X >= destination)
                {
                    //MessageBox.Show(
                    //    "panel.Location.X = " + panel.Location.X.ToString() +
                    //    "\ndestination = " + destination.ToString() +
                    //    "\nValue = " + (Math.Abs(panel.Location.X - destination) / slowdown).ToString()
                    //    );
                    await Task.Delay(1);
                    panel.Location = new Point(panel.Location.X -
                        ((Math.Abs(panel.Location.X - destination)) / slowdown > 0 ?
                         (Math.Abs(panel.Location.X - destination)) / slowdown : 1), panel.Location.Y);
                }
                if(panel.Location.X != destination)
                    panel.Location = new Point(destination, panel.Location.Y);
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_AFTER)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_AFTER)
                    panel.Hide();
                break;

                case ENUM_SLIDE_MODE.SLIDE_MODE_RIGHT:
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_BEFORE)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_BEFORE)
                    panel.Hide();
                while(panel.Location.X < destination)
                {
                    await Task.Delay(1);
                    panel.Location = new Point(panel.Location.X +
                        (Math.Abs(destination - panel.Location.X) / slowdown > 0 ?
                         Math.Abs(destination - panel.Location.X) / slowdown : 1), panel.Location.Y);
                }
                if(panel.Location.X != destination)
                    panel.Location = new Point(destination, panel.Location.Y);
                if(visible_control == ENUM_VISIBLE_CONTROL.VISIBLE_AFTER)
                    panel.Show();
                if(visible_control == ENUM_VISIBLE_CONTROL.UNVISIBLE_AFTER)
                    panel.Hide();
                break;

                default:
                break;
            }
        }

        // Показывает панель
        private async void ShowPanel(Panel panel, int slowdown)
        {
            if(panel.Location.X < panel.Parent.Location.X)
                panel.Show();
            while(panel.Location.X < panel.Parent.Location.X)
            {
                await Task.Delay(1);
                panel.Location = new Point(panel.Location.X + 
                    (Math.Abs(panel.Location.X) / slowdown > 0 ? 
                     Math.Abs(panel.Location.X) / slowdown : 1), panel.Location.Y);
            }
            if(panel.Location.X != panel.Parent.Location.X)
                panel.Location = new Point(panel.Parent.Location.X, panel.Location.Y);
        }

        // Скрывает панель
        private async void HidePanel(Panel panel, int slowdown)
        {
            while(panel.Location.X >= panel.Parent.Location.X - panel.Width)
            {
                await Task.Delay(1);
                panel.Location = new Point(panel.Location.X -
                    ((panel.Width - Math.Abs(panel.Location.X)) / slowdown > 0 ? 
                     (panel.Width - Math.Abs(panel.Location.X)) / slowdown : 1), panel.Location.Y);
            }
            if(panel.Location.X != panel.Parent.Location.X - panel.Width)
                panel.Location = new Point(panel.Parent.Location.X - panel.Width, panel.Location.Y);
            panel.Hide();
        }

        // Состояние кнопки входа в зависимости от состояния полей ввода логина и пароля
        #region
        private void SetButtonLoginState()
        {
            buttonLogin.Enabled = (textBoxLogin.Text.Length > 2 && textBoxPass.Text.Length > 3 ? true : false);
        }
        private void TextBoxLogin_TextChanged(object sender, EventArgs e)
        {
            SetButtonLoginState();
        }
        private void TextBoxPass_TextChanged(object sender, EventArgs e)
        {
            SetButtonLoginState();
        }
        #endregion

        /// <summary>
        /// Щелчок по кнопке "Данные"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMenuLeftViewDatas_Click(object sender, EventArgs e)
        {
            if(!Application.OpenForms.OfType<FormData>().Any())
                new FormData().Show();
        }

        // Для упаковки звуков
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
