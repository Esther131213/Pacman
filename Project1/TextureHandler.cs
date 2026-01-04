using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;

namespace Project1
{
    public class TextureHandler
    {
        public static Texture2D TileMap;
        public static Texture2D Pacman;
        public static Texture2D Pacwoman;
        public static Texture2D Berry;
        public static Texture2D hitBox;

        //Decorational Objects

        public static Texture2D Sofa;
        public static Texture2D Lamp;
        public static Texture2D Bed;


        public static void LoadTextures(ContentManager content)
        {
            TileMap = content.Load<Texture2D>("PacmanPath");
            Pacman = content.Load<Texture2D>("PacmanSpriteSheet");
            Pacwoman = content.Load<Texture2D>("PacmanWifeSheet");
            Berry = content.Load<Texture2D>("Alkohol");
            hitBox = content.Load<Texture2D>("hitBox");

            //Decorational Objects

            Sofa = content.Load<Texture2D>("Sofa");
            Lamp = content.Load<Texture2D>("Lamp");
            Bed = content.Load<Texture2D>("DubbleBed");
        }
    }
}
