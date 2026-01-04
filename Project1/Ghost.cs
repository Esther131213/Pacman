using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    public class Ghost
    {
        TileManager tileManager;
        Animator animator;
        Vector2 pos;
        Vector2 destination;
        Vector2 direction;
        float speed = 125.0f;
        bool moving = false;
        int hitBoxOffset = 10;
        public int playerScore = -10;

        Random rnd = new Random();
        int timer = 5000;

        public Rectangle hitbox;
        int hitBoxSize = 3;

        public Ghost(Vector2 pos)
        {
            this.pos = pos;
            animator = new Animator(TextureHandler.Pacwoman, new int[] { 15, 15 }, pos);
            hitbox.Width = TextureHandler.Pacwoman.Width / (hitBoxSize * 2);
            hitbox.Height = TextureHandler.Pacwoman.Height / hitBoxSize;
        }

        enum WalkState
        {
            notWalking,
            Left,
            Right,
            Up,
            Down
        }
        WalkState walkstate = WalkState.Up;

        public void Update(GameTime gameTime)
        {
            hitbox.X = (int)pos.X + hitBoxOffset;
            hitbox.Y = (int)pos.Y + hitBoxOffset;

            animator.Update(pos + new Vector2(TextureHandler.Pacwoman.Width / 4, TextureHandler.Pacwoman.Height / 2));

            if (!moving)
            {
                while (timer > 0)
                {
                    timer--;
                }

                if (timer <= 0)
                {
                    int random = rnd.Next(1,5);

                    switch (random)
                    {
                        case 1:
                            walkstate = WalkState.Left;
                            break;
                        case 2:
                            walkstate = WalkState.Right;
                            break;
                        case 3:
                            walkstate = WalkState.Up;
                            break;
                        case 4:
                            walkstate = WalkState.Down;
                            break;
                    }

                    timer = 5000;
                }

                if (walkstate == WalkState.Left)
                {
                    ChangeDirection(new Vector2(-1, 0));
                }
                else if (walkstate == WalkState.Right)
                {
                    ChangeDirection(new Vector2(1, 0));
                }
                else if (walkstate == WalkState.Up)
                {
                    ChangeDirection(new Vector2(0, -1));
                }
                else if (walkstate == WalkState.Down)
                {
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
        }

        public void ChangeDirection(Vector2 dir)
        {
            direction = dir;
            Vector2 newDestination = pos + dir * 32f;

            if (Game1.GetTileAtPosition_Ghost(newDestination))
            {
                destination = newDestination;
                moving = true;
            }
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
        }
    }
}
