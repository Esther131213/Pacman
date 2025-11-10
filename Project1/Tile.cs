using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.ComponentModel;

namespace Project1
{
    public class Tile
    {
        public bool isWalkable;
        public bool ghostWalkable;
        public Rectangle sourceRectangle;
        public Texture2D tex;
        Vector2 pos;
        int tileSize = 32;

        public Tile(bool isWalkable, bool ghostWalkable, Rectangle sourceRectangle, Texture2D tex, Vector2 pos)
        {
            this.tex = tex;
            this.pos = pos;
            this.isWalkable = isWalkable;
            this.ghostWalkable = ghostWalkable;
            this.sourceRectangle = sourceRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, new Rectangle((int)pos.X, (int)pos.Y, tileSize, tileSize), sourceRectangle, Color.White);
        }
    }
}
