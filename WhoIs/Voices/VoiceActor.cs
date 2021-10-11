using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WhoIs
{
    class VoiceActor
    {
        private string actorName;
        private string actorFolder;

        // Конструкторы
        public VoiceActor()
        {
            actorName = "";
            actorFolder = "";
        }
        public VoiceActor(string actor_name)
        {
            this.actorName = actor_name;
        }

        // Устанавливает/возвращает имя
        public void SetName(string name) { this.actorName = name; }
        public string GetName() { return this.actorName; }

        // Проигрывает одиночный звуковой файл
        protected void Play(string file_name) 
        {
        using(MemoryStream fileOut = new MemoryStream(Properties.Resources.About_Alena))
        using(GZipStream gz = new GZipStream(fileOut, CompressionMode.Decompress))
            new SoundPlayer(gz).Play();
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
