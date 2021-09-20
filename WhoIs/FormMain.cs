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

namespace WhoIs
{
    public partial class FormMain : Form
    {
        // PathToLogs - путь к папке логов программы
        string path;
        string PathToLogs => path ?? (path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Saved Games\Frontier Developments\Elite Dangerous\");

        // Создаём экземпляр вотчера событий
        JournalWatcher edWatcher = new JournalWatcher("");

        public FormMain()
        {
            InitializeComponent();
            SettingsLoad();
        }

        // Загрузка формы
        private void FormMain_Load(object sender, EventArgs e)
        {
            // Инициализация вотчера файлов
            FileSystemWatcher watcher = new FileSystemWatcher(PathToLogs, "*.log")
            {
                EnableRaisingEvents = true,
                SynchronizingObject = this
            };
            watcher.Created += Watcher_Created;
            //watcher.Changed += Watcher_Changed;
            
            // Инициализация вотчера ED-событий
            this.InitWatcher();
            label1.Text = $"PathToLogs: {PathToLogs}\nLatestJournalFile: {this.edWatcher.LatestJournalFile}\nwatcher.Path: {watcher.Path}";

            toolStripStatusLabel.Text = "Папка:";
            toolStripStatusLabelData.Text = PathToLogs;
        }

        // Инициализация вотчера ED-событий
        private void InitWatcher()
        {
            // указываем вотчеру на папку с логами и подписываемся на его события
            this.edWatcher = new JournalWatcher(PathToLogs);
            this.edWatcher.GetEvent<ShipTargetedEvent>()?.AddHandler((s, e) => {
                if (e.ScanStage == 1)
				{
					if (!string.IsNullOrWhiteSpace(e.PilotName))
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
        private void CheckPilot(string pilotName)
        { }

        // Обработчик создания нового лог-файла
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            label1.Text += $"Создан файл {e.FullPath}\n Прошлый файл: {PathToLogs}\n LatestJournalFile: {this.edWatcher.LatestJournalFile}";
            toolStripStatusLabel.Text = "Журнал:";
            toolStripStatusLabelData.Text = e.FullPath;
            // Добавить указание вотчеру событий имени нового файла
        }

        // Обработчик закрытия программы
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //выключаем читалку логов и записываем параметры в реестр
            this.edWatcher.StopWatching();
            SettingsSave();
        }

        // Запись параметров программы в реестр
        void SettingsSave()
        {
            using (RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
            {
                // Путь к папке логов и последние координаты окна программы
                RegKey.SetValue("LogFolderPath", PathToLogs, RegistryValueKind.String);
                if(this.WindowState != FormWindowState.Minimized)
                {
                RegKey.SetValue("FormLocationX", Location.X, RegistryValueKind.DWord);
                RegKey.SetValue("FormLocationY", Location.Y, RegistryValueKind.DWord);
                }
            }
        }

        // Загрузка параметров предыдущего запуска программы
        void SettingsLoad()
        {
            using (RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
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
