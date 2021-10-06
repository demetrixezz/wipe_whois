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

namespace WhoIs
{
    public partial class FormMain : FormBase
    {
        // PathToLogs - путь к папке логов программы
        string path;
        string PathToLogs => path ?? (path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Saved Games\Frontier Developments\Elite Dangerous\");

        // Создаём экземпляр вотчера событий
        JournalWatcher edWatcher = null;

        public FormMain()
        {
            InitializeComponent();
            // Проверка уже запущенного экземпляра программы и выход
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
            #endregion
            // Обработка событий мышки для всех текстовых меток панели главной формы (panelFormMain)
            foreach(Label lbl in panelFormMain.Controls.OfType<Label>())
            {
                lbl.MouseLeave += (s, a) => { lbl.ForeColor = Color.FromArgb(171, 171, 171); };
                lbl.MouseEnter += (s, a) => { lbl.ForeColor = Color.FromArgb(201, 201, 201); };
                lbl.MouseDown += (s, a) => { lbl.ForeColor = Color.FromArgb(221, 221, 221); };
                lbl.MouseUp += (s, a) => { lbl.ForeColor = Color.FromArgb(171, 171, 171); };
            }
            // Цвет контекстного меню и определение нового рендера
            #region
            contextMenuStrip.BackColor = Color.FromArgb(54, 57, 63);
            contextMenuStrip.ForeColor = Color.FromArgb(171, 171, 171);
            contextMenuStrip.Renderer = new CMSRenderer();
            #endregion
            #endregion

            // Панель авторизации - координаты за пределами формы
            panelMenuAutorize.Location = new Point(panelMenuLeft.Location.X - panelMenuAutorize.Width, panelMenuLeft.Location.Y + 37);

            // Устанавливаем реакции на мышку контролам панели авторизации
            #region
            new List<Control> { panelLogin, labelLogin, textBoxLogin }.ForEach(x =>
            {
                x.MouseEnter += (s, e) => { labelLoginDescription.Text = "Логин должен совпадать с игровым"; };
            });
            new List<Control> { panelPass, labelPass, textBoxPass }.ForEach(x =>
            {
                x.MouseEnter += (s, e) => { labelLoginDescription.Text = "Пароль для входа в программу"; };
            });
            new List<Control> { buttonLogin }.ForEach(x =>
            {
                x.MouseEnter += (s, e) => { labelLoginDescription.Text = "Данные будут проверены на сервере"; };
            });

            new List<Control> { panelLogin, labelLogin, textBoxLogin, panelPass, labelPass, textBoxPass, buttonLogin }.ForEach(x =>
            {
                x.MouseLeave += (s, e) => { labelLoginDescription.Text = ""; };
            });
            #endregion

            // Загружаем настройки программы из реестра
            SettingsLoad();
        }
        
        // Загрузка формы
        private void FormMain_Load(object sender, EventArgs e)
        {
            // Инициализация вотчера ED-событий
            this.InitWatcher();

            // Авторизируемся
            Authorization();
            
            textBoxLogin.Text = RegistryData.Login();
            textBoxPass.Text = RegistryData.Password();
        }

        // Инициализация вотчера ED-событий
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

        // Метод обработки пилотов-игроков
        private void CheckPilot(string pilotName) { }

        // Обработчик изменения лог-файла - факт произошедшего абстрактного события
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {

        }

        // Обработчик закрытия программы
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //выключаем читалку логов и записываем параметры в реестр
            this.edWatcher.StopWatching();
            if(this.WindowState != FormWindowState.Minimized)
                SettingsSave();
            InstanceChecker.ReleaseMemory();
        }

        // Запись параметров программы в реестр
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

        // Загрузка параметров предыдущего запуска программы
        void SettingsLoad()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
            {
                int x = Convert.ToInt32(RegKey.GetValue("FormLocationX", 100));
                int y = Convert.ToInt32(RegKey.GetValue("FormLocationY", 100));
                this.Location = new Point(x, y);
            }
        }
        
        // Сворачивание в трей
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

        // Двойной клик по значку в трее (разворачиваем из трея)
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            NotifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        // Контекстное меню программы в трее - пункт меню "Просмотреть списки"
        private void ToolStripMenuItemViewLists_Click(object sender, EventArgs e)
        {

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
            public static void Normal(Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(171, 171, 171);
                lbl.MouseLeave += (s, a) => { lbl.ForeColor = Color.FromArgb(171, 171, 171); };
                lbl.MouseEnter += (s, a) => { lbl.ForeColor = Color.FromArgb(201, 201, 201); };
                lbl.MouseDown += (s, a) => { lbl.ForeColor = Color.FromArgb(221, 221, 221); };
                lbl.MouseUp += (s, a) => { lbl.ForeColor = Color.FromArgb(171, 171, 171); };
            }
            public static void Warning(Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(230, 36, 55);
                lbl.MouseLeave += (s, a) => { lbl.ForeColor = Color.FromArgb(230, 36, 55); };
                lbl.MouseEnter += (s, a) => { lbl.ForeColor = Color.FromArgb(240, 46, 65); };
                lbl.MouseDown += (s, a) => { lbl.ForeColor = Color.FromArgb(250, 56, 75); };
                lbl.MouseUp += (s, a) => { lbl.ForeColor = Color.FromArgb(230, 36, 55); };
            }
        }
    
        // Клик по кнопке "Войти в программу"
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            RegistryData.SaveRegistrationData(textBoxLogin.Text, textBoxPass.Text);
            Authorization();
        }

        // Авторизация в программе
        private void Authorization()
        {
            // Загружаем рагистрационные данные из реестра и вписываем их в поля ввода
            RegistryData.LoadRegistrationData();
            textBoxLogin.Text = RegistryData.Login();
            textBoxPass.Text = RegistryData.Password();
            SetButtonLoginState();
            // Если нет логина или пароля в реестре -
            if(RegistryData.Login()=="" || RegistryData.Password() == "" || RegistryData.Login() == null || RegistryData.Password() == null)
            {
                // Выводим панель заполнения формы регистрации
                if(panelMenuAutorize.Location.X < panelMenuLeft.Location.X)
                    ShowPanel(panelMenuAutorize, panelMenuLeft);
                ControlView.Warning(labelStatus);
                labelStatus.Text = "Требуется авторизация!";
            }
            else
            {
                if(panelMenuAutorize.Location.X >= panelMenuLeft.Location.X)
                    HidePanel(panelMenuAutorize, panelMenuLeft);
                ControlView.Normal(labelStatus);
                labelStatus.Text = $"Авторизовано для \"{RegistryData.Login()}\", пароль: {RegistryData.Password()}";
            }
        }

        // Показывает панель
        private async void ShowPanel(Panel panel, Panel parent)
        {
            while(panel.Location.X < parent.Location.X)
            {
                await Task.Delay(1);
                int x = Math.Abs(panel.Location.X) / 4;
                if(x == 0)
                    x = 1;
                panel.Location = new Point(panel.Location.X + x, panel.Location.Y);
                labelStatus.Text = panel.Location.X.ToString();
            }
            if(panel.Location.X != parent.Location.X)
                panel.Location = new Point(parent.Location.X, panel.Location.Y);
        }
        // Скрывает панель
        private async void HidePanel(Panel panel, Panel parent)
        {
            int x = 0;
            while(panel.Location.X >= parent.Location.X - panel.Width)
            {
                await Task.Delay(1);
                x = (panel.Width - Math.Abs(panel.Location.X)) / 4;
                if(x == 0)
                    x = 1;
                panel.Location = new Point(panel.Location.X - x, panel.Location.Y);
                labelStatus.Text = panel.Location.X.ToString();
            }
            if(panel.Location.X != parent.Location.X - panel.Width)
                panel.Location = new Point(parent.Location.X - panel.Width, panel.Location.Y);
            MessageBox.Show("OK");
        }

        // Состояние кнопки входа в зависимостиот состояния полей ввода логина и пароля
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


        // Для упаковки звуков
        private void button1_Click(object sender, EventArgs e)
        {
            //string name = "Intro";
            //string path=$@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\OneDrive\Рабочий стол\Для Whois\{name}";
            //label1.Text = path + name;
            //using(FileStream fileIn = File.OpenRead($@"{path}.wav"))
            //using(FileStream fileOut = File.Create($@"{path}.gz"))
            //using(GZipStream gz = new GZipStream(fileOut, CompressionLevel.Optimal))
            //    fileIn.CopyTo(gz);

            using(MemoryStream fileOut = new MemoryStream(Properties.Resources.About_Alena))
            using(GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
                new SoundPlayer(gz).Play(); 
        }

    }
}
