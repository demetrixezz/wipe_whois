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
            buttonClose.Click += (s, e) => Close();

            // Рисуем фон формы
            #region
            Color clr1 = Color.FromArgb(47, 49, 54);
            Color clr2 = Color.FromArgb(54, 57, 63);
            Color clr3 = Color.FromArgb(54, 57, 63);
            Color clr4 = Color.FromArgb(54, 57, 63);
            FormPaint(clr1, clr2, clr3, clr4);
            #endregion

            // Устанавливаем контролам формы (в заголовке) свойства перемещения
            new List<Control> { panelHeader, labelHeader }.ForEach(x =>
            {
                x.MouseDown += (s, e) =>
                {
                    x.Capture = false;
                    Capture = false;
                    Message m = Message.Create(Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
                    base.WndProc(ref m);
                };
            });

            SettingsLoad();
        }

        // Загрузка формы
        private void FormMain_Load(object sender, EventArgs e)
        {
            // Инициализация вотчера ED-событий
            this.InitWatcher();
            this.edWatcher.Created += Watcher_Created;
            this.edWatcher.Changed += Watcher_Changed;

            //toolStripStatusLabel.Text = "Папка:";
            //toolStripStatusLabelData.Text = PathToLogs;
        }

        // Инициализация вотчера ED-событий
        private void InitWatcher()
        {
            // указываем вотчеру на папку с логами и подписываемся на его события
            this.edWatcher = new JournalWatcher(PathToLogs);
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

        // Обработчик создания нового лог-файла
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            //toolStripStatusLabel.Text = "Журнал:";
            //toolStripStatusLabelData.Text = e.FullPath;
        }

        // Обработчик изменения лог-файла
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            //toolStripStatusLabel.Text = "Журнал:";
            //toolStripStatusLabelData.Text = e.FullPath;
        }

        // Обработчик закрытия программы
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //выключаем читалку логов и записываем параметры в реестр
            this.edWatcher.StopWatching();
            if(this.WindowState != FormWindowState.Minimized)
                SettingsSave();
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
        private void FormMain_Resize(object sender, EventArgs e)
        {
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

        // Контекстное меню программы в трее - пункт меню "Закрыть"
        private void ToolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Контекстное меню программы в трее - пункт меню "О программе"
        private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {

        }

        // Контекстное меню программы в трее - пункт меню "Просмотреть списки"
        private void ToolStripMenuItemViewLists_Click(object sender, EventArgs e)
        {

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
