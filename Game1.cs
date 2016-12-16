using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Cyberbox
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Brick> bricks = new List<Brick>();
        List<Green> greens = new List<Green>();
        List<Yellow> yellows = new List<Yellow>();
        List<Blue> blues = new List<Blue>();
        List<LeftMover> leftmovers = new List<LeftMover>();
        List<RightMover> rightmovers = new List<RightMover>();
        List<DownMover> downmovers = new List<DownMover>();
        SpriteFont spriteFont;
        Texture2D circle, brick, green, yellow, blue, downmover, rightmover, leftmover;
        Circle player;

        public class LeftMover : Shape
        {
        }

        public class DownMover : Shape
        {
        }

        public class RightMover : Shape
        {
        }

        public class Green : Shape
        {
        }

        public class Yellow : Shape
        {
        }

        public class Blue : Shape
        {
        }

        public class Shape
        {
            public int X, Y;
            public Vector2 vector = new Vector2(0, 0);
        }

        public class Circle
        {
            public int X, Y;
            public int prevX, prevY;
            public Vector2 vector = new Vector2(0, 0);
        }

        public class Brick
        {
            public int X, Y;
            public Vector2 vector = new Vector2(0, 0);
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 450;
            graphics.PreferredBackBufferHeight = 300;
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
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
            circle = Content.Load<Texture2D>("circle");
            brick = Content.Load<Texture2D>("brick");
            green = Content.Load<Texture2D>("green");
            yellow = Content.Load<Texture2D>("yellow");
            blue = Content.Load<Texture2D>("blue");
            rightmover = Content.Load<Texture2D>("rightmover");
            leftmover = Content.Load<Texture2D>("leftmover");
            downmover = Content.Load<Texture2D>("downmover");
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");

            timer.Interval = 800;
            timer.Tick += new EventHandler(HeCan);
            timer.Start();
        }

        public void HeCan(object sender, EventArgs e)
        {
            hecan = true;
        }

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public void Level1()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();

            player = new Circle();
            player.prevX = 7;
            player.prevY = 9;
            player.X = 7;
            player.Y = 9;
            player.vector.X = player.X * 30;
            player.vector.Y = player.Y * 30;

            AddBrick(4, 0);
            AddBrick(10, 0);
            AddBlue(5, 1);
            AddYellow(6, 1);
            AddBlue(7, 1);
            AddYellow(8, 1);
            AddBlue(9, 1);
            AddYellow(0, 2);
            AddGreen(6, 2);
            AddGreen(8, 2);
            AddYellow(14, 2);
            AddYellow(0, 3);
            AddBrick(2, 3);
            AddBrick(5, 3);
            AddYellow(7, 3);
            AddBrick(9, 3);
            AddBrick(12, 3);
            AddYellow(14, 3);
            AddBrick(1, 5);
            AddBrick(3, 5);
            AddBlue(5, 5);
            AddGreen(7, 5);
            AddBlue(9, 5);
            AddBrick(11, 5);
            AddBrick(13, 5);
            AddYellow(0, 7);
            AddBrick(2, 7);
            AddBrick(5, 7);
            AddYellow(7, 7);
            AddBrick(9, 7);
            AddBrick(12, 7);
            AddYellow(14, 7);
            AddBlue(4, 9);
            AddBlue(5, 9);
            AddBlue(9, 9);
            AddBlue(10, 9);
        }

        public void Level2()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();

            AddBrick(4, 0);
            AddBrick(9, 0);
            AddBrick(10, 0);
            AddBrick(4, 1);
            AddBrick(5, 1);
            AddBrick(10, 1);
            AddBlue(2, 2);
            AddBlue(3, 2);
            AddBlue(4, 2);
            AddBlue(5, 2);
            AddBlue(6, 2);
            AddYellow(7, 2);
            AddBlue(8, 2);
            AddBlue(9, 2);
            AddBlue(10, 2);
            AddBrick(13, 2);
            AddYellow(14, 2);
            AddBrick(2, 3);
            AddGreen(7, 3);
            AddYellow(8, 3);
            AddBrick(11, 3);
            AddBrick(12, 3);
            AddBrick(13, 3);
            AddYellow(14, 3);
            AddYellow(0, 4);
            AddBlue(2, 4);
            AddGreen(8, 4);
            AddYellow(14, 4);
            AddYellow(0, 5);
            AddGreen(1, 5);
            AddBrick(3, 5);
            AddBrick(4, 5);
            AddBrick(11, 5);
            AddYellow(0, 6);
            AddBrick(1, 6);
            AddBrick(2, 6);
            AddBrick(5, 6);
            AddBrick(6, 6);
            AddBrick(7, 6);
            AddBrick(8, 6);
            AddBrick(13, 6);
            AddYellow(0, 7);
            AddYellow(3, 7);
            AddBrick(6, 7);
            AddBrick(7, 7);
            AddBrick(8, 7);
            AddBrick(11, 7);
            AddBlue(13, 7);
            AddYellow(0, 8);
            AddBrick(2, 8);
            AddGreen(4, 8);
            AddYellow(5, 8);
            AddBrick(8, 8);
            AddBlue(11, 8);
            AddYellow(12, 8);
            AddBrick(13, 8);
            AddBrick(2, 9);
            AddBrick(4, 9);
            AddBlue(8, 9);
            AddBrick(11, 9);
            AddBlue(13, 9);

            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * 30;
        }

        public void Level3()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();

            AddBrick(0, 0);
            AddBrick(3, 0);
            AddBrick(6, 0);
            AddBrick(11, 0);
            AddYellow(2, 1);
            AddBrick(3, 1);
            AddBrick(5, 1);
            AddYellow(9, 1);
            AddYellow(10, 1);
            AddBrick(13, 1);
            AddYellow(1, 2);
            AddGreen(2, 2);
            AddBrick(3, 2);
            AddBrick(4, 2);
            AddBrick(5, 2);
            AddBrick(6, 2);
            AddBrick(7, 2);
            AddBrick(8, 2);
            AddGreen(9, 2);
            AddGreen(10, 2);
            AddBrick(11, 2);
            AddBrick(12, 2);
            AddYellow(2, 3);
            AddBlue(5, 3);
            AddYellow(9, 3);
            AddBrick(13, 3);
            AddBrick(1, 4);
            AddBrick(7, 4);
            AddBrick(8, 4);
            AddGreen(9, 4);
            AddBrick(10, 4);
            AddBrick(12, 4);
            AddBrick(2, 5);
            AddBrick(3, 5);
            AddBrick(4, 5);
            AddBrick(5, 5);
            AddBrick(8, 5);
            AddYellow(9, 5);
            AddBlue(12, 5);
            AddBlue(13, 5);
            AddBrick(1, 6);
            AddBrick(6, 6);
            AddBrick(8, 6);
            AddYellow(9, 6);
            AddBrick(10, 6);
            AddBlue(12, 6);
            AddBlue(13, 6);
            AddBrick(2, 7);
            AddGreen(3, 7);
            AddGreen(4, 7);
            AddGreen(6, 7);
            AddRM(10, 7);
            AddYellow(11, 7);
            AddBrick(12, 7);
            AddYellow(3, 8);
            AddYellow(4, 8);
            AddBrick(7, 8);
            AddBrick(10, 8);
            AddGreen(12, 8);
            AddBrick(2, 9);
            AddBrick(5, 9);
            AddBrick(8, 9);
            AddBrick(10, 9);
            AddGreen(12, 9);
            AddBrick(14, 9);

            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * 30;
        }

        public void Level4()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();

            AddGreen(6, 0);
            AddBlue(7, 0);
            AddGreen(8, 0);
            AddGreen(9, 0);
            AddGreen(10, 0);
            AddGreen(11, 0);
            AddGreen(12, 0);
            AddDM(13, 0);
            AddBrick(4, 1);
            AddBrick(9, 1);
            AddBrick(11, 1);
            AddBlue(13, 1);
            AddYellow(14, 1);
            AddBrick(2, 2);
            AddBrick(3, 2);
            AddBrick(5, 2);
            AddBrick(6, 2);
            AddBrick(7, 2);
            AddBlue(11, 2);
            AddBrick(1, 3);
            AddBrick(8, 3);
            AddBrick(9, 3);
            AddBrick(10, 3);
            AddBrick(11, 3);
            AddBrick(13, 3);
            AddYellow(14, 3);
            AddBrick(1, 4);
            AddBlue(3, 4);
            AddBrick(5, 4);
            AddBrick(6, 4);
            AddBlue(8, 4);
            AddBrick(13, 4);
            AddBrick(1, 5);
            AddBrick(3, 5);
            AddYellow(4, 5);
            AddBrick(7, 5);
            AddBlue(9, 5);
            AddBrick(12, 5);
            AddYellow(0, 6);
            AddBrick(1, 6);
            AddBrick(3, 6);
            AddYellow(4, 6);
            AddBrick(5, 6);
            AddBrick(8, 6);
            AddBrick(9, 6);
            AddBrick(10, 6);
            AddBrick(11, 6);
            AddGreen(13, 6);
            AddYellow(0, 7);
            AddLM(1, 7);
            AddYellow(2, 7);
            AddLM(3, 7);
            AddYellow(4, 7);
            AddLM(5, 7);
            AddBlue(7, 7);
            AddBlue(8, 7);
            AddBlue(9, 7);
            AddBlue(10, 7);
            AddBrick(1, 8);
            AddBrick(3, 8);
            AddBrick(5, 8);
            AddBrick(6, 8);
            AddBrick(7, 8);
            AddBrick(8, 8);
            AddBrick(8, 9);
            AddBlue(10, 9);
            AddBlue(11, 9);
            AddBlue(12, 9);
            AddBlue(13, 9);

            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * 30;
        }

        private void AddLM(int x, int y)
        {
            LeftMover lm = new LeftMover();
            lm.vector.X = (lm.X = x) * 30;
            lm.vector.Y = (lm.Y = y) * 30;
            leftmovers.Add(lm);
        }

        private void AddRM(int x, int y)
        {
            RightMover rm = new RightMover();
            rm.vector.X = (rm.X = x) * 30;
            rm.vector.Y = (rm.Y = y) * 30;
            rightmovers.Add(rm);
        }

        private void AddDM(int x, int y)
        {
            DownMover dm = new DownMover();
            dm.vector.X = (dm.X = x) * 30;
            dm.vector.Y = (dm.Y = y) * 30;
            downmovers.Add(dm);
        }

        private void AddBrick(int x, int y)
        {
            Brick brick = new Brick();
            brick.vector.X = (brick.X = x) * 30;
            brick.vector.Y = (brick.Y = y) * 30;
            bricks.Add(brick);
        }

        private void AddGreen(int x, int y)
        {
            Green green = new Green();
            green.vector.X = (green.X = x) * 30;
            green.vector.Y = (green.Y = y) * 30;
            greens.Add(green);
        }

        private void AddYellow(int x, int y)
        {
            Yellow yellow = new Yellow();
            yellow.vector.X = (yellow.X = x) * 30;
            yellow.vector.Y = (yellow.Y = y) * 30;
            yellows.Add(yellow);
        }

        private void AddBlue(int x, int y)
        {
            Blue blue = new Blue();
            blue.vector.X = (blue.X = x) * 30;
            blue.vector.Y = (blue.Y = y) * 30;
            blues.Add(blue);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        int currentLevel = 0;

        bool drawwin = false;

        bool hecan = false;

        bool loadlevel = true;

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (currentLevel == 0 && loadlevel == true)
            {
                currentLevel = 1;
                Level1();
                loadlevel = false;
            }
            else if (currentLevel == 2 && loadlevel == true)
            {
                Level2();
                loadlevel = false;
            }
            else if (currentLevel == 3 && loadlevel == true)
            {
                Level3();
                loadlevel = false;
            }
            else if (currentLevel == 4 && loadlevel == true)
            {
                Level4();
                loadlevel = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                bool cnt = false;
                for (int i = 0; i < blues.Count; i++)
                {
                    if (blues[i].X == player.X && blues[i].Y == player.Y - 1)
                    {
                        cnt = true;
                    }
                }
                bool ispushed = false;
                bool stuck = false;
                for (int i = 0; i < greens.Count; i++)
                {
                    if (greens[i].X == player.X && greens[i].Y == player.Y)
                    {
                        ispushed = pushGreen(greens[i], 0, -1);
                        if (ispushed)
                        {
                            if(greens[i].Y > 0)
                                greens[i].Y -= 1;
                            greens[i].vector.Y = greens[i].Y * 30;
                            must = true;
                        }
                        else
                        {
                            player.prevX = player.X;
                            player.prevY = player.Y;
                            player.Y++;
                            player.vector.Y += 30;
                            stuck = true;
                        }
                    }
                }
                for (int i = 0; i < yellows.Count; i++)
                {
                    if (yellows[i].X == player.X && yellows[i].Y == player.Y)
                    {
                        ispushed = pushYellow(yellows[i], -1);
                        if (ispushed)
                        {
                            if(yellows[i].Y > 0)
                                yellows[i].Y -= 1;
                            yellows[i].vector.Y = yellows[i].Y * 30;
                            must = true;
                        }
                        else
                        {
                            player.prevX = player.X;
                            player.prevY = player.Y;
                            player.Y++;
                            player.vector.Y += 30;
                            stuck = true;
                        }
                    }
                }
                bool cant = false;
                for (int i = 0; i < bricks.Count; i++)
                {
                    if (bricks[i].X == player.X && bricks[i].Y == player.Y - 1)
                    {
                        cant = true;
                    }
                }
                if (!cant && !cnt)
                {
                    if (hecan)
                    {
                        if (!stuck)
                        {
                            hecan = false;
                            player.prevX = player.X;
                            player.prevY = player.Y;
                            player.Y--;
                            player.vector.Y -= 30;
                        }
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                bool ispushed = false;
                bool stuck = false;
                bool cnt = false;
                for (int i = 0; i < blues.Count; i++)
                {
                    if (blues[i].X == player.X && blues[i].Y == player.Y + 1)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < greens.Count; i++)
                {
                    if (greens[i].X == player.X && greens[i].Y == player.Y)
                    {
                        ispushed = pushGreen(greens[i], 0, 1);
                        if (ispushed)
                        {
                            if(greens[i].Y < 9)
                                greens[i].Y += 1;
                            greens[i].vector.Y = greens[i].Y * 30;
                            must = true;
                        }
                        else
                        {
                            player.prevX = player.X;
                            player.prevY = player.Y;
                            player.Y--;
                            player.vector.Y -= 30;
                            stuck = true;
                        }
                    }
                }
                for (int i = 0; i < yellows.Count; i++)
                {
                    if (yellows[i].X == player.X && yellows[i].Y == player.Y)
                    {
                        ispushed = pushYellow(yellows[i], 1);
                        if (ispushed)
                        {
                            if(yellows[i].Y < 9)
                                yellows[i].Y += 1;
                            yellows[i].vector.Y = yellows[i].Y * 30;
                            must = true;
                        }
                        else
                        {
                            player.prevX = player.X;
                            player.prevY = player.Y;
                            player.Y--;
                            player.vector.Y -= 30;
                            stuck = true;
                        }
                    }
                }
                bool cant = false;
                for (int i = 0; i < bricks.Count; i++)
                {
                    if (bricks[i].X == player.X && bricks[i].Y == player.Y + 1)
                    {
                        cant = true;
                    }
                }
                if (!cant && !cnt)
                {
                    if (hecan)
                    {
                        if (!stuck)
                        {
                            hecan = false;
                            player.prevX = player.X;
                            player.prevY = player.Y;
                            player.Y++;
                            player.vector.Y += 30;
                        }
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                bool ispushed = false;
                bool stuck = false;
                bool cnt = false;
                for (int i = 0; i < yellows.Count; i++)
                {
                    if (yellows[i].X == player.X - 1 && yellows[i].Y == player.Y)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < greens.Count; i++)
                {
                    if (greens[i].X == player.X && greens[i].Y == player.Y)
                    {
                        ispushed = pushGreen(greens[i], -1, 0);
                        if (ispushed)
                        {
                            if(greens[i].X > 0)
                                greens[i].X -= 1;
                            greens[i].vector.X = greens[i].X * 30;
                            must = true;
                        }
                        else
                        {
                            player.prevX = player.X;
                            player.prevY = player.Y;
                            player.X++;
                            player.vector.X += 30;
                            stuck = true;
                        }
                    }
                }
                for (int i = 0; i < blues.Count; i++)
                {
                    if (blues[i].X == player.X && blues[i].Y == player.Y)
                    {
                        ispushed = pushBlue(blues[i], -1);
                        if (ispushed)
                        {
                            if(blues[i].X > 0)
                                blues[i].X -= 1;
                            blues[i].vector.X = blues[i].X * 30;
                            must = true;
                        }
                        else
                        {
                            player.prevX = player.X;
                            player.prevY = player.Y;
                            player.X++;
                            player.vector.X += 30;
                            stuck = true;
                        }
                    }
                }
                bool cant = false;
                for (int i = 0; i < bricks.Count; i++)
                {
                    if (bricks[i].X == player.X - 1 && bricks[i].Y == player.Y)
                    {
                        cant = true;
                    }
                }
                if (!cant && !cnt)
                {
                    if (hecan)
                    {
                        if (!stuck)
                        {
                            hecan = false;
                            player.prevX = player.X;
                            player.prevY = player.Y;
                            player.X--;
                            player.vector.X -= 30;
                        }
                    }
                }
            }
            if (rightmovers.Count > 0)
            {
                if (player.X == rightmovers[0].X && player.Y == rightmovers[0].Y)
                {
                    player.X--;
                    player.vector.X = player.X * 30;
                }        
                bool ispushe = false;
                bool stuc = false;
                ispushe = pushRM(player, rightmovers[0], 1, 0);
                if (ispushe)
                {
                    if (rightmovers[0].X < 14)
                    {
                        rightmovers[0].X += 1;
                        if (player.X == rightmovers[0].X && player.Y == rightmovers[0].Y)
                        {
                            rightmovers[0].X -= 1;
                        }
                    }
                    rightmovers[0].vector.X = rightmovers[0].X * 30;
                    must = true;
                }
            }
            if (downmovers.Count > 0)
            {
                bool ispushe = false;
                bool stuc = false;
                ispushe = pushDM(player, downmovers[0], 0, 1);
                if (ispushe)
                {
                    if (downmovers[0].Y < 9)
                    {
                        downmovers[0].Y += 1;
                        if (player.X == downmovers[0].X && player.Y == downmovers[0].Y)
                        {
                            downmovers[0].Y -= 1;
                        }
                    }
                    downmovers[0].vector.Y = downmovers[0].Y * 30;
                    must = true;
                }
                ispushe = pushLM(player, leftmovers[0], -1, 0);
                if (ispushe)
                {
                    if (leftmovers[0].X > 0)
                    {
                        leftmovers[0].X -= 1;
                        if (player.X == leftmovers[0].X && player.Y == leftmovers[0].Y)
                        {
                            leftmovers[0].X += 1;
                        }
                    }
                    leftmovers[0].vector.X = leftmovers[0].X * 30;
                    must = true;
                }
                ispushe = pushLM(player, leftmovers[1], -1, 0);
                if (ispushe)
                {
                    if (leftmovers[1].X > 0)
                    {
                        leftmovers[1].X -= 1;
                        if (player.X == leftmovers[1].X && player.Y == leftmovers[1].Y)
                        {
                            leftmovers[1].X += 1;
                        }
                    }
                    leftmovers[1].vector.X = leftmovers[1].X * 30;
                    must = true;
                }
                ispushe = pushLM(player, leftmovers[2], -1, 0);
                if (ispushe)
                {
                    if (leftmovers[2].X > 0)
                    {
                        leftmovers[2].X -= 1;
                        if (player.X == leftmovers[2].X && player.Y == leftmovers[2].Y)
                        {
                            leftmovers[2].X += 1;
                        }
                    }
                    leftmovers[2].vector.X = leftmovers[2].X * 30;
                    must = true;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                bool ispushed = false;
                bool stuck = false;
                bool cnt = false;
                for (int i = 0; i < yellows.Count; i++)
                {
                    if (yellows[i].X == player.X + 1 && yellows[i].Y == player.Y)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < greens.Count; i++)
                {
                    if (greens[i].X == player.X && greens[i].Y == player.Y)
                    {
                        ispushed = pushGreen(greens[i], 1, 0);
                        if (ispushed)
                        {
                            if(greens[i].X < 14)
                                greens[i].X += 1;
                            greens[i].vector.X = greens[i].X * 30;
                            must = true;
                        }
                        else
                        {
                            player.prevX = player.X;
                            player.prevY = player.Y;
                            player.X--;
                            player.vector.X -= 30;
                            stuck = true;
                        }
                    }
                }
                for (int i = 0; i < blues.Count; i++)
                {
                    if (blues[i].X == player.X && blues[i].Y == player.Y)
                    {
                        ispushed = pushBlue(blues[i], 1);
                        if (ispushed)
                        {
                            if(blues[i].X < 14)
                                blues[i].X += 1;
                            blues[i].vector.X = blues[i].X * 30;
                            must = true;
                        }
                        else
                        {
                            player.prevX = player.X;
                            player.prevY = player.Y;
                            player.X--;
                            player.vector.X -= 30;
                            stuck = true;
                        }
                    }
                }
                bool cant = false;
                for (int i = 0; i < bricks.Count; i++)
                {
                    if (bricks[i].X == player.X + 1 && bricks[i].Y == player.Y)
                    {
                        cant = true;
                    }
                }
                if (!cant && !cnt)
                {
                    if (hecan)
                    {
                        if (!stuck)
                        {
                            hecan = false;
                            player.prevX = player.X;
                            player.prevY = player.Y;
                            player.X++;
                            player.vector.X += 30;
                        }
                    }
                }
            }

            if (player.X != 7 && player.Y != -1)
            {
                if (player.X < 0 || player.X > 14 || player.Y < 0 || player.Y > 9)
                {
                    player.X = player.prevX;
                    player.Y = player.prevY;
                    player.vector.X = player.X * 30;
                    player.vector.Y = player.Y * 30;
                }
            }

            if (player.X == 7 && player.Y == -1)
            {
                currentLevel = currentLevel + 1;
                loadlevel = true;
                if (currentLevel == 5)
                    drawwin = true;
            }
            else
            {
                drawwin = false;
            }

            base.Update(gameTime);
        }

        Boolean must = false;

        public Boolean pushRM(Circle player, Shape shp, int x, int y)
        {
            Boolean ispushed = true;
            for (int i = 0; i < rightmovers.Count; i++)
            {
                if (shp.X + x == rightmovers[i].X && shp.Y + y == rightmovers[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < bricks.Count; i++)
            {
                if (shp.X + x == bricks[i].X && shp.Y + y == bricks[i].Y)
                {
                    ispushed = false;
                }
            }
            if (x == 0 && y != 0)
            {
                for (int i = 0; i < blues.Count; i++)
                {
                    if (shp.X == blues[i].X && shp.Y + y == blues[i].Y)
                    {
                        ispushed = false;
                    }
                }
            }
            else if (y == 0 && x != 0)
            {
                for (int i = 0; i < yellows.Count; i++)
                {
                    if (shp.X + x == yellows[i].X && shp.Y == yellows[i].Y)
                    {
                        ispushed = false;
                    }
                }
            }
            for (int i = 0; i < greens.Count; i++)
            {
                if (shp.X + x == greens[i].X && shp.Y + y == greens[i].Y)
                {
                    ispushed = pushGreen(greens[i], x, y);
                    if (ispushed)
                    {
                        if (greens[i].X > 0 && greens[i].X < 14)
                            greens[i].X += x;
                        else
                            if (greens[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (greens[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (greens[i].Y > 0 && greens[i].Y < 9)
                            greens[i].Y += y;
                        else
                            if (greens[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (greens[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        greens[i].vector.X = greens[i].X * 30;
                        greens[i].vector.Y = greens[i].Y * 30;
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < blues.Count; i++)
            {
                if (shp.X + x == blues[i].X && shp.Y + y == blues[i].Y)
                {
                    ispushed = pushBlue(blues[i], x);
                    if (ispushed)
                    {
                        if (blues[i].X > 0 && blues[i].X < 14)
                            blues[i].X += x;
                        else
                            ispushed = false;
                        blues[i].vector.X = blues[i].X * 30;
                        return ispushed;
                    }
                }
            }
            return ispushed;
        }

        public Boolean pushDM(Circle player, Shape shp, int x, int y)
        {
            Boolean ispushed = true;
            for (int i = 0; i < downmovers.Count; i++)
            {
                if (shp.X + x == downmovers[i].X && shp.Y + y == downmovers[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < bricks.Count; i++)
            {
                if (shp.X + x == bricks[i].X && shp.Y + y == bricks[i].Y)
                {
                    ispushed = false;
                }
            }
            if (x == 0 && y != 0)
            {
                for (int i = 0; i < blues.Count; i++)
                {
                    if (shp.X == blues[i].X && shp.Y + y == blues[i].Y)
                    {
                        ispushed = false;
                    }
                }
            }
            else if (y == 0 && x != 0)
            {
                for (int i = 0; i < yellows.Count; i++)
                {
                    if (shp.X + x == yellows[i].X && shp.Y == yellows[i].Y)
                    {
                        ispushed = false;
                    }
                }
            }
            for (int i = 0; i < greens.Count; i++)
            {
                if (shp.X + x == greens[i].X && shp.Y + y == greens[i].Y)
                {
                    ispushed = pushGreen(greens[i], x, y);
                    if (ispushed)
                    {
                        if (greens[i].X > 0 && greens[i].X < 14)
                            greens[i].X += x;
                        else
                            if (greens[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (greens[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (greens[i].Y > 0 && greens[i].Y < 9)
                            greens[i].Y += y;
                        else
                            if (greens[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (greens[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        greens[i].vector.X = greens[i].X * 30;
                        greens[i].vector.Y = greens[i].Y * 30;
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < yellows.Count; i++)
            {
                if (shp.X + x == yellows[i].X && shp.Y + y == yellows[i].Y)
                {
                    ispushed = pushYellow(yellows[i], y);
                    if (ispushed)
                    {
                        if (yellows[i].Y > 0 && yellows[i].Y < 9)
                            yellows[i].Y += y;
                        else
                            ispushed = false;
                        yellows[i].vector.Y = yellows[i].Y * 30;
                        return ispushed;
                    }
                }
            }
            return ispushed;
        }

        public Boolean pushLM(Circle player, Shape shp, int x, int y)
        {
            Boolean ispushed = true;
            for (int i = 0; i < leftmovers.Count; i++)
            {
                if (shp.X + x == leftmovers[i].X && shp.Y + y == leftmovers[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < bricks.Count; i++)
            {
                if (shp.X + x == bricks[i].X && shp.Y + y == bricks[i].Y)
                {
                    ispushed = false;
                }
            }
            if (x == 0 && y != 0)
            {
                for (int i = 0; i < blues.Count; i++)
                {
                    if (shp.X == blues[i].X && shp.Y + y == blues[i].Y)
                    {
                        ispushed = false;
                    }
                }
            }
            else if (y == 0 && x != 0)
            {
                for (int i = 0; i < yellows.Count; i++)
                {
                    if (shp.X + x == yellows[i].X && shp.Y == yellows[i].Y)
                    {
                        ispushed = false;
                    }
                }
            }
            for (int i = 0; i < greens.Count; i++)
            {
                if (shp.X + x == greens[i].X && shp.Y + y == greens[i].Y)
                {
                    ispushed = pushGreen(greens[i], x, y);
                    if (ispushed)
                    {
                        if (greens[i].X > 0 && greens[i].X < 14)
                            greens[i].X += x;
                        else
                            if (greens[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (greens[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (greens[i].Y > 0 && greens[i].Y < 9)
                            greens[i].Y += y;
                        else
                            if (greens[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (greens[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        greens[i].vector.X = greens[i].X * 30;
                        greens[i].vector.Y = greens[i].Y * 30;
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < blues.Count; i++)
            {
                if (shp.X + x == blues[i].X && shp.Y + y == blues[i].Y)
                {
                    ispushed = pushBlue(blues[i], x);
                    if (ispushed)
                    {
                        if (blues[i].X > 0 && blues[i].X < 14)
                            blues[i].X += x;
                        else
                            ispushed = false;
                        blues[i].vector.X = blues[i].X * 30;
                        return ispushed;
                    }
                }
            }
            return ispushed;
        }

        public Boolean pushGreen(Shape shp, int x, int y)
        {
            Boolean ispushed = true;
            for (int i = 0; i < bricks.Count; i++)
            {
                if (shp.X + x == bricks[i].X && shp.Y + y == bricks[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < greens.Count; i++)
            {
                if (shp.X + x == greens[i].X && shp.Y + y == greens[i].Y)
                {
                    ispushed = pushGreen(greens[i], x, y);
                    if (ispushed)
                    {
                        if (greens[i].X > 0 && greens[i].X < 14)
                            greens[i].X += x;
                        else
                            if(greens[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (greens[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (greens[i].Y > 0 && greens[i].Y < 9)
                            greens[i].Y += y;
                        else
                            if (greens[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (greens[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        greens[i].vector.X = greens[i].X * 30;
                        greens[i].vector.Y = greens[i].Y * 30;
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < yellows.Count; i++)
            {
                if (shp.X + x == yellows[i].X && shp.Y + y == yellows[i].Y)
                {
                    ispushed = pushYellow(yellows[i], y);
                    if (ispushed)
                    {
                        if (yellows[i].Y > 0 && yellows[i].Y < 9)
                            yellows[i].Y += y;
                        else
                            ispushed = false;
                        yellows[i].vector.Y = yellows[i].Y * 30;
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < blues.Count; i++)
            {
                if (shp.X + x == blues[i].X && shp.Y + y == blues[i].Y)
                {
                    ispushed = pushBlue(blues[i], x);
                    if (ispushed)
                    {
                        if (blues[i].X > 0 && blues[i].X < 14)
                            blues[i].X += x;
                        else
                            ispushed = false;
                        blues[i].vector.X = blues[i].X * 30;
                        return ispushed;
                    }
                }
            }
            return ispushed;
        }

        public Boolean pushYellow(Shape shp, int y)
        {
            Boolean ispushed = true;
            for (int i = 0; i < bricks.Count; i++)
            {
                if (shp.X == bricks[i].X && shp.Y + y == bricks[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < blues.Count; i++)
            {
                if (shp.X == blues[i].X && shp.Y + y == blues[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < leftmovers.Count; i++)
            {
                if (shp.X == leftmovers[i].X && shp.Y + y == leftmovers[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < rightmovers.Count; i++)
            {
                if (shp.X == rightmovers[i].X && shp.Y + y == rightmovers[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < downmovers.Count; i++)
            {
                if (shp.X == downmovers[i].X && shp.Y + y == downmovers[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < yellows.Count; i++)
            {
                if (shp.X == yellows[i].X && shp.Y + y == yellows[i].Y)
                {
                    ispushed = pushYellow(yellows[i], y);
                    if (ispushed)
                    {
                        if (yellows[i].Y > 0 && yellows[i].Y < 9)
                            yellows[i].Y += y;
                        else
                            ispushed = false;
                        yellows[i].vector.Y = yellows[i].Y * 30;
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < greens.Count; i++)
            {
                if (shp.X == greens[i].X && shp.Y + y == greens[i].Y)
                {
                    ispushed = pushGreen(greens[i], 0, y);
                    if (ispushed)
                    {
                        if (greens[i].Y > 0 && greens[i].Y < 9)
                            greens[i].Y += y;
                        else
                            ispushed = false;
                        greens[i].vector.Y = greens[i].Y * 30;
                        return ispushed;
                    }
                }
            }
            return ispushed;
        }

        public Boolean pushBlue(Shape shp, int x)
        {
            Boolean ispushed = true;
            for (int i = 0; i < bricks.Count; i++)
            {
                if (shp.X + x == bricks[i].X && shp.Y == bricks[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < yellows.Count; i++)
            {
                if (shp.X + x == yellows[i].X && shp.Y == yellows[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < leftmovers.Count; i++)
            {
                if (shp.X + x == leftmovers[i].X && shp.Y == leftmovers[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < rightmovers.Count; i++)
            {
                if (shp.X + x == rightmovers[i].X && shp.Y == rightmovers[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < downmovers.Count; i++)
            {
                if (shp.X + x == downmovers[i].X && shp.Y == downmovers[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < blues.Count; i++)
            {
                if (shp.X + x == blues[i].X && shp.Y == blues[i].Y)
                {
                    ispushed = pushBlue(blues[i], x);
                    if (ispushed)
                    {
                        if (blues[i].X > 0 && blues[i].X < 14)
                            blues[i].X += x;
                        else
                            ispushed = false;
                        blues[i].vector.X = blues[i].X * 30;
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < greens.Count; i++)
            {
                if (shp.X + x == greens[i].X && shp.Y == greens[i].Y)
                {
                    ispushed = pushGreen(greens[i], x, 0);
                    if (ispushed)
                    {
                        if (greens[i].X > 0 && greens[i].X < 14)
                            greens[i].X += x;
                        else
                            ispushed = false;
                        greens[i].vector.X = greens[i].X * 30;
                        return ispushed;
                    }
                }
            }
            return ispushed;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(green, new Vector2(7*30+1, -30+4), Color.White);
            for (int i = 0; i < bricks.Count; i++)
            {
                spriteBatch.Draw(brick, bricks[i].vector, Color.White);
            }
            for (int i = 0; i < greens.Count; i++)
            {
                spriteBatch.Draw(green, greens[i].vector, Color.White);
            }
            for (int i = 0; i < blues.Count; i++)
            {
                spriteBatch.Draw(blue, blues[i].vector, Color.White);
            }
            for (int i = 0; i < yellows.Count; i++)
            {
                spriteBatch.Draw(yellow, yellows[i].vector, Color.White);
            }
            for (int i = 0; i < downmovers.Count; i++)
            {
                spriteBatch.Draw(downmover, downmovers[i].vector, Color.White);
            }
            for (int i = 0; i < rightmovers.Count; i++)
            {
                spriteBatch.Draw(rightmover, rightmovers[i].vector, Color.White);
            }
            for (int i = 0; i < leftmovers.Count; i++)
            {
                spriteBatch.Draw(leftmover, leftmovers[i].vector, Color.White);
            }
            spriteBatch.Draw(circle, player.vector, Color.White);
            if (drawwin)
            {
                spriteBatch.DrawString(spriteFont, "You win!", new Vector2(0, 0), Color.White);
            }
            else
            {
                spriteBatch.DrawString(spriteFont, "You win!", new Vector2(0, 0), Color.Black);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
