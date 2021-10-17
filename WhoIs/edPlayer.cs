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

    /// <summary>
    /// Класс "Данные пилота". Содержит данные о пилоте: 
    /// его имя, список эскадр, время создания имени, 
    /// последний вход в игру и репутация у нашей фракции
    /// </summary>
    public class PilotData : IEquatable<PilotData>
    {
        private List<SquadronData>  list_squadrons;
        private DateTime            time_create;
        private DateTime            time_last;
        public  string              Name;
        public  double              FactionReputation;
        // Конструкторы
        public PilotData()
        {
            this.list_squadrons = new List<SquadronData>();
            this.list_squadrons.Sort();   
            this.Name = "";
            this.FactionReputation = 0.0;
        }
        public PilotData(string name)
        { 
            this.list_squadrons = new List<SquadronData>();
            this.list_squadrons.Sort(); 
            this.Name = name; 
        }
        // Методы установки/получения значений переменных
        /// <summary>
        /// Возвращает список эскадр пилота
        /// </summary>
        /// <returns></returns>
        public  List<SquadronData> SquadronsList()  { return this.list_squadrons;   }

        /// <summary>
        /// Возвращает время создания пилота
        /// </summary>
        /// <returns></returns>
        public  DateTime    TimeCreate()            { return this.time_create;      }

        /// <summary>
        /// Возвращает время последней загрузки игры с именем пилота
        /// </summary>
        /// <returns></returns>
        public  DateTime    TimeLast()              { return this.time_last;        }

        /// <summary>
        /// Устанавливает время создания пилота
        /// </summary>
        /// <param name="time"></param>
        public  void        TimeCreate(string time) { this.time_create = DateTime.Parse(time, null, DateTimeStyles.AdjustToUniversal);  }

        /// <summary>
        /// Устанавливает время последней загрузки игры с именем пилота
        /// </summary>
        /// <param name="time"></param>
        public void        TimeLast(string time)    { this.time_last = DateTime.Parse(time, null, DateTimeStyles.AdjustToUniversal);    }

        /// <summary>
        /// Возвращает имя эскадры по её индексу в списке эскадр пилота
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public  string      Squadron(int index=0) 
        {
            int i = index<0 ? 0 : index>list_squadrons.Count-1 ? list_squadrons.Count-1 : index;
            SquadronData squadron = this.list_squadrons.ElementAt(i);
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
            if(!this.list_squadrons.Contains(squadron))
                this.list_squadrons.Add(squadron);
            
        }

        public bool Equals(PilotData pilot)
        {
            if(this.Name == pilot.Name)
                return true;
            return false;
        }
    }

    /// <summary>
    /// Класс "Лог-файл". Содержит в себе список всех строк одного файла и методы обращения к ним
    /// </summary>
    public class LogFile
    {
        private string path_name;
        private FileContent content = null;
        public LogFile(string path)
        {
            this.path_name = path;
            this.content = new FileContent(this.path_name);
        }
        public FileContent  Content()       { return this.content;                                                  }
        public int          LinesCount()    { return content.LinesCount();                                          }
        public string       Line(int index) { return content.Line(index);                                           }
        public string       FileName()      { return this.path_name.Substring(this.path_name.IndexOf("Journal"));   }
        public List<string> ListContent()   { return this.content.GetListContent();                                 }
    }

    /// <summary>
    /// Класс "Содержимое файла". Содержит в списке List<string> все строки одного лог-файла
    /// </summary>
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
        public List<string> GetListContent(){ return this.lines;    }
        public int          LinesCount()    { return lines.Count;   }
        public string       Line(int index) 
        { 
            return this.lines.ElementAt(index<0 ? 0 : index>this.lines.Count()-1 ? this.lines.Count()-1 : index); 
        }
    }

    /// <summary>
    /// Перечисление "интересных" событий журнала для отслеживания
    /// </summary>
    public enum ENUM_JOURNAL_EVENT
    {
        JOURNAL_EVENT_CREATE_NEW_PILOT,         // Создание нового пилота
        JOURNAL_EVENT_RENAME_PILOT,             // Переименование пилота
        JOURNAL_EVENT_SQUADRON_APPLIED,         // Запрос в эскадру
        JOURNAL_EVENT_SQUADRON_JOINED,          // Присоединение к эскадре
        JOURNAL_EVENT_SQUADRON_LEFT,            // Выход из эскадры
        JOURNAL_EVENT_GAME_MODE_PRIVATE,        // Режим игры "Приватная группа"
        JOURNAL_EVENT_GAME_MODE_SOLO,           // Режим игры "Соло"
        JOURNAL_EVENT_GAME_RESET,               // Сброс игры
        JOURNAL_EVENT_GAME_LOAD,                // Загрузка игры
        JOURNAL_EVENT_DEBUG,                    // СобытиеX (для отладки и поиска событий)
    };

    /// <summary>
    /// Класс события журнала (событие в одной строке файла)
    /// </summary>
    public class JournalEvent
    {
        private ENUM_JOURNAL_EVENT  jevent;
        private DateTime            time;
        private string              subject;
        private string              file_name;
        private string              pilot;
        public JournalEvent() { }
        public JournalEvent(ENUM_JOURNAL_EVENT journal_event, string time_event, string subject)
        {
            this.jevent = journal_event;
            this.time = DateTime.Parse(time_event, null, DateTimeStyles.AdjustToUniversal);
            this.subject = subject;
        }
        
        public void     Pilot(string name)      { this.pilot = name;                    }
        public string   Pilot()                 { return this.pilot;                    }
        public void     FileName(string name)   { this.file_name = name;                }
        public string   FileName()              { return this.file_name;                }
        public string   TimeAsString()          { return this.time.ToString();          }
        public DateTime Time()                  { return this.time;                     }
        public string   Subject()               { return this.subject;                  }
        public string   Description()           { return this.EventDescription(jevent); }
        
        private string EventDescription(ENUM_JOURNAL_EVENT jevent)
        {
            switch(jevent)
            {
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_CREATE_NEW_PILOT  : return $"{this.TimeAsString()} Создание пилота {this.Subject()}";
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_RENAME_PILOT      : return $"{this.TimeAsString()} Переименование в {this.Subject()}";
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_SQUADRON_APPLIED  : return $"{this.TimeAsString()} {this.Pilot()} Запрос в эскадру {this.Subject()}";
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_SQUADRON_JOINED   : return $"{this.TimeAsString()} {this.Pilot()} Присоединение к эскадре {this.Subject()}";
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_SQUADRON_LEFT     : return $"{this.TimeAsString()} {this.Pilot()} Выход из эскадры {this.Subject()}";
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_GAME_MODE_PRIVATE : return $"{this.TimeAsString()} {this.Pilot()} Приватная группа \"{this.Subject()}\"";
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_GAME_MODE_SOLO    : return $"{this.TimeAsString()} {this.Pilot()} Режим Соло";
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_GAME_RESET        : return $"{this.TimeAsString()} Сброс игры {this.Subject()}";
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_GAME_LOAD         : return $"{this.TimeAsString()} Загрузка игры {this.Subject()}";
                case ENUM_JOURNAL_EVENT.JOURNAL_EVENT_DEBUG             : return $"{this.TimeAsString()} СобытиеX {this.Subject()}";
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
        public string               PilotCurrent = "";
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
        /// <param name="time_create"></param>
        /// <returns></returns>
        public PilotData CreateNewPilot(string name, DateTime time_create)
        {
            PilotData pilot = new PilotData(name);
            if(pilot is null)
                return null;
            pilot.TimeCreate(time_create.ToString());
            pilot.TimeLast(time_create.ToString());
            this.AddNewPilot(pilot);
            return pilot;
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
                if(pilot.Name == pilot_name)
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
        /// Возвращает список интересных событий игрока
        /// </summary>
        /// <returns></returns>
        public List<JournalEvent> EventsList() { return this.events_list; }

        /// <summary>
        /// Асинхронный метод. Обрабатывает файлы журналов и собирает интересные события игрока
        /// </summary>
        /// <param name="path_to_logs"></param>
        async public void History(string path_to_logs)
        {
            //MessageBox.Show($"Запускаю чтение истории для {PilotCurrent}");
            await Task.Run(()=> 
            { 
                CollectHistory(path_to_logs);
                HistoryCompleted = true;
            });
        }
        
        /// <summary>
        /// Собирает в списки все файлы журналов игры
        /// </summary>
        /// <param name="path_to_logs"></param>
        protected void CollectHistory(string path_to_logs)
        {
            if(this.CollectLogFilesAll(path_to_logs))
            {
                MessageBox.Show("История прочитана");
                SearchPlayerEvents();
                return;
            }
            this.HistoryCompleted = false;
        }
        
        /// <summary>
        /// Ищет интересные события игрока и собирает их в список событий
        /// </summary>
        protected void SearchPlayerEvents()
        {
            int count=0;
            foreach(LogFile logfile in this.log_files_list)
            {
                string CurrentPilot = "";
                string CurrentSquadron = "";
                List<string> lines = logfile.ListContent();
                foreach(string line in lines)
                {
                    // Создание нового пилота
                    if(line.Contains("NewCommander"))
                    {
                        DateTime time_event = this.EventTime(line);
                        string name = this.Name(line);
                        PilotData pilot = this.PilotByName(name);
                        if(pilot == null)
                            pilot = this.CreateNewPilot(name, time_event);
                        if(pilot != null)
                        {
                            CurrentPilot = pilot.Name;
                            JournalEvent evn = new JournalEvent(ENUM_JOURNAL_EVENT.JOURNAL_EVENT_CREATE_NEW_PILOT, time_event.ToString(), CurrentPilot);
                            evn.Pilot(CurrentPilot);
                            evn.FileName(logfile.FileName());
                            this.events_list.Add(evn);
                        }
                    }
                    // Загрузка игры
                    if(line.Contains("LoadGame"))
                    {
                        DateTime time_event = this.EventTime(line);
                        string name = this.Commander(line);
                        PilotData pilot = this.PilotByName(name);
                        // Переименование пилота
                        if(pilot == null)
                        {
                            pilot = this.CreateNewPilot(name, time_event);
                            if(pilot != null)
                            {
                                CurrentPilot = pilot.Name;
                                if(time_event > pilot.TimeLast())
                                    pilot.TimeLast(time_event.ToString());
                                JournalEvent evn = new JournalEvent(ENUM_JOURNAL_EVENT.JOURNAL_EVENT_RENAME_PILOT,time_event.ToString(),CurrentPilot);
                                if(evn != null)
                                {
                                    evn.Pilot(CurrentPilot);
                                    evn.FileName(logfile.FileName());
                                    this.events_list.Add(evn);
                                }
                            }
                        }
                        if(pilot != null)
                        {
                            CurrentPilot = pilot.Name;
                            if(time_event > pilot.TimeLast())
                                pilot.TimeLast(time_event.ToString());
                            // Режим игры не "Open"
                            string game_mode = this.GameMode(line);
                            if(game_mode != "Open")
                            {
                                ENUM_JOURNAL_EVENT mode = game_mode == "Solo" ? ENUM_JOURNAL_EVENT.JOURNAL_EVENT_GAME_MODE_SOLO : ENUM_JOURNAL_EVENT.JOURNAL_EVENT_GAME_MODE_PRIVATE;
                                DateTime time_ban = game_mode == "Group" ? DateTime.Parse("2021-03-24T00:00:00") : DateTime.Parse("2021-09-19T00:00:00");
                                string group_name = game_mode == "Group" ? this.Group(line) : "";
                                if(time_event > time_ban)
                                {
                                    JournalEvent evn = new JournalEvent(mode,time_event.ToString(),group_name);
                                    if(evn != null)
                                    {
                                        evn.Pilot(CurrentPilot);
                                        evn.FileName(logfile.FileName());
                                        this.events_list.Add(evn);
                                    }
                                }
                            }
                        }
                    }
                    // Запрос в эскадру
                    if(line.Contains("AppliedToSquadron"))
                    {
                        DateTime time_event = this.EventTime(line);
                        PilotData pilot = this.PilotByName(CurrentPilot);
                        if(pilot != null)
                        {
                            if(time_event > pilot.TimeLast())
                                pilot.TimeLast(time_event.ToString());
                            JournalEvent evn = new JournalEvent(ENUM_JOURNAL_EVENT.JOURNAL_EVENT_SQUADRON_APPLIED,time_event.ToString(),this.SquadronName(line));
                            if(evn != null)
                            {
                                evn.Pilot(CurrentPilot);
                                evn.FileName(logfile.FileName());
                                this.events_list.Add(evn);
                            }
                        }
                    }
                    // Присоединение к эскадре
                    if(line.Contains("JoinedSquadron"))
                    {
                        CurrentSquadron = this.SquadronName(line);
                        DateTime time_event = this.EventTime(line);
                        PilotData pilot = this.PilotByName(CurrentPilot);
                        if(pilot != null)
                        {
                            pilot.AddNewSquadron(CurrentSquadron, time_event.ToString());
                            if(time_event > pilot.TimeLast())
                                pilot.TimeLast(time_event.ToString());
                            JournalEvent evn = new JournalEvent(ENUM_JOURNAL_EVENT.JOURNAL_EVENT_SQUADRON_JOINED,time_event.ToString(),CurrentSquadron);
                            if(evn != null)
                            {
                                evn.Pilot(CurrentPilot);
                                evn.FileName(logfile.FileName());
                                this.events_list.Add(evn);
                            }
                        }
                    }

                    // Уход из эскадры
                    if(line.Contains("LeftSquadron"))
                    {
                        CurrentSquadron = "";
                        DateTime time_event = this.EventTime(line);
                        PilotData pilot = this.PilotByName(CurrentPilot);
                        if(pilot != null)
                        {
                            if(time_event > pilot.TimeLast())
                                pilot.TimeLast(time_event.ToString());
                            JournalEvent evn = new JournalEvent(ENUM_JOURNAL_EVENT.JOURNAL_EVENT_SQUADRON_LEFT,time_event.ToString(),this.SquadronName(line));
                            if(evn != null)
                            {
                                evn.Pilot(CurrentPilot);
                                evn.FileName(logfile.FileName());
                                this.events_list.Add(evn);
                            }
                        }
                    }

                    // Репутация у Wild Priest Corps
                    if(line.Contains("SquadronFaction\":true"))
                    {
                        DateTime time_event = this.EventTime(line);
                        PilotData pilot = this.PilotByName(CurrentPilot);
                        if(pilot != null)
                        {
                            if(time_event > pilot.TimeLast())
                                pilot.TimeLast(time_event.ToString());
                            pilot.FactionReputation = Convert.ToDouble(MyReputation(line),CultureInfo.InvariantCulture);
                            //JournalEvent evn = new JournalEvent(ENUM_JOURNAL_EVENT.JOURNAL_EVENT_XXX,time_event.ToString(),pilot.FactionReputation.ToString());
                            //if(evn != null)
                            //{
                            //    evn.Pilot(CurrentPilot);
                            //    evn.FileName(logfile.FileName());
                            //    this.events_list.Add(evn);
                            //}
                        }
                    }

                    //// Что-то иное с вхождением "Squadron", но не скан корабля и не вход в игру в составе эскадры и не закладки эскадры
                    //if(line.Contains("Squadron") & 
                    //   !line.Contains("SquadronID") & 
                    //   !line.Contains("SquadronStartup") &
                    //   !line.Contains("SharedBookmarkToSquadron")
                    //   )
                    //{
                    //    DateTime time_event = this.EventTime(line);
                    //    PilotData pilot = this.PilotByName(CurrentPilot);
                    //    if(pilot != null)
                    //    {
                    //        string subject = line.Substring(line.IndexOf("Squadron"));
                    //        JournalEvent evn = new JournalEvent(ENUM_JOURNAL_EVENT.JOURNAL_EVENT_XXX,time_event.ToString(),subject);
                    //        if(time_event > pilot.TimeLast())
                    //            pilot.TimeLast(time_event.ToString());
                    //        if(evn != null)
                    //        {
                    //            evn.Pilot(CurrentPilot);
                    //            evn.FileName(logfile.FileName());
                    //            this.events_list.Add(evn);
                    //        }
                    //    }
                    //}
                }
            }

            MessageBox.Show("Собрано "+log_files_list.Count+" файлов");
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
                {
                    this.log_files_list.Add(new LogFile(file));
                }
            }
            return this.log_files_list.Count>0;
        }
        
        /// <summary>
        /// Возвращает список всех лог-файлов игрока
        /// </summary>
        /// <returns></returns>
        public List<LogFile> GetListLogFiles() { return this.log_files_list; }

        /// <summary>
        /// Возвращает из строки репутацию у фракции эскадры
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string MyReputation(string line)
        {
            int xxx = line.IndexOf("SquadronFaction\":true");
            int beg = line.IndexOf("MyReputation",xxx)+14;
            int pnt = line.IndexOf(".",beg);
            int end = pnt+7;
            return line.Substring(beg, end - beg);
        }

        /// <summary>
        /// Возвращает из строки режим игры
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string GameMode(string line)
        {
            int beg = line.IndexOf("GameMode")+11;
            int end = line.IndexOf(",", beg);
            return line.Substring(beg, end - beg - 1);
        }

        /// <summary>
        /// Возвращает из строки наименование группы
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string Group(string line)
        {
            int beg = line.IndexOf("GameMode")+28;
            int end = line.IndexOf("\"", beg);
            return line.Substring(beg, end - beg);
        }

        /// <summary>
        /// Возвращает из строки имя пилота/наименование чего/кого либо
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string Name(string line)
        {
            int beg = line.IndexOf("Name")+7;
            int end = line.IndexOf(",", beg);
            return line.Substring(beg, end - beg - 1);
        }

        /// <summary>
        /// Возвращает из строки имя пилота
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string Commander(string line)
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
            int end = line.IndexOf("\"", beg);
            return line.Substring(beg, end - beg - 1);
        }
    }
}
