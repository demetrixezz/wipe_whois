using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoIs
{
    public class SquadronData : IEquatable<SquadronData>
    {
        private string      name;
        private DateTime    time_entry;
        private DateTime    time_leave;
        // Конструкторы
        public              SquadronData() 
        { 
            this.name = "";
            this.time_entry = new DateTime(1, 1, 1, 0, 0, 0);
            this.time_leave = new DateTime(1, 1, 1, 0, 0, 0);
        }
        public              SquadronData(string name)
        {
            this.Name(name);
            this.time_entry = new DateTime(1, 1, 1, 0, 0, 0);
            this.time_leave = new DateTime(1, 1, 1, 0, 0, 0);
        }
        public              SquadronData(string name, string time)
        {
            this.Name(name);
            this.time_entry = DateTime.Parse(time, null, DateTimeStyles.RoundtripKind);
            this.time_leave = new DateTime(1, 1, 1, 0, 0, 0);
        }
        public void         TimeEntry(string time)
        { 
            this.time_entry = DateTime.Parse(time, null, DateTimeStyles.AdjustToUniversal);
        }
        public void         TimeLeave(string time)
        { 
            this.time_leave = DateTime.Parse(time, null, DateTimeStyles.AdjustToUniversal);
        }
        public DateTime     TimeEntry()             { return this.time_entry;   }
        public DateTime     TimeLeave()             { return this.time_leave;   }
        public void         Name(string name)       { this.name = name;         }
        public string       Name()                  { return this.name;         }

        public bool Equals(SquadronData squadron)
        {
            if(this.TimeEntry() == squadron.TimeEntry() && this.Name() == squadron.Name())
                return true;
            return false;
        }
    }

    public class PilotData : IEquatable<PilotData>
    {
        private List<SquadronData> squadrons_list;
        private string      name;
        private DateTime    time_create;
        private DateTime    time_last;
        // Конструкторы
        public              PilotData()
        {
            this.squadrons_list = new List<SquadronData>();
            this.squadrons_list.Sort();   
            this.name = ""; 
        }
        public              PilotData(string name)
        { 
            this.squadrons_list = new List<SquadronData>();
            this.squadrons_list.Sort(); 
            this.Name(name); 
        }
        // Методы установки/получения значений переменных
        public  List<SquadronData> SquadronsList()                  { return this.squadrons_list;   }
        public  string      Name()                                  { return this.name;             }
        public  void        Name(string name)                       { this.name = name;             }
        public  DateTime    TimeCreate()                            { return this.time_create;      }
        public  DateTime    TimeLast()                              { return this.time_last;        }
        public  void        TimeCreate(string time)
        { 
            this.time_create = DateTime.Parse(time, null, DateTimeStyles.AdjustToUniversal);
        }
        public  void        TimeLast(string time)
        { 
            this.time_last = DateTime.Parse(time, null, DateTimeStyles.AdjustToUniversal);
        }
        public  string      Squadron(int index=0) 
        {
            int i = index<0 ? 0 : index>squadrons_list.Count-1 ? squadrons_list.Count-1 : index;
            SquadronData squadron = this.squadrons_list.ElementAt(i);
            return squadron != null ? squadron.Name() : "";
        }
        
        /// <summary>
        /// Добавляет в список новую эскадру (имя эскадры, дата и время вступления)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="time"></param>
        public  void        AddNewSquadron(string name, string time)
        {
            SquadronData squadron = new SquadronData(name, time);
            if(squadron is null)
                return;
            if(!this.squadrons_list.Contains(squadron))
                this.squadrons_list.Add(squadron);
            
        }

        public bool Equals(PilotData pilot)
        {
            if(this.Name() == pilot.Name())
                return true;
            return false;
        }
    }

    public class LogFile
    {
        private string path_name;
        private FileContent content = null;
        public LogFile(string path)
        {
            this.path_name = path;
            this.content = new FileContent(this.path_name);
        }
        public FileContent  ListAllLines()  { return this.content;          }
        public int          LinesCount()    { return content.LinesCount();  }
        public string       Line(int index) { return content.Line(index);   }
        public string       FileName() 
        { 
            return this.path_name.Substring(this.path_name.IndexOf("Journal")); 
        }
    }

    public class FileContent
    {
        List<string>    lines = new List<string>();
        private string  path_name;
        public FileContent(string file) 
        { 
            this.path_name = file;
            this.ContentFilling();
        }
        private int ContentFilling()
        {
            string[] lines = File.ReadAllLines(this.path_name);
            foreach(string line in lines) { this.lines.Add(line); }
            return this.lines.Count;
        }
        public List<string> GetAllContent() { return this.lines;    }
        public int          LinesCount()    { return lines.Count;   }
        public string       Line(int index) 
        { 
            return this.lines.ElementAt(index<0 ? 0 : index>this.lines.Count()-1 ? this.lines.Count()-1 : index); 
        }
    }

    public enum ENUM_JOURNAL_EVENT
    {
        JOURNAL_EVENT_CREATE_NEW_PILOT,         // Создание нового пилота
        JOURNAL_EVENT_SQUADRON_ENTRY,           // Присоединение к эскадре
        JOURNAL_EVENT_SQUADRON_LEAVE,           // Выход из эскадры
        JOURNAL_EVENT_GAME_MODE_PRIVATE,        // Режим игры "Приватная группа"
        JOURNAL_EVENT_GAME_MODE_SOLO,           // Режим игры "Соло"
        JOURNAL_EVENT_GAME_ENTRY_WRONG_NAME,    // Вход в игру под другим именем
    };

    public class JournalEvent
    {
        private ENUM_JOURNAL_EVENT  jevent;
        private DateTime            time;
        private string              subject;
        public JournalEvent() { }
        public JournalEvent(ENUM_JOURNAL_EVENT journal_event, string time_event, string subject)
        {
            this.jevent = journal_event;
            this.time = DateTime.Parse(time_event, null, DateTimeStyles.AdjustToUniversal);
            this.subject = subject;
        }
        
        public string   TimeAsString()  { return this.time.ToString();  }
        public DateTime Time()          { return this.time;             }
        public string   Subject()       { return this.subject;          }
        
        public string EventDescription(ENUM_JOURNAL_EVENT jevent)
        {
            switch(jevent)
            {
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_CREATE_NEW_PILOT      : return $"{this.TimeAsString()} Создание нового пилота: \"{this.Subject()}\"";
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_SQUADRON_ENTRY        : return $"{this.TimeAsString()} Присоединение к эскадре: \"{this.Subject()}\"";
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_SQUADRON_LEAVE        : return $"{this.TimeAsString()} Выход из эскадры: \"{this.Subject()}\"";
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_GAME_MODE_PRIVATE     : return $"{this.TimeAsString()} Режим игры \"Приватная группа\"";
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_GAME_MODE_SOLO        : return $"{this.TimeAsString()} Режим игры \"Соло\"";
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_GAME_ENTRY_WRONG_NAME : return $"{this.TimeAsString()} Вход в игру под другим именем: \"{this.Subject()}\"";
                default:
                break;
            }
            return "Unknown";
        }
    }

    /// <summary>
    /// Класс "Игрок" описывает игрока - имена его пилотов, присутствие в эскадрах
    /// </summary>
    public class edPlayer
    {
        private List<PilotData>     pilots_list = new List<PilotData>(10);
        private List<LogFile>       log_files_list = new List<LogFile>();
        private List<JournalEvent>  events_list = new List<JournalEvent>();
        public bool                 HistoryCompleted;
        // Конструкторы
        public edPlayer() 
        { 
            this.pilots_list.Sort(); 
            this.log_files_list.Sort(); 
        }
        //public edPlayer(string name) 
        //{ 
        //    this.pilots_list.Sort(); 
        //    this.log_files_list.Sort(); 
        //    this.CreateNewPilot(name); 
        //}

        /// <summary>
        /// Создаёт новый объект "Пилот"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CreateNewPilot(string name)
        {
            PilotData pilot = new PilotData(name);
            if(pilot is null)
                return false;
            this.AddNewPilot(pilot);
            return true;
        }

        /// <summary>
        /// Возвращает по индексу эскадру указанного по индексу пилота
        /// </summary>
        /// <param name="pilot_index"></param>
        /// <param name="squadron_index"></param>
        /// <returns></returns>
        public string PilotSquadron(int pilot_index, int squadron_index)
        {
            PilotData pilot=this.pilots_list.ElementAt(pilot_index);
            if(pilot is null)
                return "";
            return pilot.Squadron(squadron_index);
            return "";
        }

        /// <summary>
        /// Возвращает список эскадр пилота по его имени
        /// </summary>
        /// <param name="pilot_name"></param>
        /// <returns></returns>
        public List<SquadronData> SquadronList(string pilot_name)
        {
            PilotData pilot=this.PilotByName(pilot_name);
            if(pilot == null)
                return null;
            return pilot.SquadronsList();
        }

        /// <summary>
        /// Добавляет к списку пилотов игрока новое имя пилота
        /// </summary>
        /// <param name="pilot"></param>
        protected void AddNewPilot(PilotData pilot)
        {
            if(!this.pilots_list.Contains(pilot))
                this.pilots_list.Add(pilot);
        }
        /// <summary>
        /// Возвращает объект "Пилот" по индексу из списка пилотов игрока
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PilotData Pilot(int index=0) 
        {
            if(this.pilots_list.Count == 0)
                return null;
            return this.pilots_list.ElementAt(index < 0 ? 0 : index > pilots_list.Count-1 ? pilots_list.Count-1 : index); 
        }

        /// <summary>
        /// Возвращает объект "Пилот" по имени пилота
        /// </summary>
        /// <param name="pilot_name"></param>
        /// <returns></returns>
        public PilotData PilotByName(string pilot_name)
        {
            foreach(PilotData pilot in this.pilots_list)
            {
                if(pilot.Name() == pilot_name)
                    return pilot;
            }
            return null;
        }

        /// <summary>
        /// Возвращает количество пилотов игрока
        /// </summary>
        /// <returns></returns>
        public int PilotsCount() { return this.pilots_list.Count; }

        /// <summary>
        /// Обрабатывает файлы журналов и собирает интересные события игрока
        /// </summary>
        /// <param name="path_to_logs"></param>
        async public void History(string path_to_logs)
        {
            MessageBox.Show("Запускаю чтение истории");
            await Task.Run(()=> 
            { 
                CollectHistory(path_to_logs);
                HistoryCompleted = true;
            });
        }
        
        protected void CollectHistory(string path_to_logs)
        {
            if(this.CollectLogFilesAll(path_to_logs))
            {
                MessageBox.Show("История прочитана");
                return;
            }
            this.HistoryCompleted = false;
        }
        
        /// <summary>
        /// Создаёт список всех лог-файлов игры за всё время (Альфа не учитывается)
        /// </summary>
        /// <param name="path_to_logs"></param>
        /// <returns></returns>
        private bool CollectLogFilesAll(string path_to_logs)
        {
            //список всех файлов с расширением log
            string[] array = Directory.GetFiles(path_to_logs, "*.log");
            foreach(string file in array)
            {
                if(!file.Contains("Alpha"))
                    this.log_files_list.Add(new LogFile(file));
            }
            return this.log_files_list.Count>0;
        }
        
        /// <summary>
        /// Возвращает список всех лог-файлов игрока
        /// </summary>
        /// <returns></returns>
        public List<LogFile> GetListLogFiles() { return this.log_files_list; }

        /// <summary>
        /// Возвращает из строки имя пилота
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string PilotName(string line)
        {
            int beg = line.IndexOf("Commander")+12;
            int end = line.IndexOf(",", beg);
            return line.Substring(beg, end - beg - 1);
        }
        /// <summary>
        /// Возвращает из строки время события
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private DateTime EventTime(string line)
        {
            int beg = line.IndexOf("timestamp")+12;
            int end = line.IndexOf("Z",beg);
            string time = line.Substring(beg, end - beg);
            return DateTime.Parse(time,null,DateTimeStyles.AdjustToUniversal);
        }
        /// <summary>
        /// Возвращает из строки имя эскадры
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string SquadronName(string line)
        {
            int beg = line.IndexOf("SquadronName")+15;
            int end = line.IndexOf(",", beg);
            return line.Substring(beg, end - beg - 1);
        }
    }
}
