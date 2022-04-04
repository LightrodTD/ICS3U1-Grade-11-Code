//Author: Mehdi Syed
//Project Name: MonogameA2
//File Name: Game1.cs
//Creation Date: ‎‎Nov. ‎01, ‎2019
//Modified Date: Nov. 20, 2019
//Description: This program is for an endless runner. 
//             A game where the player is the character, and he/she must try to avoid the obstacles.
//             If the player does, he/ she essentially must restart. The only other goal is to get the hieghest score.

using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Animation2D;

namespace MonogameA2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //Score Counter
        float count = 1f; //every  2s.
        float timer = 1f;

        //Game states
        const int Menu = 0;
        const int Instructions = 1;
        const int Play = 2;
        const int Dead = 3;
        int GAMESTATE = Menu;

        //Player State & Jumping Variables
        const int run = 0;
        const int jump = 1;
        const int slide = 2;
        int playerState = run;
        double jumpSpeed = 0;

        //Background Image
        Texture2D bGround;
        Rectangle bGroundPos1;
        Rectangle bGroundPos2;
        Rectangle bGroundPosGameOver;

        //Screen Dimensions / Data
        int screenWidth = 800;
        int screenHeight = 480;
        float xValue = 10f;
        float yValue = 300f;

        //Keyboard State
        KeyboardState kb;

        //Background Speed
        int speed = 6;

        //Scor
        SpriteFont Font;
        double score = 0;
        Vector2 scorePos;
        string x;

        //Animation
        //Run Animation
        Texture2D runAnimationImg;
        Animation runAnimation;
        Vector2 runAnimationLoc;
        Rectangle runAnimationPos;

        //Roll or slide Animation
        Texture2D rollAnimationImg;
        Animation rollAnimation;
        Vector2 rollAnimationLoc;
        Rectangle rollAnimationPos;

        //Jump Animation
        Texture2D jumpAnimationImg;
        Animation jumpAnimation;
        Vector2 jumpAnimationLoc;
        Rectangle jumpAnimationPos;

        //Obstacle
        //Stump
        Texture2D stump;
        Rectangle[] stumpLoc = new Rectangle[4];

        //Bullet
        Texture2D bullet;
        Rectangle[] bulletLoc = new Rectangle[3];

        //Random Variable
        Random rng = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //Background
            bGround = Content.Load<Texture2D>("Images/Background/BACKGROUND");
            bGroundPos1 = new Rectangle(0, 0, screenWidth, screenHeight);
            bGroundPos2 = new Rectangle(screenWidth, 0, screenWidth, screenHeight);
            bGroundPosGameOver = new Rectangle(0, 0, screenWidth, screenHeight);
            //Score
            Font = Content.Load<SpriteFont>("Fonts/ScoreFonts");
            scorePos = new Vector2(0, 0);

            //Animation
            //Running
            runAnimationImg = Content.Load<Texture2D>("Images/Sprites/OrignalSprite_Run_Final");
            runAnimationLoc = new Vector2(xValue, yValue);
            runAnimation = new Animation(runAnimationImg,
                                         6,
                                         1,
                                         6,
                                         0,
                                         0,
                                         Animation.ANIMATE_FOREVER,
                                         2,
                                         runAnimationLoc,
                                         (1f),
                                         true);
            //Sliding 
            rollAnimationImg = Content.Load<Texture2D>("Images/Sprites/slidingAnimationFinal");
            rollAnimationLoc = new Vector2(xValue, 350f);
            rollAnimation = new Animation(rollAnimationImg,
                                         4,
                                         1,
                                         4,
                                         0,
                                         0,
                                         Animation.ANIMATE_FOREVER,
                                         1,
                                         rollAnimationLoc,
                                         (1f),
                                         false);
            //Jump Animation
            jumpAnimationImg = Content.Load<Texture2D>("Images/Sprites/OrignalSprite_JetpackJump_Final");
            jumpAnimationLoc = new Vector2(xValue, yValue);
            jumpAnimation = new Animation(jumpAnimationImg,
                                         5,
                                         1,
                                         5,
                                         0,
                                         0,
                                         Animation.ANIMATE_FOREVER,
                                         2,
                                         jumpAnimationLoc,
                                         (1f),
                                         false);

            //Obstacle
            //Stump
            stump = Content.Load<Texture2D>("Images/Sprites/stumpObstacleFinal3");
            stumpLoc[1] = new Rectangle(-112, (int)yValue, 112, 111);
            stumpLoc[2] = new Rectangle(-112, (int)yValue, 112, 111);
            stumpLoc[3] = new Rectangle(-112, (int)yValue, 112, 111);

            //Bullet
            bullet = Content.Load<Texture2D>("Images/Sprites/bulletObstacle");
            bulletLoc[0] = new Rectangle(-100, (int)yValue - 20, 90, 50);
            bulletLoc[1] = new Rectangle(-100, (int)yValue - 70, 90, 50);
            bulletLoc[2] = new Rectangle(-20, (int)yValue, 90, 50);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            runAnimation.Update(gameTime);
           

            kb = Keyboard.GetState();
            // TODO: Add your update logic here
            switch (GAMESTATE)
            {
                case Menu:
                    UpdateMenu();
                    break;
                case Instructions:
                    break;
                case Play:
                    UpdateGame(gameTime);
                    break;
                case Dead:
                    break;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            //Game States
            switch (GAMESTATE)
            {
                case Menu:
                    DrawMenu();
                    break;
                case Instructions:
                    DrawInstructions();
                    break;
                case Play:
                    DrawGame(gameTime);
                    break;
                case Dead:
                    DrawDeadScreen();
                    break;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateMenu()
        {
            //Modify game state based on user choice, exit on 4 key
            if (kb.IsKeyDown(Keys.NumPad1))
            {
                GAMESTATE = Instructions;
            }
            else if (kb.IsKeyDown(Keys.NumPad2))
            {
                GAMESTATE = Play;
            }
            else if (kb.IsKeyDown(Keys.NumPad3))
            {
                Exit();
            }
        }

        private void UpdateGame(GameTime gameTime)
        {
            //Score/ Score Logic
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds; //Time passed since last Update() 

            if (timer >= count)
            {
                score++;
                timer -= count; 
            }
            x = Convert.ToString(score);

            //Move background to the left by speed
            bGroundPos1.X -= speed;
            bGroundPos2.X -= speed;

            //Check for either background image to be offscreen and shift right
            if (bGroundPos1.X <= -screenWidth)
            {
                bGroundPos1.X += 2 * screenWidth;
            }
            else if (bGroundPos2.X <= -screenWidth)
            {
                bGroundPos2.X += 2 * screenWidth;
            }

            //Switching PLayerState
            switch (playerState)
            {
                //Running
                case run:
                    if (kb.IsKeyDown(Keys.Space))
                    {
                        playerState = jump;
                        jumpSpeed = 12;
                    }
                    if (kb.IsKeyDown(Keys.Down))
                    {
                        playerState = slide;
                    }
                    //Run Collision
                    if (runAnimation.destRec.Intersects(bulletLoc[0]))
                        GAMESTATE = Dead;
                    if (runAnimation.destRec.Intersects(stumpLoc[1]))
                        GAMESTATE = Dead;
                    if (runAnimation.destRec.Intersects(stumpLoc[2]))
                        GAMESTATE = Dead;
                    if (runAnimation.destRec.Intersects(stumpLoc[3]))
                        GAMESTATE = Dead;
                    break;
                //Jumping
                case jump:
                    jumpAnimation.isAnimating = true;
                    jumpAnimation.destRec.Y -= (int)jumpSpeed;
                    jumpSpeed -= 0.5;
                    if (jumpAnimation.destRec.Intersects(bulletLoc[0]))
                        GAMESTATE = Dead;
                    if (jumpAnimation.destRec.Y >= 270f)
                    {
                        jumpAnimation.destRec.Y = (int)270f;
                        playerState = run;
                    }
                    break;
                //Sliding
                case slide:
                    rollAnimation.isAnimating = true;
                    speed = 5;
                    if (rollAnimation.destRec.Intersects(bulletLoc[0]))
                        GAMESTATE = Dead;
                    if (rollAnimation.destRec.Intersects(stumpLoc[1]))
                        GAMESTATE = Dead;
                    if (rollAnimation.destRec.Intersects(stumpLoc[2]))
                        GAMESTATE = Dead;
                    if (rollAnimation.destRec.Intersects(stumpLoc[3]))
                        GAMESTATE = Dead;
                    if (kb.IsKeyUp(Keys.Down))
                    {
                        playerState = run;
                        speed = 6;
                    }
                    break;
            }

            //Obstacle Logic
            stumpLoc[1].X -= speed;
            stumpLoc[2].X -= speed;
            stumpLoc[3].X -= speed;
            bulletLoc[0].X -= 2 * speed;

            //Stump Spawning
            //Stump 1
            if (stumpLoc[1].X <= -stumpLoc[1].Width)
            {
                stumpLoc[1].X = rng.Next(screenWidth, screenWidth + 100);
            }
            //Stump 2
            if (stumpLoc[2].X <= -stumpLoc[2].Width)
            {
                stumpLoc[2].X = rng.Next(screenWidth + 101, screenWidth + 250);
            }
            //Stump 3
            if (stumpLoc[3].X <= -stumpLoc[3].Width)
            {
                stumpLoc[3].X = rng.Next(screenWidth + 260, screenWidth + 300);
            }
            //Does not let Stump 1 and 3 collide
            if (stumpLoc[1].Width == stumpLoc[3].Width)
            {
                stumpLoc[3].X = rng.Next(screenWidth + 260, screenWidth + 300);
            }
            //Does not let Stump 2 and 3 collide
            if (stumpLoc[2].Width == stumpLoc[3].Width)
            {
                stumpLoc[2].X = rng.Next(screenWidth + 101, screenWidth + 250);
            }

            //Bullet Spawning
            if (bulletLoc[0].X <= -bulletLoc[0].Width)
            {
                bulletLoc[0].X = rng.Next(screenWidth, screenWidth + 100);
            }
        }
        
        private void DrawMenu()
        {
            //Background
            spriteBatch.Draw(bGround, bGroundPosGameOver, Color.White);
            //Title
            spriteBatch.DrawString(Font, "RUN BOY, RUN!!!", new Vector2(320, 50), Color.Black);

            //Draw GameStates
            spriteBatch.DrawString(Font, "MENU", new Vector2(360, 90), Color.Black);
            spriteBatch.DrawString(Font, "1. Instructions", new Vector2(320, 110), Color.Black);
            spriteBatch.DrawString(Font, "2. Play", new Vector2(320, 130), Color.Black);
            spriteBatch.DrawString(Font, "3. Exit", new Vector2(320, 150), Color.Black);

            //Creator
            spriteBatch.DrawString(Font, "Created by Mehdi Syed", new Vector2(300, 390), Color.Black);
        }

        private void DrawInstructions()
        {
            //Draw Instructions
            spriteBatch.DrawString(Font, "These are the instructions for this game:", new Vector2(300, 50), Color.Black);
            spriteBatch.DrawString(Font, "To jump, press the  space key", new Vector2(300, 70), Color.Black);
            spriteBatch.DrawString(Font, "To slide, press the down key", new Vector2(300, 90), Color.Black);
            spriteBatch.DrawString(Font, "Press Delete to return to Menu", new Vector2(300, 110), Color.Black);

            //Return to Menu
            if (kb.IsKeyDown(Keys.Delete))
            {
                GAMESTATE = Menu;
            }
        }


        private void DrawGame(GameTime gameTime)
        {
            //Background Image
            spriteBatch.Draw(bGround, bGroundPos1, Color.White);
            spriteBatch.Draw(bGround, bGroundPos2, Color.White);

            //Score
            spriteBatch.DrawString(Font, "Score: " + x, scorePos, Color.Black);

            //Animation
            switch (playerState)
            {
                case run:
                    runAnimation.Draw(spriteBatch, Color.White, SpriteEffects.None);
                    break;
                case jump:
                    jumpAnimation.Draw(spriteBatch, Color.White, SpriteEffects.None);
                    break;
                case slide:
                    rollAnimation.Draw(spriteBatch, Color.White, SpriteEffects.None);
                    break;
            }

            //Stump
            spriteBatch.Draw(stump, stumpLoc[1], Color.White);
            spriteBatch.Draw(stump, stumpLoc[2], Color.White);
            spriteBatch.Draw(stump, stumpLoc[3], Color.White);

            //Bullet
            spriteBatch.Draw(bullet, bulletLoc[0], Color.White);
        }

        private void DrawDeadScreen()
        {
            spriteBatch.Draw(bGround, bGroundPosGameOver, Color.White);
            spriteBatch.DrawString(Font, "YOU LOSE", new Vector2(350, 200), Color.Black);
            spriteBatch.DrawString(Font, "Better Luck Next Time!", new Vector2(310, 360), Color.Black);
            spriteBatch.DrawString(Font, "Press Delete to go back to the Menu", new Vector2(270, 390), Color.Black);
            if (kb.IsKeyDown(Keys.Delete))
            {
                GAMESTATE = Menu;
                score = 0;
                playerState = run;
                bulletLoc[0].X = -100;
                stumpLoc[1].X = -112;
                stumpLoc[2].X = -112;
                stumpLoc[3].X = -112;
                bGroundPos1.X = 0;
                bGroundPos2.X = screenWidth;
            }
        }
    }
}
