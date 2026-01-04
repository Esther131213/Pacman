using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;

namespace Project1 // Download editor: dotnet tool install --global dotnet-mgcb-editor
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        TileManager tileManager;

        Player player;

        Ghost wife;

        int berryAmount;

        bool touchingWife = false;

        int scoresToGet;

        int tileSize = 32;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1312;
            graphics.PreferredBackBufferHeight = 672;
            IsMouseVisible = true;
        }

        enum GameStates
        {
            Playing,
            Won,
            Lost
        }
        GameStates gameState = GameStates.Playing;

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureHandler.LoadTextures(Content);

            player = new Player(new Vector2(tileSize, tileSize));
            wife = new Ghost(new Vector2(tileSize * 21, tileSize * 15));
            tileManager = new TileManager();
            tileManager.LoadTileMap("tilemap.txt", TextureHandler.TileMap);

            berryAmount = tileManager.berryList.Count;

            scoresToGet = (berryAmount * 15) - 15;
        }

        public static bool GetTileAtPosition(Vector2 vec)
        {
            return TileManager.tiles[(int)vec.X / 32, (int)vec.Y / 32].isWalkable;
        }
        public static bool GetTileAtPosition_Ghost(Vector2 vec)
        {
            return TileManager.tiles[(int)vec.X / 32, (int)vec.Y / 32].ghostWalkable;
        }

        protected override void Update(GameTime gameTime)
        {
            Window.Title = "Lives: " + player.PlayerHealth + "    Score: " + player.playerScore + " / " + scoresToGet +"    You have drank: " + (player.playerScore / 15) + " bottles!" ;

            if (player.PlayerHealth <= 0)
            {
                gameState = GameStates.Lost;
            }

            if (player.playerScore == scoresToGet)
            {
                gameState = GameStates.Won;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gameState == GameStates.Playing)
            {
                player.Update(gameTime);
                wife.Update(gameTime);

                foreach (Berry b in tileManager.berryList)
                {
                    if (player.hitbox.Intersects(b.hitbox))
                    {
                        b.pos.X = 50000;
                        b.hitbox.X = 40000;
                        player.playerScore += b.pointAmount;
                    }
                }

                if (player.hitbox.Intersects(wife.hitbox) && touchingWife == false)
                {
                    player.PlayerHealth--;
                    touchingWife = true;
                }
                else if (!player.hitbox.Intersects(wife.hitbox))
                {
                    touchingWife = false;
                }
            }
            else if (gameState == GameStates.Won)
            {

            }
            else if (gameState == GameStates.Lost)
            {

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointWrap, null, null);

            if (gameState == GameStates.Playing)
            {
                tileManager.Draw(spriteBatch);
                spriteBatch.Draw(TextureHandler.Sofa, new Vector2(tileSize * 22, tileSize * 13), Color.White); //Decoration
                spriteBatch.Draw(TextureHandler.Lamp, new Vector2(tileSize * 22.8f, tileSize * 12.9f), Color.White); //Decoration
                spriteBatch.Draw(TextureHandler.Bed, new Vector2(tileSize * 18.3f, tileSize * 15), Color.White); //Decoration
                player.Draw(spriteBatch);
                wife.Draw(spriteBatch);
            }
            else if (gameState == GameStates.Won)
            {

            }
            else if (gameState == GameStates.Lost)
            {

            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
