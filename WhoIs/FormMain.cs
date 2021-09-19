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
        string path;
        string PathToLogs => path ?? (path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\Saved Games\Frontier Developments\Elite Dangerous\");
        string FullName = "";

        JournalWatcher edWatcher = new JournalWatcher(""); // инициируем читалку логов
        
        public FormMain()
        {
            InitializeComponent();
            SettingsLoad();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.InitWatcher();

            toolStripStatusLabel.Text = "Папка:";
            toolStripStatusLabelData.Text = this.PathToLogs;
            
            FileSystemWatcher watcher = new FileSystemWatcher(PathToLogs, "*.log")
            {
                EnableRaisingEvents = true,
                SynchronizingObject = this
            };
            watcher.Created += Watcher_Created;
            watcher.Changed += Watcher_Changed;


        }

        private void InitWatcher()
        {
            // указываем вотчеру на папку с логами
            this.edWatcher = new JournalWatcher(PathToLogs);
            // подписываемся на события обрати внимание на лямбда функцию (она же стрелочная функция) очень полезная хрень для сосздания мелких обработчиков
            

            this.edWatcher.GetEvent<ShipTargetedEvent>()?.AddHandler((s, e) => {
                if (e.ScanStage == 1)
				{
					if (!String.IsNullOrWhiteSpace(e.PilotName))
					    this.CheckPilot(e.PilotName);
                    
				}
			});

            //стартуем читалку логов 

            this.edWatcher.StartWatching();
        }

        private void CheckPilot(string pilotName)
        { }


        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //выключаем читалку логов 
            this.edWatcher.StopWatching();
            SettingsSave();

        }

        void SettingsSave()
        {
            using (RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
            {
                RegKey.SetValue("LogFolderPath", PathToLogs, RegistryValueKind.String);
                RegKey.SetValue("FormLocationX", Location.X, RegistryValueKind.DWord);
                RegKey.SetValue("FormLocationY", Location.Y, RegistryValueKind.DWord);
            }
        }

        void SettingsLoad()
        {
            using (RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
            {
                //PathToLogs = Convert.ToString(RegKey.SetValue("LogFolderPath", PathToLogs, RegistryValueKind.String));
                int x = Convert.ToInt32(RegKey.GetValue("FormLocationX", 100));
                int y = Convert.ToInt32(RegKey.GetValue("FormLocationY", 100));
                this.Location = new Point(x, y);
            }
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            FullName = e.FullPath;
            label1.Text += $"Создан файл {FullName}\n";
            toolStripStatusLabel.Text = "Журнал:";
            toolStripStatusLabelData.Text = this.FullName;
        }
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            label1.Text += $"Изменён файл {FullName}\n";
            using (StreamReader stream = new StreamReader(new FileStream(FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                //label1.Text = stream.ReadLine().Last;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string name = "About_Alena";
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
