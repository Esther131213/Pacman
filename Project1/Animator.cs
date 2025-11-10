using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Animator
    {
        public int frame { get; private set; }
        private int maxFrames;

        private Texture2D spriteSheet;
        private int[] interval;
        private int timer;

        private Vector2 position;

        public Animator(Texture2D spriteSheet, int[] interval, Vector2 pos)
        {
            this.spriteSheet = spriteSheet;
            this.interval = interval;
            timer = interval[0];
            maxFrames = interval.Length;
            position = pos;
        }

        public void Update(Vector2 pos)
        {
            position = pos;
            timer--;

            if (timer <= 0)
            {
                frame = (frame + 1) % maxFrames;
                timer = interval[frame];
            }
        }

        public void Draw(SpriteBatch sb, float rotation)
        {
            sb.Draw(spriteSheet, position, new Rectangle(spriteSheet.Width / maxFrames * frame, 0, spriteSheet.Width / maxFrames, spriteSheet.Height), Color.White, rotation, new Vector2(spriteSheet.Width / (maxFrames * 2), spriteSheet.Height / 2), 1, SpriteEffects.None, 0);
        }
    }
}
