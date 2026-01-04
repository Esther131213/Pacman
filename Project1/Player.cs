using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{

    public class Player
    {
        TileManager tileManager;
        Animator animator;
        Vector2 pos;
        Vector2 destination;
        Vector2 direction;
        float speed = 125.0f;
        bool moving = false;
        int hitBoxOffset = 10;
        public int playerScore = -15;
        public int PlayerHealth = 3;

        public Rectangle hitbox;
        int hitBoxSize = 3;

        public Player(Vector2 pos)
        {
            this.pos = pos;
            animator = new Animator(TextureHandler.Pacman, new int[]{15, 15}, pos);
            hitbox.Width = TextureHandler.Pacman.Width / (hitBoxSize * 2);
            hitbox.Height = TextureHandler.Pacman.Height / hitBoxSize;
        }

        public void ChangeDirection(Vector2 dir)
        {
            direction = dir;
            Vector2 newDestination = pos + dir * 32f;

            if (Game1.GetTileAtPosition(newDestination))
            {
                destination = newDestination;
                moving = true;
            }
        }

        enum WalkState
        {
            notWalking, 
            Left,
            Right,
            Up,
            Down
        }
        WalkState walkstate = WalkState.notWalking;

        public void Update(GameTime gameTime)
        {
            hitbox.X = (int)pos.X + hitBoxOffset;
            hitbox.Y = (int)pos.Y + hitBoxOffset;

            if (!moving)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left)/* || walkstate == WalkState.Left*/)
                {
                    walkstate = WalkState.Left;
                    ChangeDirection(new Vector2(-1, 0));
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right)/* || walkstate == WalkState.Right*/)
                {
                    walkstate = WalkState.Right;
                    ChangeDirection(new Vector2(1, 0));
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Up)/* || walkstate == WalkState.Up*/)
                {
                    walkstate = WalkState.Up;
                    ChangeDirection(new Vector2(0, -1));
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Down)/* || walkstate == WalkState.Down*/)
                {
                    walkstate = WalkState.Down;
                    ChangeDirection(new Vector2(0, 1));
                }
            }
            else
            {
                pos += direction * speed * 
                    (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (Vector2.Distance(pos, destination) < 1)
                {
                    pos = destination;
                    moving = false;
                }
            }

            animator.Update(pos + new Vector2(TextureHandler.Pacman.Width / 4, TextureHandler.Pacman.Height / 2));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float rotation = 0;
            if (walkstate == WalkState.Down)
            {
                rotation = MathF.PI * 0.5f;
            }
            else if (walkstate == WalkState.Left)
            {
                rotation = MathF.PI;
            }
            else if (walkstate == WalkState.Up)
            {
                rotation = MathF.PI * 1.5f;
            }

            animator.Draw(spriteBatch, rotation);
            //spriteBatch.Draw(TextureHandler.hitBox, new Vector2(hitbox.X, hitbox.Y), hitbox, Color.Green);
        }
    }
}
