using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Media;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EliteJournalReader;

namespace WhoIs
{
    public enum ENUM_VOICE_EVENT_DATA_INDEXES
    {
        VOICE_EVENT_AFMUREPAIRS,
        VOICE_EVENT_APPLIED_TO_SQUADRON,
        VOICE_EVENT_APPROACH_BODY,
        VOICE_EVENT_APPROACH_SETTLEMENT,
        VOICE_EVENT_ASTEROID_CRACKED,
        VOICE_EVENT_BACKPACK_MATERIALS,
        VOICE_EVENT_BOOK_DROPSHIP,
        VOICE_EVENT_BOOK_TAXI,
        VOICE_EVENT_BOUNTY,
        VOICE_EVENT_BUY_AMMO,
        VOICE_EVENT_BUY_DRONES,
        VOICE_EVENT_BUY_EXPLORATION_DATA,
        VOICE_EVENT_BUY_MICRO_RESOURCES,
        VOICE_EVENT_BUY_SUIT,
        VOICE_EVENT_BUY_TRADE_DATA,
        VOICE_EVENT_BUY_WEAPON,
        VOICE_EVENT_CANCEL_DROPSHIP,
        VOICE_EVENT_CANCEL_TAXI,
        VOICE_EVENT_CAP_SHIP_BOND,
        VOICE_EVENT_CARGO_DEPOT,
        VOICE_EVENT_CARGO,
        VOICE_EVENT_CARGO_TRANSFER,
        VOICE_EVENT_CARRIER_BANK_TRANSFER,
        VOICE_EVENT_CARRIER_BUY,
        VOICE_EVENT_CARRIER_CANCEL_DECOMMISSION,
        VOICE_EVENT_CARRIER_CREW_SERVICES,
        VOICE_EVENT_CARRIER_DECOMMISSION,
        VOICE_EVENT_CARRIER_DEPOSIT_FUEL,
        VOICE_EVENT_CARRIER_DOCKING_PERMISSION,
        VOICE_EVENT_CARRIER_FINANCE,
        VOICE_EVENT_CARRIER_JUMP_CANCELLED,
        VOICE_EVENT_CARRIER_JUMP,
        VOICE_EVENT_CARRIER_JUMP_REQUEST,
        VOICE_EVENT_CARRIER_MODULE_PACK,
        VOICE_EVENT_CARRIER_NAME_CHANGED,
        VOICE_EVENT_CARRIER_SHIP_PACK,
        VOICE_EVENT_CARRIER_STATS,
        VOICE_EVENT_CARRIER_TRADE_ORDER,
        VOICE_EVENT_CHANGE_CREW_ROLE,
        VOICE_EVENT_CLEAR_SAVED_GAME,
        VOICE_EVENT_COCKPIT_BREACHED,
        VOICE_EVENT_CODEX_ENTRY,
        VOICE_EVENT_COLLECT_CARGO,
        VOICE_EVENT_COLLECT_ITEMS,
        VOICE_EVENT_COMMANDER,
        VOICE_EVENT_COMMIT_CRIME,
        VOICE_EVENT_COMMUNITY_GOAL_DISCARD,
        VOICE_EVENT_COMMUNITY_GOAL,
        VOICE_EVENT_COMMUNITY_GOAL_JOIN,
        VOICE_EVENT_COMMUNITY_GOAL_REWARD,
        VOICE_EVENT_CONTINUED,
        VOICE_EVENT_CREATE_SUIT_LOADOUT,
        VOICE_EVENT_CREW_ASSIGN,
        VOICE_EVENT_CREW_FIRE,
        VOICE_EVENT_CREW_HIRE,
        VOICE_EVENT_CREW_LAUNCH_FIGHTER,
        VOICE_EVENT_CREW_MEMBER_JOINS,
        VOICE_EVENT_CREW_MEMBER_QUITS,
        VOICE_EVENT_CREW_MEMBER_ROLE_CHANGE,
        VOICE_EVENT_CRIME_VICTIM,
        VOICE_EVENT_DATALINK_SCAN,
        VOICE_EVENT_DATALINK_VOUCHER,
        VOICE_EVENT_DATA_SCANNED,
        VOICE_EVENT_DELETE_SUIT_LOADOUT,
        VOICE_EVENT_DIED,
        VOICE_EVENT_DISBANDED_SQUADRON,
        VOICE_EVENT_DISCOVERY_SCAN,
        VOICE_EVENT_DISEMBARK,
        VOICE_EVENT_DOCKED,
        VOICE_EVENT_DOCK_FIGHTER,
        VOICE_EVENT_DOCKING_CANCELLED,
        VOICE_EVENT_DOCKING_DENIED,
        VOICE_EVENT_DOCKING_GRANTED,
        VOICE_EVENT_DOCKING_REQUESTED,
        VOICE_EVENT_DOCKING_TIMEOUT,
        VOICE_EVENT_DOCK_SRV,
        VOICE_EVENT_DROP_ITEMS,
        VOICE_EVENT_DROP_SHIP_DEPLOY,
        VOICE_EVENT_EJECT_CARGO,
        VOICE_EVENT_EMBARK,
        VOICE_EVENT_END_CREW_SESSION,
        VOICE_EVENT_ENGINEER_CONTRIBUTION,
        VOICE_EVENT_ENGINEER_CRAFT,
        VOICE_EVENT_ENGINEER_LEGACY_CONVERT,
        VOICE_EVENT_ENGINEER_PROGRESS,
        VOICE_EVENT_ESCAPE_INTERDICTION,
        VOICE_EVENT_FACTION_KILL_BOND,
        VOICE_EVENT_FETCH_REMOTE_MODULE,
        VOICE_EVENT_FIGHTER_DESTROYED,
        VOICE_EVENT_FIGHTER_REBUILT,
        VOICE_EVENT_FILEHEADER,
        VOICE_EVENT_FRIENDS,
        VOICE_EVENT_FSD_JUMP,
        VOICE_EVENT_FSD_TARGET,
        VOICE_EVENT_FSS_ALL_BODIES_FOUND,
        VOICE_EVENT_FSS_DISCOVERY_SCAN,
        VOICE_EVENT_FSS_SIGNAL_DISCOVERED,
        VOICE_EVENT_FUEL_SCOOP,
        VOICE_EVENT_HEAT_DAMAGE,
        VOICE_EVENT_HEAT_WARNING,
        VOICE_EVENT_HULL_DAMAGE,
        VOICE_EVENT_INTERDICTED,
        VOICE_EVENT_INTERDICTION,
        VOICE_EVENT_INVITED_TO_SQUADRON,
        VOICE_EVENT_MAGIC_MAU_IS_LIVE_EVENT,
        VOICE_EVENT_JET_CONE_BOOST,
        VOICE_EVENT_JET_CONE_DAMAGE,
        VOICE_EVENT_JOIN_A_CREW,
        VOICE_EVENT_JOINED_SQUADRON,
        VOICE_EVENT_KICK_CREW_MEMBER,
        VOICE_EVENT_KICKED_FROM_SQUADRON,
        VOICE_EVENT_LAUNCH_DRONE,
        VOICE_EVENT_LAUNCH_FIGHTER,
        VOICE_EVENT_LAUNCH_SRV,
        VOICE_EVENT_LEAVE_BODY,
        VOICE_EVENT_LEFT_SQUADRON,
        VOICE_EVENT_LIFTOFF,
        VOICE_EVENT_LOAD_GAME,
        VOICE_EVENT_LOADOUT_EQUIP_MODULE,
        VOICE_EVENT_LOADOUT,
        VOICE_EVENT_LOADOUT_REMOVE_MODULE,
        VOICE_EVENT_LOCATION,
        VOICE_EVENT_MARKET_BUY,
        VOICE_EVENT_MARKET,
        VOICE_EVENT_MARKET_REFINED,
        VOICE_EVENT_MARKET_SELL,
        VOICE_EVENT_MASS_MODULE_STORE,
        VOICE_EVENT_MATERIAL_COLLECTED,
        VOICE_EVENT_MATERIAL_DISCARDED,
        VOICE_EVENT_MATERIAL_DISCOVERED,
        VOICE_EVENT_MATERIALS,
        VOICE_EVENT_MATERIAL_TRADE,
        VOICE_EVENT_MINING_REFINED,
        VOICE_EVENT_MISSION_ABANDONED,
        VOICE_EVENT_MISSION_ACCEPTED,
        VOICE_EVENT_MISSION_COMPLETED,
        VOICE_EVENT_MISSION_FAILED,
        VOICE_EVENT_MISSION_REDIRECTED,
        VOICE_EVENT_MISSIONS,
        VOICE_EVENT_MODULE_BUY,
        VOICE_EVENT_MODULE_INFO,
        VOICE_EVENT_MODULE_RETRIEVE,
        VOICE_EVENT_MODULE_SELL,
        VOICE_EVENT_MODULE_SELL_REMOTE,
        VOICE_EVENT_MODULES_INFO,
        VOICE_EVENT_MODULE_STORE,
        VOICE_EVENT_MODULE_SWAP,
        VOICE_EVENT_MULTI_SELL_EXPLORATION_DATA,
        VOICE_EVENT_MUSIC,
        VOICE_EVENT_NAV_BEACON_SCAN,
        VOICE_EVENT_NAV_ROUTE,
        VOICE_EVENT_NEW_COMMANDER,
        VOICE_EVENT_NPC_CREW_PAID_WAGE,
        VOICE_EVENT_NPC_CREW_RANK,
        VOICE_EVENT_OUTFITTING,
        VOICE_EVENT_PASSENGERS,
        VOICE_EVENT_PAY_BOUNTIES,
        VOICE_EVENT_PAY_FINES,
        VOICE_EVENT_PAY_LEGACY_FINES,
        VOICE_EVENT_POWERPLAY_COLLECT,
        VOICE_EVENT_POWERPLAY_DEFECT,
        VOICE_EVENT_POWERPLAY_DELIVER,
        VOICE_EVENT_POWERPLAY,
        VOICE_EVENT_POWERPLAY_FAST_TRACK,
        VOICE_EVENT_POWERPLAY_JOIN,
        VOICE_EVENT_POWERPLAY_LEAVE,
        VOICE_EVENT_POWERPLAY_SALARY,
        VOICE_EVENT_POWERPLAY_VOTE,
        VOICE_EVENT_POWERPLAY_VOUCHER,
        VOICE_EVENT_PROGRESS,
        VOICE_EVENT_PROMOTION,
        VOICE_EVENT_PROSPECTED_ASTEROID,
        VOICE_EVENT_PVP_KILL,
        VOICE_EVENT_QUIT_A_CREW,
        VOICE_EVENT_RANK,
        VOICE_EVENT_REBOOT_REPAIR,
        VOICE_EVENT_RECEIVE_TEXT,
        VOICE_EVENT_REDEEM_VOUCHER,
        VOICE_EVENT_REFUEL_ALL,
        VOICE_EVENT_REFUEL_PARTIAL,
        VOICE_EVENT_RENAME_SUIT_LOADOUT,
        VOICE_EVENT_REPAIR_ALL,
        VOICE_EVENT_REPAIR_DRONE,
        VOICE_EVENT_REPAIR,
        VOICE_EVENT_REPUTATION,
        VOICE_EVENT_RESERVOIR_REPLENISHED,
        VOICE_EVENT_RESTOCK_VEHICLE,
        VOICE_EVENT_RESURRECT,
        VOICE_EVENT_ROUTE,
        VOICE_EVENT_SAA_SCAN_COMPLETE,
        VOICE_EVENT_SAA_SIGNALS_FOUND,
        VOICE_EVENT_SCAN,
        VOICE_EVENT_SCANNED,
        VOICE_EVENT_SCAN_ORGANIC,
        VOICE_EVENT_SCIENTIFIC_RESEARCH,
        VOICE_EVENT_SCREENSHOT,
        VOICE_EVENT_SEARCH_AND_RESCUE,
        VOICE_EVENT_SELF_DESTRUCT,
        VOICE_EVENT_SELL_DRONES,
        VOICE_EVENT_SELL_EXPLORATION_DATA,
        VOICE_EVENT_SELL_MICRO_RESOURCES,
        VOICE_EVENT_SELL_ORGANIC_DATA,
        VOICE_EVENT_SELL_SHIP_ON_REBUY,
        VOICE_EVENT_SELL_SUIT,
        VOICE_EVENT_SELL_WEAPON,
        VOICE_EVENT_SEND_TEXT,
        VOICE_EVENT_SET_USER_SHIP_NAME,
        VOICE_EVENT_SHARED_BOOKMARK_TO_SQUADRON,
        VOICE_EVENT_SHIELD_STATE,
        VOICE_EVENT_SHIP_LOCKER,
        VOICE_EVENT_SHIP_LOCKER_MATERIALS,
        VOICE_EVENT_SHIP_TARGETED,
        VOICE_EVENT_SHIPYARD_BUY,
        VOICE_EVENT_SHIPYARD,
        VOICE_EVENT_SHIPYARD_NEW,
        VOICE_EVENT_SHIPYARD_SELL,
        VOICE_EVENT_SHIPYARD_SWAP,
        VOICE_EVENT_SHIPYARD_TRANSFER,
        VOICE_EVENT_SHUTDOWN,
        VOICE_EVENT_SQUADRON_CREATED,
        VOICE_EVENT_SQUADRON_DEMOTION,
        VOICE_EVENT_SQUADRON_PROMOTION,
        VOICE_EVENT_SQUADRON_STARTUP,
        VOICE_EVENT_SRV_DESTROYED,
        VOICE_EVENT_START_JUMP,
        VOICE_EVENT_STATISTICS,
        VOICE_EVENT_STORED_MODULES,
        VOICE_EVENT_STORED_SHIPS,
        VOICE_EVENT_SUPERCRUISE_ENTRY,
        VOICE_EVENT_SUPERCRUISE_EXIT,
        VOICE_EVENT_SWITCH_SUIT_LOADOUT,
        VOICE_EVENT_SYNTHESIS,
        VOICE_EVENT_SYSTEMS_SHUTDOWN,
        VOICE_EVENT_TECHNOLOGY_BROKER,
        VOICE_EVENT_TOUCHDOWN,
        VOICE_EVENT_TRADE_MICRO_RESOURCES,
        VOICE_EVENT_TRANSFER_MICRO_RESOURCES,
        VOICE_EVENT_UNDER_ATTACK,
        VOICE_EVENT_UNDOCKED,
        VOICE_EVENT_UPGRADE_SUIT,
        VOICE_EVENT_UPGRADE_WEAPON,
        VOICE_EVENT_USE_CONSUMABLE,
        VOICE_EVENT_USS_DROP,
        VOICE_EVENT_VEHICLE_SWITCH,
        VOICE_EVENT_WING_ADD,
        VOICE_EVENT_WING_JOIN,
        VOICE_EVENT_WING_LEAVE,
        VOICE_EVENT_WON_A_TROPHY_FOR_SQUADRON,
    }
    
    public class VoiceActorsCollection
    {
        private List<VoiceActor> list_actors = null;
        private Panel PanelParent = null;
        public VoiceActorsCollection(Panel panelParent)
        {
            this.list_actors = new List<VoiceActor>();
            this.list_actors.Sort();
            this.PanelParent = panelParent;
            this.AddNewActor(this.list_actors.Count, "Алёна", "Alena");
            this.AddNewActor(this.list_actors.Count, "Филипп", "Filipp");
            this.list_actors.ElementAt(0).Used = true;
            //MessageBox.Show("Count=" + list_actors.Count.ToString(), "VoiceActorsCollection");
        }

        /// <summary>
        /// Возвращает список ассистентов
        /// </summary>
        /// <returns></returns>
        public List<VoiceActor> List() { return this.list_actors; }
        /// <summary>
        /// Возвращает количество ассистентов
        /// </summary>
        /// <returns></returns>
        public int Count() { return this.list_actors.Count; }
        /// <summary>
        /// Добавляет нового ассистента как ранее созданный объект VoiceActor
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        public bool AddNewActor(VoiceActor actor)
        {
            foreach(VoiceActor vactor in this.list_actors)
                if(vactor.Name.Display == actor.Name.Display || vactor.Name.Program == actor.Name.Program)
                    return false;
            actor.ID = this.list_actors.Count;
            actor.PrevID(this.list_actors.Count - 1);
            this.list_actors.Add(actor);
            //MessageBox.Show("Count=" + list_actors.Count.ToString(), "AddNewActor");
            return true;
        }
        /// <summary>
        /// Добавляет нового ассистента по указанному имени (отображаемому русскому и программному англ.)
        /// </summary>
        /// <param name="actor_name"></param>
        /// <param name="actor_program_name"></param>
        /// <returns></returns>
        public bool AddNewActor(int actorID, string actor_name, string actor_program_name)
        {
            VoiceActor actor = new VoiceActor(actorID, actor_name, actor_program_name, this.PanelParent);
            foreach(VoiceActor vactor in this.list_actors)
                if(vactor.Name.Display == actor_name || vactor.Name.Program == actor_program_name)
                    return false;
            actor.ID = actorID;
            actor.PrevID(actorID - 1);
            this.list_actors.Add(actor);
            //MessageBox.Show("Count=" + list_actors.Count.ToString() + "actor.ID="+ actor.ID.ToString(), "AddNewActor");
            return true;
        }

        /// <summary>
        /// Возвращает объект ассистента по индексу
        /// Если индекс меньше нуля - возвращает первого ассистента
        /// Если индекс больше общего количества - возвращает последнего
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public VoiceActor Actor(int index) 
        {
            return this.list_actors.ElementAt(index < 0 ? 0 : index > this.Count() - 1 ? this.Count() - 1 : index); 
        }
        /// <summary>
        /// Возвращает текущего установленного ассистента
        /// </summary>
        /// <returns></returns>
        public VoiceActor CurrentUsedActor()
        {
            foreach(VoiceActor actor in this.list_actors)
                if(actor.Used)
                    return actor;
            return null;
        }
        /// <summary>
        /// Возвращает ассистента по его отображаемому имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public VoiceActor ActorByDisplayName(string name)
        {
            foreach(VoiceActor actor in this.list_actors)
                if(actor.Name.Display == name)
                    return actor;
            return null;
        }
        /// <summary>
        /// Возвращает ассистента по его программному имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public VoiceActor ActorByProgramName(string name)
        {
            foreach(VoiceActor actor in this.list_actors)
                if(actor.Name.Program == name)
                    return actor;
            return null;
        }
    }
    
    /// <summary>
    /// Структура имён ассистента
    /// </summary>
    public struct ActorNames
    {
        public string  Display; // Отображаемое имя (рус)
        public string  Program; // Программное имя (англ)
    }
    /// <summary>
    /// Класс "Голосовой ассистент"
    /// </summary>
    public class VoiceActor
    {
        public  ActorNames  Name;
        public  bool        Used = false;
        public  int         ID = -1;
        private int         id_prev = -1;
        private string      sounds_data_path = "";
        private Panel       PanelParent = null;
        private SplitContainer Panel = null;
        private Label       Header = null;
        private Button      ButtonListen = null;
        private RadioButton ButtonSetActor = null;
        
        /// <summary>
        /// Конструктор без параметров.
        /// После создания объекта требуется установить отображаемое и программное имя,
        /// флаг использования, идентификаторы этого и предыдущего ассистента,
        /// а также дополнить путь к папке хранения звуковых файлов, и указать родительскую панель.
        /// </summary>
        public VoiceActor()
        {
            this.Name.Display = "";
            this.Name.Program = "";
            this.Used = false;
            this.ID = -1;
            this.id_prev = -1;
            this.sounds_data_path = Application.StartupPath + "\\Sounds\\";
        }
        /// <summary>
        /// Параметрический конструктор. 
        /// После создания объекта требуется установить флаг использования, идентификаторы этого и предыдущего ассистента.
        /// </summary>
        /// <param name="actor_name"></param>
        /// <param name="actor_program_name"></param>
        /// <param name="panelParent"></param>
        public VoiceActor(string actor_name, string actor_program_name, Panel panelParent)
        {
            this.Name.Display = actor_name;
            this.Name.Program = actor_program_name;
            this.Used = false;
            this.ID = -1;
            this.id_prev = -1;
            this.sounds_data_path = Application.StartupPath + "\\Sounds\\" + actor_program_name;
            this.PanelParent = panelParent;
        }
        /// <summary>
        /// Параметрический конструктор.
        /// После создания объекта требуется установить флаг использования, идентификаторы этого и предыдущего ассистента.
        /// </summary>
        /// <param name="actor_name"></param>
        /// <param name="folder_name"></param>
        /// <param name="actor_program_name"></param>
        /// <param name="panelParent"></param>
        public VoiceActor(string actor_name, string folder_name, string actor_program_name, Panel panelParent)
        {
            this.Name.Display = actor_name;
            this.Name.Program = actor_program_name;
            this.Used = false;
            this.ID = -1;
            this.id_prev = -1;
            this.sounds_data_path = Application.StartupPath + "\\Sounds\\" + actor_program_name;
            this.PanelParent = panelParent;
        }
        /// <summary>
        /// Параметрический конструктор.
        /// Все параметры и свойства задаются автоматически.
        /// </summary>
        /// <param name="actorID"></param>
        /// <param name="actor_name"></param>
        /// <param name="actor_program_name"></param>
        /// <param name="panelParent"></param>
        public VoiceActor(int actorID, string actor_name, string actor_program_name, Panel panelParent)
        {
            this.Name.Display = actor_name;
            this.Name.Program = actor_program_name;
            this.Used = false;
            this.ID = actorID;
            this.id_prev = actorID - 1;
            this.sounds_data_path = Application.StartupPath + "\\Sounds\\" + actor_program_name;
            this.PanelParent = panelParent;
            this.CreateControlPanel();
        }
        /// <summary>
        /// Создаёт панель управления
        /// </summary>
        /// <returns></returns>
        public bool CreateControlPanel()
        {
            if(PanelParent == null)
                return false;
            this.Panel = new SplitContainer();
            this.InitControlPanel();
            this.Header = new Label();
            this.InitHeader();
            this.ButtonListen = new Button();
            this.InitButtonListen();
            this.ButtonSetActor = new RadioButton();
            this.InitButtonSetActor();

            this.Panel.Show();
            this.Header.Show();
            this.ButtonListen.Show();
            this.ButtonSetActor.Show();
            return true;
        }
        /// <summary>
        /// Инициализация свойств панели управления
        /// </summary>
        private void InitControlPanel()
        {
            if(this.Panel == null)
                return;
            this.PanelParent.Controls.Add(this.Panel);
            this.Panel.Width = this.Panel.Parent.Width - 18;
            this.Panel.Height = 59;
            this.Panel.IsSplitterFixed = true;
            this.Panel.SplitterDistance = 217;
            this.Panel.SplitterWidth = 3;
            this.Panel.Location = new Point(10, (8 + this.ID * this.Panel.Height) + (this.ID == 0 ? 0 : 4));
            this.Panel.BackColor = Color.FromArgb(47, 49, 54);
            this.Panel.BorderStyle = BorderStyle.FixedSingle;
            this.Panel.ForeColor = Color.FromArgb(171, 171, 171);
            this.Panel.Panel1.BackColor = Color.FromArgb(47, 49, 54);
            this.Panel.Panel1.ForeColor = Color.FromArgb(171, 171, 171);
            this.Panel.Panel2.BackColor = Color.FromArgb(47, 49, 54);
            this.Panel.Panel2.ForeColor = Color.FromArgb(171, 171, 171);

            MessageBox.Show(this.Description() + ": ID = " + this.ID + ": X = " + Panel.Location.X.ToString() + ", Y = " + Panel.Location.Y.ToString());
        }
        /// <summary>
        /// Инициализация свойств заголовка панели управления (имя ассистента)
        /// </summary>
        private void InitHeader()
        {
            if(this.Header == null)
                return;
            this.Panel.Panel1.Controls.Add(this.Header);
            this.Header.Text = this.Description();
            this.Header.Location = new Point(5, 5);
            this.Header.Width = 113;
            this.Header.Height = 13;
            this.Header.AutoSize = true;
            this.Header.BackColor = Color.FromArgb(47, 49, 54);
            this.Header.ForeColor = Color.FromArgb(171, 171, 171);
            this.Header.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
        }
        /// <summary>
        /// Инициализация свойств кнопки "Прослушать" голос ассистента
        /// </summary>
        private void InitButtonListen()
        {
            if(this.ButtonListen == null)
                return;
            this.Panel.Panel1.Controls.Add(this.ButtonListen);
            this.ButtonListen.BackColor = Color.FromArgb(57, 59, 64);
            this.ButtonListen.ForeColor = Color.FromArgb(171, 171, 171);
            this.ButtonListen.Location = new Point(5, 24);
            this.ButtonListen.Width = 100;
            this.ButtonListen.Height = 26;
            this.ButtonListen.Text = "Прослушать";
            this.ButtonListen.TextAlign = ContentAlignment.MiddleCenter;
            this.ButtonListen.FlatStyle = FlatStyle.Flat;
            this.ButtonListen.FlatAppearance.BorderColor = Color.FromArgb(57, 59, 64);
            this.ButtonListen.FlatAppearance.BorderSize = 0;
            this.ButtonListen.FlatAppearance.MouseDownBackColor = Color.FromArgb(77, 79, 94);
            this.ButtonListen.FlatAppearance.MouseOverBackColor = Color.FromArgb(67, 69, 74);

            this.ButtonListen.Click += (s, e) =>
            {
                MessageBox.Show("Путь к папке звуков:\n" + this.sounds_data_path);
            };
        }
        /// <summary>
        /// Инициализация свойств кнопки "Установить" ассистента
        /// </summary>
        private void InitButtonSetActor()
        {
            if(this.ButtonSetActor == null)
                return;
            this.Panel.Panel1.Controls.Add(this.ButtonSetActor);
            this.ButtonSetActor.Appearance = Appearance.Button;
            this.ButtonSetActor.BackColor = Color.FromArgb(57, 59, 64);
            this.ButtonSetActor.ForeColor = Color.FromArgb(171, 171, 171);
            this.ButtonSetActor.Location = new Point(110, 24);
            this.ButtonSetActor.Width = 100;
            this.ButtonSetActor.Height = 26;
            this.ButtonSetActor.Text = "Установить";
            this.ButtonSetActor.TextAlign = ContentAlignment.MiddleCenter;
            this.ButtonSetActor.FlatStyle = FlatStyle.Flat;
            this.ButtonSetActor.FlatAppearance.BorderColor = Color.FromArgb(57, 59, 64);
            this.ButtonSetActor.FlatAppearance.BorderSize = 0;
            this.ButtonSetActor.FlatAppearance.CheckedBackColor = Color.FromArgb(57, 109, 64);
            this.ButtonSetActor.FlatAppearance.MouseDownBackColor = (!this.ButtonSetActor.Checked ? Color.FromArgb(77, 79, 94) : Color.FromArgb(77, 129, 84));
            this.ButtonSetActor.FlatAppearance.MouseOverBackColor = (!this.ButtonSetActor.Checked ? Color.FromArgb(67, 69, 74) : Color.FromArgb(67, 119, 74));
            this.ButtonSetActor.AutoCheck = false;

            /// <summary>
            /// Обработчик клика по кнопке
            /// </summary>
            this.ButtonSetActor.Click += (s, e) =>
            {
                this.ButtonSetActor.Checked = !this.ButtonSetActor.Checked;
                if(this.ButtonSetActor.Checked)
                    this.SetON();
                else
                    this.SetOFF();
            };

        }
        /// <summary>
        /// Установка состояния ассистента "Установлен" и свойств кнопки в этом состоянии
        /// </summary>
        public void SetON()
        {
            this.ButtonSetActor.FlatAppearance.MouseDownBackColor = Color.FromArgb(77, 129, 84);
            this.ButtonSetActor.FlatAppearance.MouseOverBackColor = Color.FromArgb(67, 119, 74);
            this.ButtonSetActor.Text = "Установлен";
            this.Used = true;
        }
        /// <summary>
        /// Установка состояния ассистента "Установить" и свойств кнопки в этом состоянии
        /// </summary>
        public void SetOFF()
        {
            this.ButtonSetActor.FlatAppearance.MouseDownBackColor = Color.FromArgb(77, 79, 94);
            this.ButtonSetActor.FlatAppearance.MouseOverBackColor = Color.FromArgb(67, 69, 74);
            this.ButtonSetActor.Text = "Установить";
            this.Used = false;
        }

        public void PrevID(int id)  { this.id_prev = id;                                }
        public int  PrevID()        { return this.id_prev;                              }
        public string Description() { return $"Ассистент: {this.Name.Display}";         }
        public int  PanelTop()      { return this.Panel.Location.Y;                     }
        public int  PanelBottom()   { return this.Panel.Location.Y + this.Panel.Height; }
        
        /// <summary>
        /// Создаёт сжатый gz-файл из wav-файла и записывает его в ресурсы
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="game_event"></param>
        private void CreateRecourceSound(string file_path, string event_name)
        {
            string gzName = GetResourceFileName(event_name);
            using(FileStream fileIn = File.OpenRead($@"{file_path}.wav"))
            using(FileStream fileOut = File.Create($@"{this.sounds_data_path}\{this.GetResourceFileName(event_name)}.gz"))
            using(GZipStream gz = new GZipStream(fileOut, CompressionLevel.Optimal))
                fileIn.CopyTo(gz);
        }

        // Проигрывает одиночный звуковой файл
        protected void Play(string event_name) 
        {
        //using(MemoryStream fileOut = new MemoryStream(Properties.Resources.About_Alena))
        //using(GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
        //    new SoundPlayer(gz).Play();
        
        var obj = Properties.Resources.ResourceManager.GetObject(GetResourceFileName(event_name));
        using(MemoryStream fileOut = new MemoryStream(Properties.Resources.About_Alena))
        using(GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
            new SoundPlayer(gz).Play();
        }
        
        //value = Properties.Resources.ResourceManager.GetObject(GetResourceFileName(event_name, actor));
        private string GetResourceFileName(string event_name)
        {
            string fileNameFormat = "{0}_{1}.gz";
            string fileName = string.Format(fileNameFormat, this.Name.Program, event_name);
            return fileName;
        }
    }
}

//Программа эскадрильи Вайп для оповещения пилотов о встреченных в космосе игроках. 
//Оповещает голосом об эскадре в которой состоит пилот и о сам+ом игроке, корабль которого находится в прицеле - 
//друг, враг, спир, зашкварщик или другой Бр+абен. Списки эскадр и пилотов, дружественных и враждебных 
//заносятся в базу данных администрацией эскадры Вайп, что исключает случайные или сомнительные убийства.


/*
"Послушник"
-----------------
TYPHOON) (Лёня)
+Vorobei+ (Валера)
-AgenT777- (Александр)
STALKER111 [Влад]
=BY=SNICKERS (Александр)
D.Lager
Abclex(Александр)
Aexxon (Антон)
Air 78 RUS (Кирилл)
Andrew Rais (Андрей)
Holmrand(Кирилл)
C4sssOWNER (Глебик)
Doping Net (Дмитрий)
CrazerAvrorA (Артем)
DeVOral(Николай)
Dias_Flack |Роман|
CMDR Dijerica (Арсений)
AbsturzDream
FighterJet (Андрей)
The_FuRiz (Саша)
Glebec (Глеб)
Gr2y82(Сергей)
SunstrikeFX (Андрей)
Kazerman (Коля)
Kotabuki (Влад)
Oleze(Олег)
Laegolasse
Rey Lynx (Андрей)
x_MAKCiM_x (Макс)
MemoRex_BLR
MotSarT (Руслан)
N.K.B.D
Sagittarius RUS (Кирилл)
Nimrad (Алексей)
Parus majer  Андрей Синица
Perfect_Sinner (грешный Андрій)
Poetiq (Толя)
sHaLoPaY (Влад)
Sonar/Jerkbait
SLA74
CMDR SOCRAT99 (Дмитрий)
Sanchez174(Саня)
Shtanishki (Миша)
Black_Angel(Иван)
Untraceab1e (Паша Трэйс)
VicPeTiv
VoDLight (Виталий)
Megalag(Андрей)
YadrenBaton (Ден)
[S]kY[N]ET  [Дмитрий]
DeH4uK (Денис)
digital_den_b (Дионисий)
Gvok (Юра)
Lerou_Game(Ильнар)
Mavir (Николай)
kucher9985(Anton)
m666rs(alex)
rohrick (Игорь)
syxapuk(Михаил)
XXEL (Ростислав)
KuiryoOne(Никита)
MallarWand (Артур)
Scrimer (Max)
MazzikKamazzik (Владимир)
[WIPE]Noldral(Ченан)


"Монах"
-----------------
-=Voyageur=-
9flyx[flyx]
Dementey (Дмитрий)
Asumaru
Cpt. Spirt (Иван)
DIKAPb(Александр)
DKey
DKey (Денис)
Evgenich (Женя)
F_E_N_I_K_S ( Сергей )
Faust-V (Виталий)
Grossgraf (Денис)
Jason Hill (Димон)
Jhonny K (Женя)
KAMA3OTXODOB(Михаил)
Kerastr (Миша)
Lagologo69 (Юрий)
Master ZenLee (Сергей UTC+7)
Michael Beryl
OptimYs (Валера)
PaToom (Паша)
Phantom Es0I
Призрак21 (Илья)
Rroman (Роман)
SPECTERsis (Ягайло)
SenzZzo
Serendypty (Илья)
Shevve(Саня)
SkyOne
Longade Horizon (Ярослав)
Thargoid
Ulairi (Саня)
Vadhrnt (Вадим)
AlexSever (Александр)
DiVits (Виктор)
Vladzimor(Владимир)
Vladyslav
Volkodav SR (Роман)
Warvolf (Вольфыч)
Westshot (Сергей)
Whisper00(Орест)
-WHITE-_(Антон)
dimmen
kirpichnikov_m
Konstantin Zalupa (Сергей)
Tankict_Zapasa (Игорь)
Vikarych (Дмитрий)
Михалыч1966
Михалыч1966 (Михаил)
𝐻𝑒𝓁𝓁𝓌𝑜𝓇𝓀𝑒𝓇(Лёха)

"Пастырь"
-----------------
DarkOui (Алексей)
DeQSer (святой Андрий)
Vlajni (Алексей)
E1St0rm (Денис)
Elite Tiger-UA (Виталик)
Kirtim (Василий) [WIPE]
Kosevich (Олег)
Luchezarny(Михаил)
Khetag Terrible (Хетаг)
Seasle (Саня/Шурик)
Vintir (Винтир)
Demetrixezz (Dimitris)
Aileen Leith (Илья)
eNmaXx (Max)
gromozeka 78
ISIN (Гоша)
kasaria (Алексей)
pahastik(Пахастик)
ruxa(Руслан)
𝕱𝖊𝖘𝖙𝖔𝖗 (святой Даний)
𝖆𝖗𝖙𝖊𝖒𝖜𝖆𝖞𝖓𝖊𝖘

"Аббат"
-----------------
AlexIE13 (Игорь)
DragoNext (Стас)
Satorio(Димас)
MadAbbe (Артем)
chechinskiy (Михаил)

"Архиепископ"
-----------------
Wild Priest (псевдоним = W|ld Priest)


*/
