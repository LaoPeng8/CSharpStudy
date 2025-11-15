using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thirdlySeasonTankBattle.Properties;

namespace thirdlySeasonTankBattle.Entity
{
    internal class Explosion : GameObject
    {
        private Bitmap[] bmpArray = new Bitmap[]
        {
            Resources.EXP1,
            Resources.EXP2,
            Resources.EXP3,
            Resources.EXP4,
            Resources.EXP5
        };
        private int playSpeed = 1;
        private int playCount = 0;
        private int index = 0;
        public bool IsNeedDestroy { get; private set; }

        public Explosion(int x, int y)
        {
            foreach (var item in bmpArray)
            {
                item.MakeTransparent(Color.Black);
            }

            this.X = x - bmpArray[0].Width / 2;
            this.Y = y - bmpArray[0].Height / 2;
            IsNeedDestroy = false;
        }

        public override Image GetImage()
        {
            if(index > 4)
            {
                return bmpArray[4];
            }
            return bmpArray[index];
        }

        public override void Update()
        {
            playCount++;
            index = (playCount - 1) / playSpeed;
            if(index > 4)// 播放完了的爆炸效果就可以把状态设为销毁了, 同时直接return不绘制了, 后续爆炸效果在集合中存储大于一定阈值, 再统一清除状态为销毁的爆炸效果
            {
                IsNeedDestroy = true;
                return;
            }
            base.Update();
        }

    }
}
