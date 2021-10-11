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
            this.squadrons_list.Sort();   
            this.name = ""; 
        }
        public              PilotData(string name)
        { 
            this.squadrons_list.Sort(); 
            this.Name(name); 
        }
        // Методы установки/получения значений переменных
        public  string      Name()                                  { return this.name;         }
        public  void        Name(string name)                       { this.name = name;         }
        public  DateTime    TimeCreate()                            { return this.time_create;  }
        public  DateTime    TimeLast()                              { return this.time_last;    }
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

    public class edPlayer
    {
        private List<PilotData> pilots_list = new List<PilotData>(10);
        private List<LogFile>   log_files_list = new List<LogFile>();
        // Конструкторы
        public edPlayer() 
        { 
            this.pilots_list.Sort(); 
            this.log_files_list.Sort(); 
        }
        public edPlayer(string name) 
        { 
            this.pilots_list.Sort(); 
            this.log_files_list.Sort(); 
            this.CreateNewPilot(name); 
        }

        /// <summary>
        /// Создаёт новый объект "Пилот"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CreateNewPilot(string name)
        {
            PilotData pilot=new PilotData(name);
            if(pilot is null)
                return false;
            this.AddNewPilot(pilot);
            return true;
        }

        protected void AddNewPilot(PilotData pilot)
        {
            if(!this.pilots_list.Contains(pilot))
                this.pilots_list.Add(pilot);
        }
        public int PilotsCount() { return this.pilots_list.Count; }
        public PilotData Pilot() { return this.pilots_list.ElementAt(0); }
        public PilotData Pilot(int index) 
        {
            if(this.pilots_list.Count == 0)
                return null;
            return this.pilots_list.ElementAt(index < 0 ? 0 : index > pilots_list.Count-1 ? pilots_list.Count-1 : index); 
        }
        public List<LogFile> GetListLogFiles() { return this.log_files_list; }

        /// <summary>
        /// Создаёт список всех лог-файлов игры за всё время (Альфа не учитывается)
        /// </summary>
        /// <param name="path_to_logs"></param>
        /// <returns></returns>
        public bool CollectLogFilesAll(string path_to_logs)
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
        /// Возвращает из строки имя пилота
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public string PilotName(string line)
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
        public DateTime EventTime(string line)
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
        public string SquadronName(string line)
        {
            int beg = line.IndexOf("SquadronName")+15;
            int end = line.IndexOf(",", beg);
            return line.Substring(beg, end - beg - 1);
        }
    }
}
