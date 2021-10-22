using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Media;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoIs
{
    public class VoiceActorsCollection
    {
        private List<VoiceActor> list_actors = null;
        public VoiceActorsCollection()
        {
            this.list_actors = new List<VoiceActor>();
            this.list_actors.Sort();
            VoiceActor actorAlena = new VoiceActor("Алёна", "Alena");
            VoiceActor actorFilipp= new VoiceActor("Филипп", "Filipp");
            this.list_actors.Add(actorAlena);
            this.list_actors.Add(actorFilipp);
            actorAlena.ID(this.list_actors.IndexOf(actorAlena));
            actorFilipp.ID(this.list_actors.IndexOf(actorFilipp));
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

    public class VoiceActor
    {
        public  ActorNames  Name;
        public  bool        Used;
        private int         identifier;
        private string      programm_path;

        // Конструкторы
        public VoiceActor()
        {
            this.Name.Display = "";
            this.Name.Program = "";
            this.Used = false;
            this.identifier = -1;
            this.programm_path = Application.StartupPath;
        }
        public VoiceActor(string actor_name, string actor_program_name)
        {
            this.Name.Display = actor_name;
            this.Name.Program = actor_program_name;
            this.Used = false;
            this.identifier = -1;
            this.programm_path = Application.StartupPath;
        }
        public VoiceActor(string actor_name, string folder_name, string actor_program_name)
        {
            this.Name.Display = actor_name;
            this.Name.Program = actor_program_name;
            this.Used = false;
            this.identifier = -1;
            this.programm_path = Application.StartupPath;
        }

        public void ID(int id)  { this.identifier = id;     }
        public int  ID()        { return this.identifier;   }

        /// <summary>
        /// Создаёт сжатый gz-файл из wav-файла и записывает его в ресурсы
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="game_event"></param>
        private void CreateRecourceSound(string file_path, string event_name)
        {
            string gzName = GetResourceFileName(event_name, this);
            using(FileStream fileIn = File.OpenRead($@"{file_path}.wav"))
            using(FileStream fileOut = File.Create($@"{file_path}.gz"))
            using(GZipStream gz = new GZipStream(fileOut, CompressionLevel.Optimal))
                fileIn.CopyTo(gz);
        }

        // Проигрывает одиночный звуковой файл
        protected void Play(string event_name, VoiceActor actor) 
        {
        //using(MemoryStream fileOut = new MemoryStream(Properties.Resources.About_Alena))
        //using(GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
        //    new SoundPlayer(gz).Play();
        
            var obj = Properties.Resources.ResourceManager.GetObject(GetResourceFileName(event_name, actor));
        using(MemoryStream fileOut = new MemoryStream(Properties.Resources.About_Alena))
        using(GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
            new SoundPlayer(gz).Play();
        }
        
        //value = Properties.Resources.ResourceManager.GetObject(GetResourceFileName(event_name, actor));
        protected string GetResourceFileName(string event_name, VoiceActor actor)
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
