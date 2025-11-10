using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    public class TextureHandler
    {
        public static Texture2D TileMap;
        public static Texture2D Pacman;

        public static void LoadTextures(ContentManager content)
        {
            TileMap = content.Load<Texture2D>("PacmanPath");
            Pacman = content.Load<Texture2D>("PacmanSpriteSheet");
        }
    }
}
