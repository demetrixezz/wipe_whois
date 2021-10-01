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


