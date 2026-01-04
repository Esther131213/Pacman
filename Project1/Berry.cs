using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    public class Berry
    {
        Texture2D tex;
        public Vector2 pos;
        public int pointAmount = 15;
        public Rectangle hitbox;

        public Berry(Texture2D tex, Vector2 pos)
        {
            this.tex = tex;
            this.pos = pos;
            hitbox.X = (int)pos.X+8;
            hitbox.Y = (int)pos.Y+8;
            hitbox.Width = tex.Width/2;
            hitbox.Height = tex.Height/2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex,pos,Color.White);
            //spriteBatch.Draw(TextureHandler.hitBox, new Vector2(hitbox.X, hitbox.Y), hitbox, Color.Blue);
        }
    }
}
