using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDev_EindWerk1.Classes
{
    class SoundManager
    {
        private static SoundManager _sounds = new SoundManager();

        public Dictionary<string, Song> dictionary = new Dictionary<string, Song>();

        private SoundManager() { }
        public static SoundManager GetInstance()
        {
            return _sounds;
        }

        public void StartBackgroundMusic() {
            MediaPlayer.Play(dictionary["BackgroundSound"]);
        }
    }
}
