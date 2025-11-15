using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using thirdlySeasonTankBattle.Properties;

namespace thirdlySeasonTankBattle.Manager
{
    internal class GameSoundManager
    {
        private static SoundPlayer startPlay = new SoundPlayer(Resources.start);
        private static SoundPlayer addPlay = new SoundPlayer(Resources.add);
        private static SoundPlayer blastPlay = new SoundPlayer(Resources.blast);
        private static SoundPlayer firePlay = new SoundPlayer(Resources.fire);
        private static SoundPlayer hitPlay = new SoundPlayer(Resources.hit);

        /// <summary>
        /// 播放游戏开始音效
        /// </summary>
        public static void PlayStart()
        {
            startPlay.Play();
        }

        /// <summary>
        /// 播放游戏内生成敌方坦克的音效
        /// </summary>
        public static void PlayAdd()
        {
            addPlay.Play();
        }

        /// <summary>
        /// 播放游戏内子弹碰撞后发生爆炸的音效
        /// </summary>
        public static void PlayBlast()
        {
            blastPlay.Play();
        }

        /// <summary>
        /// 播放游戏内我方坦克发射子弹的音效
        /// </summary>
        public static void PlayFire()
        {
            firePlay.Play();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void PlayHit()
        {
            hitPlay.Play();
        }
    }
}
