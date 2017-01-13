using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cyberbox
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GifAnimation.GifAnimation background, brick, green, yellow, blue;
        Boolean cheat = true;
        String[] rooms = new String[17];
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Block1> block1s = new List<Block1>();
        List<Block2> block2s = new List<Block2>();
        List<Brick> bricks = new List<Brick>();
        List<Green> greens = new List<Green>();
        List<Yellow> yellows = new List<Yellow>();
        List<Blue> blues = new List<Blue>();
        List<LeftMover> leftmovers = new List<LeftMover>();
        List<RightMover> rightmovers = new List<RightMover>();
        List<DownMover> downmovers = new List<DownMover>();
        List<UpMover> upmovers = new List<UpMover>();
        List<UpZapp> upzapps = new List<UpZapp>();
        List<DownZapp> downzapps = new List<DownZapp>();
        List<LeftZapp> leftzapps = new List<LeftZapp>();
        List<RightZapp> rightzapps = new List<RightZapp>();
        SpriteFont spriteFont, spriteFont2, spriteFont3, cyberFont;
        Texture2D circle, downmover, upmover, rightmover, leftmover, block1, block2;
        Circle player;
        Texture2D pixel, upzapp, downzapp, leftzapp, rightzapp;
        KeyboardState _currentKeyboardState;
        KeyboardState _previousKeyboardState;
        Rectangle rect;
        int currentLevel = 0;
        bool drawwin = false;
        bool loadlevel = true;
        int attempts = 4;

        public class LeftMover : Shape
        {
        }

        public class DownMover : Shape
        {
        }

        public class RightMover : Shape
        {
        }

        public class UpMover : Shape
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

        public class UpZapp : Shape
        {
        }

        public class DownZapp : Shape
        {
        }

        public class LeftZapp : Shape
        {
        }

        public class RightZapp : Shape
        {
        }

        public class Block1 : Shape
        {
        }

        public class Block2 : Shape
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
            graphics.PreferredBackBufferWidth = 615;
            graphics.PreferredBackBufferHeight = 490;
            graphics.ToggleFullScreen();
            graphics.ToggleFullScreen();
            Content.RootDirectory = "Content";
        }

        public class Background : DrawableGameComponent
        {
            SpriteBatch spriteBatch;
            Texture2D dummyTexture;
            Rectangle dummyRectangle;
            Color Colori;

            public Background(Rectangle rect, Color colori, Game game, SpriteBatch sp)
                : base(game)
            {
                spriteBatch = sp;
                DrawOrder = 0;
                dummyRectangle = rect;
                Colori = colori;
            }

            public void LoadContent()
            {
                dummyTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                dummyTexture.SetData(new Color[] { Color.White });
            }

            public override void Draw(GameTime gameTime)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(dummyTexture, dummyRectangle, Colori);
                spriteBatch.End();
            }
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
            // Somewhere in your LoadContent() method:
            pixel = new Texture2D(this.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White }); // so that we can draw whatever color we want on top of it

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //rect = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            //background = new Background(rect, Color.Black, this, spriteBatch);
            //background.LoadContent();

            // TODO: use this.Content to load your game content here
            background = Content.Load<GifAnimation.GifAnimation>("bk");
            circle = Content.Load<Texture2D>("circle");
            block1 = Content.Load<Texture2D>("block1");
            block2 = Content.Load<Texture2D>("block2");
            brick = Content.Load<GifAnimation.GifAnimation>("brick");
            green = Content.Load<GifAnimation.GifAnimation>("green");
            yellow = Content.Load<GifAnimation.GifAnimation>("yellow");
            blue = Content.Load<GifAnimation.GifAnimation>("blue");
            rightmover = Content.Load<Texture2D>("rightmover");
            leftmover = Content.Load<Texture2D>("leftmover");
            downmover = Content.Load<Texture2D>("downmover");
            upmover = Content.Load<Texture2D>("upmover");
            upzapp = Content.Load<Texture2D>("upzapp");
            downzapp = Content.Load<Texture2D>("downzapp");
            leftzapp = Content.Load<Texture2D>("leftzapp");
            rightzapp = Content.Load<Texture2D>("rightzapp");
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");
            cyberFont = Content.Load<SpriteFont>("SpriteFont2");
            spriteFont2 = Content.Load<SpriteFont>("SpriteFont3");
            spriteFont3 = Content.Load<SpriteFont>("SpriteFont4");

            rooms[0] = "The Lobby";
            rooms[1] = "No Problem";
            rooms[2] = "Think Ahead";
            rooms[3] = "Choices, Choices";
            rooms[4] = "You Can Do It";
            rooms[5] = "Chain Reaction";
            rooms[6] = "Your Guess";
            rooms[7] = "Go With The Flow";
            rooms[8] = "Don't Get Zapped!";
            rooms[9] = "Prioritize!";
            rooms[10] = "Fifty Fifty...";
            rooms[11] = "Watch Your Step!";
            rooms[12] = "Move It Or Lose It";
            rooms[13] = "Zapperland";
            rooms[14] = "Logistics...";
            rooms[15] = "Last But Not Least";
            rooms[16] = "...Almost!";
        }

        public void Level1()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();
            upmovers.Clear();

            player = new Circle();
            player.prevX = 7;
            player.prevY = 9;
            player.X = 7;
            player.Y = 9;
            player.vector.X = player.X *((int)(30*1.3));
            player.vector.Y = player.Y *((int)(30*1.3));

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
            upmovers.Clear();

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
            player.vector.Y = player.Y *((int)(30*1.3));
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
            upmovers.Clear();

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
            AddBrick(6, 7);
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
            player.vector.Y = player.Y *((int)(30*1.3));
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
            upmovers.Clear();

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
            player.vector.Y = player.Y *((int)(30*1.3));
        }

        public void Level5()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();
            upmovers.Clear();

            AddBrick(6, 0);
            AddBlue(12, 0);
            AddBlue(13, 0);
            AddBrick(1, 1);
            AddBrick(7, 1);
            AddYellow(9, 1);
            AddBlue(11, 1);
            AddBrick(13, 1);
            AddBrick(0, 2);
            AddBrick(2, 2);
            AddYellow(4, 2);
            AddYellow(6, 2);
            AddBrick(8, 2);
            AddBrick(12, 2);
            AddBrick(0, 3);
            AddBrick(2, 3);
            AddBrick(3, 3);
            AddYellow(4, 3);
            AddBrick(5, 3);
            AddYellow(7, 3);
            AddBrick(9, 3);
            AddBrick(10, 3);
            AddBrick(11, 3);
            AddYellow(14, 3);
            AddBrick(0, 4);
            AddBrick(2, 4);
            AddDM(3, 4);
            AddDM(4, 4);
            AddBrick(5, 4);
            AddYellow(8, 4);
            AddBrick(11, 4);
            AddYellow(1, 5);
            AddBlue(2, 5);
            AddBlue(3, 5);
            AddBlue(4, 5);
            AddGreen(5, 5);
            AddBrick(9, 5);
            AddBrick(11, 5);
            AddYellow(1, 6);
            AddBrick(2, 6);
            AddBrick(5, 6);
            AddBrick(6, 6);
            AddBrick(7, 6);
            AddBrick(9, 6);
            AddBrick(11, 6);
            AddBrick(13, 6);
            AddBrick(14, 6);
            AddGreen(1, 7);
            AddBrick(2, 7);
            AddBrick(6, 7);
            AddBrick(7, 7);
            AddBrick(8, 7);
            AddBrick(9, 7);
            AddBlue(11, 7);
            AddBlue(12, 7);
            AddGreen(13, 7);
            AddBrick(0, 8);
            AddYellow(1, 8);
            AddBrick(2, 8);
            AddBrick(3, 8);
            AddBrick(4, 8);
            AddBrick(5, 8);
            AddBrick(6, 8);
            AddBrick(7, 8);
            AddBrick(8, 8);
            AddBrick(9, 8);
            AddGreen(11, 8);
            AddBlue(12, 8);
            AddBlue(13, 8);
            AddBrick(8, 9);

            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * ((int)(30 * 1.3));
        }

        public void Level6()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();
            upmovers.Clear();

            AddBrick(3, 0);
            AddDM(6, 0);
            AddBlue(3, 1);
            AddBlue(4, 1);
            AddBlue(5, 1);
            AddDM(6, 1);
            AddBlue(7, 1);
            AddBlue(8, 1);
            AddBlue(9, 1);
            AddBlue(10, 1);
            AddBlue(11, 1);
            AddBlue(12, 1);
            AddYellow(13, 1);
            AddLM(14, 1);
            AddBlue(6, 2);
            AddBrick(12, 2);
            AddGreen(13, 2);
            AddYellow(13, 3);
            AddBrick(6, 4);
            AddYellow(13, 4);
            AddRM(0, 5);
            AddBlue(1, 5);
            AddBlue(2, 5);
            AddBlue(3, 5);
            AddYellow(4, 5);
            AddBrick(5, 5);
            AddBrick(6, 5);
            AddBrick(7, 5);
            AddBrick(8, 5);
            AddBrick(9, 5);
            AddBrick(10, 5);
            AddBrick(11, 5);
            AddBrick(12, 5);
            AddYellow(13, 5);
            AddBrick(14, 5);
            AddBrick(0, 6);
            AddBrick(1, 6);
            AddBrick(2, 6);
            AddBrick(3, 6);
            AddBrick(5, 6);
            AddBrick(7, 6);
            AddBrick(11, 6);
            AddBrick(12, 6);
            AddYellow(13, 6);
            AddBlue(5, 7);
            AddBrick(12, 7);
            AddYellow(13, 7);
            AddBrick(5, 8);
            AddBrick(6, 8);
            AddBrick(7, 8);
            AddBrick(8, 8);
            AddBrick(9, 8);
            AddBrick(10, 8);
            AddYellow(11, 8);
            AddGreen(12, 8);
            AddBlue(13, 8);
            AddBrick(8, 9);
            AddUM(13, 9);

            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * ((int)(30 * 1.3));
        }

        public void Level7()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();
            upmovers.Clear();

            AddBlue(0, 0);
            AddBlue(1, 0);
            AddDM(2, 0);
            AddBlue(3, 0);
            AddBlue(4, 0);
            AddBlue(5, 0);
            AddBlue(6, 0);
            AddBrick(9, 0);
            AddBlue(2, 1);
            AddBrick(6, 1);
            AddGreen(7, 1);
            AddBrick(9, 1);
            AddGreen(4, 2);
            AddRM(5, 2);
            AddRM(6, 2);
            AddYellow(7, 2);
            AddBrick(9, 2);
            AddBrick(12, 2);
            AddBrick(13, 2);
            AddBrick(0, 3);
            AddBrick(1, 3);
            AddGreen(4, 3);
            AddBlue(5, 3);
            AddBrick(8, 3);
            AddBrick(11, 3);
            AddBrick(14, 3);
            AddRM(1, 4);
            AddYellow(2, 4);
            AddGreen(4, 4);
            AddBlue(7, 4);
            AddBrick(14, 4);
            AddGreen(4, 5);
            AddUM(7, 5);
            AddBrick(13, 5);
            AddGreen(4, 6);
            AddBrick(12, 6);
            AddBrick(0, 7);
            AddBrick(1, 7);
            AddBlue(3, 7);
            AddBlue(4, 7);
            AddGreen(5, 7);
            AddBlue(6, 7);
            AddBlue(7, 7);
            AddBlue(8, 7);
            AddBlue(9, 7);
            AddBlue(10, 7);
            AddBrick(12, 7);
            AddBrick(12, 9);

            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * ((int)(30 * 1.3));
        }

        public void Level8()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();
            upmovers.Clear();
            upzapps.Clear();
            downzapps.Clear();
            leftzapps.Clear();
            rightzapps.Clear();

            AddBrick(6, 0);
            AddBrick(8, 0);
            AddBrick(1, 1);
            AddBrick(2, 1);
            AddBrick(5, 1);
            AddUZ(7, 1);
            AddBrick(9, 1);
            AddBrick(12, 1);
            AddBrick(13, 1);
            AddBrick(0, 2);
            AddBrick(3, 2);
            AddYellow(6, 2);
            AddBlue(7, 2);
            AddYellow(8, 2);
            AddBrick(12, 2);
            AddBrick(13, 2);
            AddDZ(2, 3);
            AddGreen(6, 3);
            AddBrick(7, 3);
            AddGreen(8, 3);
            AddBrick(12, 3);
            AddBrick(13, 3);
            AddBrick(1, 4);
            AddBrick(3, 4);
            AddYellow(6, 4);
            AddBrick(7, 4);
            AddYellow(8, 4);
            AddBrick(12, 4);
            AddBrick(13, 4);
            AddUZ(0, 5);
            AddRM(1, 5);
            AddYellow(2, 5);
            AddBlue(6, 5);
            AddBlue(7, 5);
            AddBlue(8, 5);
            AddBlue(9, 5);
            AddBrick(1, 6);
            AddBrick(3, 6);
            AddBrick(4, 6);
            AddBrick(5, 6);
            AddUM(6, 6);
            AddBrick(7, 6);
            AddUM(8, 6);
            AddUM(9, 6);
            AddBrick(12, 6);
            AddBrick(13, 6);
            AddBrick(1, 7);
            AddBrick(3, 7);
            AddLZ(5, 7);
            AddBrick(8, 7);
            AddBrick(12, 7);
            AddBrick(13, 7);
            AddBrick(1, 8);
            AddBrick(2, 8);
            AddBrick(3, 8);
            AddLZ(5, 8);
            AddBrick(8, 8);
            AddLZ(5, 9);
            AddBrick(8, 9);

            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * ((int)(30 * 1.3));
        }

        public void Level9()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();
            upmovers.Clear();
            upzapps.Clear();
            downzapps.Clear();
            leftzapps.Clear();
            rightzapps.Clear();

            AddBrick(5, 0);
            AddDM(6, 0);
            AddDM(7, 0);
            AddDM(8, 0);
            AddBlue(11, 0);
            AddDM(12, 0);
            AddYellow(0, 1);
            AddBlue(1, 1);
            AddBlue(2, 1);
            AddBlue(3, 1);
            AddBlue(4, 1);
            AddGreen(5, 1);
            AddBlue(6, 1);
            AddBlue(7, 1);
            AddGreen(8, 1);
            AddBlue(12, 1);
            AddBrick(1, 2);
            AddBrick(2, 2);
            AddDZ(3, 2);
            AddRZ(6, 2);
            AddLZ(8, 2);
            AddBrick(11, 2);
            AddUZ(0, 3);
            AddBrick(2, 3);
            AddBrick(5, 3);
            AddBrick(6, 3);
            AddBrick(8, 3);
            AddBrick(9, 3);
            AddBrick(10, 3);
            AddBrick(2, 4);
            AddBrick(3, 4);
            AddBrick(4, 4);
            AddLZ(6, 4);
            AddRZ(8, 4);
            AddBrick(10, 4);
            AddBrick(1, 5);
            AddLZ(3, 5);
            AddBrick(6, 5);
            AddBrick(8, 5);
            AddBrick(10, 5);
            AddBrick(11, 5);
            AddUZ(12, 5);
            AddBrick(13, 5);
            AddBrick(14, 5);
            AddUZ(0, 6);
            AddUZ(2, 6);
            AddDZ(4, 6);
            AddBrick(6, 6);
            AddBrick(8, 6);
            AddBlue(11, 6);
            AddBlue(12, 6);
            AddBlue(13, 6);
            AddLZ(1, 7);
            AddRZ(3, 7);
            AddDZ(5, 7);
            AddBrick(6, 7);
            AddUZ(7, 7);
            AddBrick(8, 7);
            AddDM(13, 7);
            AddRZ(0, 8);
            AddUZ(2, 8);
            AddDZ(4, 8);
            AddBrick(6, 8);
            AddBrick(8, 8);
            AddBlue(11, 8);
            AddGreen(12, 8);
            AddBlue(13, 8);
            AddLZ(1, 9);
            AddLZ(3, 9);
            AddBrick(5, 9);
            AddBrick(6, 9);
            AddBrick(8, 9);
            AddBrick(14, 9);

            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * ((int)(30 * 1.3));
        }

        public void Level10()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();
            upmovers.Clear();
            upzapps.Clear();
            downzapps.Clear();
            leftzapps.Clear();
            rightzapps.Clear();

            AddBrick(1, 0);
            AddBrick(6, 0);
            AddBrick(8, 0);
            AddBrick(10, 0);
            AddRM(1, 1);
            AddYellow(2, 1);
            AddBlue(7, 1);
            AddBrick(11, 1);
            AddBrick(12, 1);
            AddBrick(13, 1);
            AddBrick(14, 1);
            AddGreen(2, 2);
            AddBrick(3, 2);
            AddBrick(6, 2);
            AddBrick(8, 2);
            AddBrick(9, 2);
            AddBrick(10, 2);
            AddYellow(2, 3);
            AddBrick(5, 3);
            AddBlue(7, 3);
            AddYellow(2, 4);
            AddBrick(5, 4);
            AddRM(6, 4);
            AddYellow(7, 4);
            AddBrick(8, 4);
            AddBrick(12, 4);
            AddBrick(13, 4);
            AddBrick(1, 5);
            AddYellow(2, 5);
            AddBrick(5, 5);
            AddBrick(6, 5);
            AddBrick(8, 5);
            AddBrick(9, 5);
            AddBrick(10, 5);
            AddBrick(11, 5);
            AddUZ(0, 6);
            AddBlue(2, 6);
            AddGreen(3, 6);
            AddBlue(4, 6);
            AddBlue(5, 6);
            AddBlue(6, 6);
            AddBrick(8, 6);
            AddRM(9, 6);
            AddRM(10, 6);
            AddRM(11, 6);
            AddGreen(12, 6);
            AddGreen(13, 6);
            AddGreen(14, 6);
            AddBrick(1, 7);
            AddYellow(2, 7);
            AddBrick(5, 7);
            AddBrick(6, 7);
            AddUZ(7, 7);
            AddBrick(8, 7);
            AddBrick(9, 7);
            AddBrick(3, 8);
            AddBrick(4, 8);
            AddBrick(12, 9);
            AddBrick(13, 9);
            AddBrick(14, 9);

            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * ((int)(30 * 1.3));
        }

        public void Level11()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();
            upmovers.Clear();
            upzapps.Clear();
            downzapps.Clear();
            leftzapps.Clear();
            rightzapps.Clear();

            AddBrick(4, 0);
            AddBrick(5, 0);
            AddBrick(6, 0);
            AddDM(7, 0);
            AddBrick(8, 0);
            AddBrick(9, 0);
            AddBrick(10, 0);
            AddBrick(11, 0);
            AddBrick(3, 1);
            AddBlue(6, 1);
            AddBlue(7, 1);
            AddBlue(8, 1);
            AddGreen(9, 1);
            AddBlue(10, 1);
            AddBrick(12, 1);
            AddBrick(2, 2);
            AddGreen(4, 2);
            AddBlue(5, 2);
            AddBlue(6, 2);
            AddBlue(7, 2);
            AddBlue(8, 2);
            AddBrick(13, 2);
            AddBrick(2, 3);
            AddBlue(5, 3);
            AddBlue(6, 3);
            AddBlue(7, 3);
            AddGreen(8, 3);
            AddBlue(9, 3);
            AddBlue(10, 3);
            AddBrick(13, 3);
            AddBrick(2, 4);
            AddBlue(4, 4);
            AddGreen(5, 4);
            AddBlue(6, 4);
            AddBlue(7, 4);
            AddGreen(8, 4);
            AddBlue(9, 4);
            AddBlue(10, 4);
            AddBrick(13, 4);
            AddBrick(2, 5);
            AddBlue(5, 5);
            AddBlue(6, 5);
            AddBlue(7, 5);
            AddGreen(8, 5);
            AddBlue(9, 5);
            AddBlue(10, 5);
            AddBrick(13, 5);
            AddBrick(3, 6);
            AddBlue(7, 6);
            AddBrick(12, 6);
            AddBrick(6, 7);
            AddBrick(8, 7);
            AddBrick(5, 8);
            AddDM(6, 8);
            AddBrick(7, 8);
            AddDM(8, 8);
            AddBrick(9, 8);
            AddBlue(5, 9);
            AddBlue(6, 9);
            AddBlue(8, 9);
            AddBlue(9, 9);

            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * ((int)(30 * 1.3));
        }

        public void Level12()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();
            upmovers.Clear();
            upzapps.Clear();
            downzapps.Clear();
            leftzapps.Clear();
            rightzapps.Clear();

            AddBrick(2, 0);
            AddDM(3, 0);
            AddBlock1(5, 0);
            AddBlue(6, 0);
            AddBlue(7, 0);
            AddDM(10, 0);
            AddBlue(3, 1);
            AddBrick(7, 1);
            AddYellow(10, 1);
            AddBrick(0, 2);
            AddUZ(1, 2);
            AddBrick(2, 2);
            AddYellow(3, 2);
            AddBrick(8, 2);
            AddBrick(9, 2);
            AddGreen(10, 2);
            AddBrick(11, 2);
            AddYellow(3, 3);
            AddBlue(4, 3);
            AddBlue(5, 3);
            AddBlue(6, 3);
            AddBlue(7, 3);
            AddBlue(8, 3);
            AddBlue(9, 3);
            AddLM(10, 3);
            AddBrick(12, 3);
            AddLZ(2, 4);
            AddGreen(5, 4);
            AddBrick(7, 4);
            AddDZ(8, 4);
            AddBrick(9, 4);
            AddBrick(10, 4);
            AddBrick(11, 4);
            AddLZ(2, 5);
            AddGreen(5, 5);
            AddGreen(8, 5);
            AddBlue(11, 5);
            AddBlue(12, 5);
            AddLZ(2, 6);
            AddGreen(5, 6);
            AddGreen(8, 6);
            AddBrick(10, 6);
            AddBrick(11, 6);
            AddUM(12, 6);
            AddUZ(13, 6);
            AddUZ(14, 6);
            AddBrick(3, 7);
            AddBrick(4, 7);
            AddBrick(6, 7);
            AddBrick(7, 7);
            AddBrick(8, 7);
            AddBrick(10, 7);
            AddBlock1(5, 8);
            AddBlue(7, 8);
            AddBlock1(9, 8);
            AddBlock1(5, 9);
            AddBlock1(9, 9);

            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * ((int)(30 * 1.3));
        }

        public void Level13()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();
            upmovers.Clear();
            upzapps.Clear();
            downzapps.Clear();
            leftzapps.Clear();
            rightzapps.Clear();
            block1s.Clear();

            AddBlock1(6, 0);
            AddBlock1(7, 0);
            AddBlock1(8, 0);
            AddBrick(8, 1);
            AddBrick(9, 1);
            AddBrick(10, 1);
            AddBrick(11, 1);
            AddBrick(5, 2);
            AddBrick(6, 2);
            AddBrick(7, 2);
            AddLZ(11, 2);
            AddBrick(0, 3);
            AddBrick(1, 3);
            AddBrick(2, 3);
            AddBrick(3, 3);
            AddBrick(4, 3);
            AddBrick(10, 3);
            AddBrick(11, 3);
            AddBrick(6, 4);
            AddBrick(7, 4);
            AddBrick(8, 4);
            AddBrick(9, 4);
            AddBrick(12, 4);
            AddBrick(14, 4);
            AddBrick(2, 5);
            AddBlue(7, 5);
            AddLZ(12, 5);
            AddBrick(0, 6);
            AddBrick(2, 6);
            AddBrick(3, 6);
            AddBrick(4, 6);
            AddBrick(5, 6);
            AddBrick(6, 6);
            AddBrick(7, 6);
            AddBrick(9, 6);
            AddBrick(11, 6);
            AddGreen(5, 7);
            AddLZ(7, 7);
            AddBrick(9, 7);
            AddBrick(11, 7);
            AddBrick(6, 8);
            AddBrick(7, 8);
            AddBlue(13, 8);
            AddBrick(8, 9);
            AddBrick(11, 9);
            AddBrick(12, 9);
            AddUM(13, 9);
            AddBrick(14, 9);

            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * ((int)(30 * 1.3));
        }

        public void Level14()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();
            upmovers.Clear();
            upzapps.Clear();
            downzapps.Clear();
            leftzapps.Clear();
            rightzapps.Clear();
            block1s.Clear();

            AddRZ(2, 0);
            AddRZ(4, 0);
            AddRZ(6, 0);
            AddRZ(8, 0);
            AddLZ(10, 0);
            AddLZ(12, 0);
            AddRZ(1, 1);
            AddRZ(3, 1);
            AddLZ(5, 1);
            AddLZ(7, 1);
            AddLZ(9, 1);
            AddRZ(11, 1);
            AddLZ(13, 1);
            AddUZ(0, 2);
            AddDZ(2, 2);
            AddUZ(4, 2);
            AddUZ(6, 2);
            AddDZ(8, 2);
            AddUZ(10, 2);
            AddDZ(12, 2);
            AddUZ(14, 2);
            AddLZ(1, 3);
            AddLZ(3, 3);
            AddRZ(5, 3);
            AddLZ(7, 3);
            AddDZ(9, 3);
            AddLZ(11, 3);
            AddLZ(13, 3);
            AddDZ(0, 4);
            AddDZ(2, 4);
            AddUZ(4, 4);
            AddUZ(6, 4);
            AddDZ(8, 4);
            AddLZ(10, 4);
            AddRZ(12, 4);
            AddUZ(14, 4);
            AddRZ(1, 5);
            AddLZ(3, 5);
            AddLZ(5, 5);
            AddLZ(7, 5);
            AddRZ(9, 5);
            AddUZ(11, 5);
            AddRZ(13, 5);
            AddUZ(0, 6);
            AddDZ(2, 6);
            AddDZ(4, 6);
            AddDZ(6, 6);
            AddDZ(8, 6);
            AddUZ(10, 6);
            AddUZ(12, 6);
            AddDZ(14, 6);
            AddLZ(1, 7);
            AddRZ(3, 7);
            AddRZ(5, 7);
            AddLZ(7, 7);
            AddRZ(9, 7);
            AddRZ(11, 7);
            AddRZ(13, 7);
            AddDZ(0, 8);
            AddUZ(2, 8);
            AddUZ(4, 8);
            AddUZ(6, 8);
            AddUZ(8, 8);
            AddUZ(10, 8);
            AddDZ(12, 8);
            AddUZ(14, 8);
            AddRZ(1, 9);
            AddLZ(3, 9);
            AddLZ(5, 9);
            AddRZ(9, 9);
            AddRZ(11, 9);
            AddRZ(13, 9);

            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * ((int)(30 * 1.3));
        }

        public void Level15()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();
            upmovers.Clear();
            upzapps.Clear();
            downzapps.Clear();
            leftzapps.Clear();
            rightzapps.Clear();
            block1s.Clear();
            block2s.Clear();

            AddGreen(1, 0);
            AddBlue(5, 0);
            AddBlue(6, 0);
            AddDM(7, 0);
            AddBlue(8, 0);
            AddBlue(9, 0);
            AddDM(10, 0);
            AddBlue(11, 0);
            AddBlue(12, 0);
            AddDM(13, 0);
            AddBlue(14, 0);
            AddGreen(1, 1);
            AddBrick(4, 1);
            AddBrick(5, 1);
            AddBrick(6, 1);
            AddYellow(7, 1);
            AddBrick(8, 1);
            AddBlock1(10, 1);
            AddBlock1(13, 1);
            AddBrick(1, 2);
            AddBrick(2, 2);
            AddBrick(3, 2);
            AddBrick(6, 2);
            AddYellow(7, 2);
            AddBrick(8, 2);
            AddBlock2(10, 2);
            AddBlock2(13, 2);
            AddUZ(0, 3);
            AddBrick(3, 3);
            AddBrick(4, 3);
            AddBrick(5, 3);
            AddYellow(7, 3);
            AddBrick(8, 3);
            AddBlock2(10, 3);
            AddBlock2(13, 3);
            AddYellow(1, 4);
            AddYellow(2, 4);
            AddBrick(4, 4);
            AddBlock1(7, 4);
            AddBrick(8, 4);
            AddBrick(9, 4);
            AddBrick(10, 4);
            AddGreen(11, 4);
            AddBrick(13, 4);
            AddBrick(0, 5);
            AddBlock2(1, 5);
            AddBlock2(2, 5);
            AddUZ(3, 5);
            AddBrick(4, 5);
            AddBlock2(7, 5);
            AddBrick(10, 5);
            AddBrick(12, 5);
            AddBrick(13, 5);
            AddBrick(14, 5);
            AddYellow(1, 6);
            AddYellow(2, 6);
            AddBrick(4, 6);
            AddBlock2(7, 6);
            AddBrick(10, 6);
            AddBrick(12, 6);
            AddBrick(0, 7);
            AddBrick(1, 7);
            AddBrick(3, 7);
            AddBrick(4, 7);
            AddBrick(5, 7);
            AddBrick(7, 7);
            AddBrick(9, 7);
            AddBrick(10, 7);
            AddBrick(4, 9);
            AddBrick(10, 9);

            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * ((int)(30 * 1.3));
        }

        public void Level16()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();
            upmovers.Clear();
            upzapps.Clear();
            downzapps.Clear();
            leftzapps.Clear();
            rightzapps.Clear();
            block1s.Clear();
            block2s.Clear();

            AddBrick(6, 0);
            AddLZ(8, 0);
            AddBrick(0, 1);
            AddBrick(1, 1);
            AddBrick(5, 1);
            AddBrick(7, 1);
            AddBrick(9, 1);
            AddBrick(10, 1);
            AddBrick(11, 1);
            AddBrick(12, 1);
            AddYellow(2, 2);
            AddBlock2(3, 2);
            AddYellow(4, 2);
            AddBrick(7, 2);
            AddBrick(9, 2);
            AddBrick(12, 2);
            AddBrick(14, 2);
            AddUZ(0, 3);
            AddBlock1(2, 3);
            AddBrick(3, 3);
            AddBlock1(4, 3);
            AddBrick(5, 3);
            AddYellow(8, 3);
            AddBlue(11, 3);
            AddBlock2(12, 3);
            AddBlue(13, 3);
            AddLZ(1, 4);
            AddBlock2(2, 4);
            AddBlock2(4, 4);
            AddBrick(6, 4);
            AddBlock1(8, 4);
            AddBrick(9, 4);
            AddBrick(10, 4);
            AddBrick(11, 4);
            AddBrick(12, 4);
            AddBrick(14, 4);
            AddBrick(0, 5);
            AddBrick(6, 5);
            AddBlock2(8, 5);
            AddBlue(11, 5);
            AddBlock2(12, 5);
            AddBlue(13, 5);
            AddBrick(6, 6);
            AddDZ(7, 6);
            AddBlock1(8, 6);
            AddBrick(9, 6);
            AddBrick(10, 6);
            AddBrick(11, 6);
            AddBrick(12, 6);
            AddBrick(14, 6);
            AddBrick(6, 7);
            AddYellow(8, 7);
            AddRZ(9, 7);
            AddBlue(11, 7);
            AddBlock2(12, 7);
            AddBlue(13, 7);
            AddBlue(1, 8);
            AddBlue(2, 8);
            AddGreen(3, 8);
            AddBlue(4, 8);
            AddLZ(6, 8);
            AddBrick(9, 8);
            AddBrick(10, 8);
            AddDZ(11, 8);
            AddBrick(12, 8);
            AddBrick(14, 8);
            AddUM(2, 9);
            AddUM(4, 9);
            AddBrick(6, 9);
            AddBrick(8, 9);
            AddBrick(9, 9);

            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * ((int)(30 * 1.3));
        }

        public void Level17()
        {
            bricks.Clear();
            greens.Clear();
            yellows.Clear();
            blues.Clear();
            leftmovers.Clear();
            downmovers.Clear();
            rightmovers.Clear();
            upmovers.Clear();
            upzapps.Clear();
            downzapps.Clear();
            leftzapps.Clear();
            rightzapps.Clear();
            block1s.Clear();
            block2s.Clear();

            AddYellow(2, 0);
            AddYellow(4, 0);
            AddDM(7, 0);
            AddBrick(10, 0);
            AddBrick(13, 0);
            AddYellow(2, 1);
            AddYellow(4, 1);
            AddYellow(6, 1);
            AddGreen(7, 1);
            AddYellow(8, 1);
            AddBrick(10, 1);
            AddBrick(13, 1);
            AddYellow(3, 2);
            AddYellow(6, 2);
            AddGreen(7, 2);
            AddYellow(8, 2);
            AddBrick(10, 2);
            AddBrick(13, 2);
            AddYellow(3, 3);
            AddYellow(6, 3);
            AddGreen(7, 3);
            AddYellow(8, 3);
            AddBrick(10, 3);
            AddBrick(13, 3);
            AddYellow(3, 4);
            AddUM(7, 4);
            AddBrick(11, 4);
            AddBrick(12, 4);
            AddBlue(1, 6);
            AddBlue(5, 6);
            AddYellow(7, 6);
            AddYellow(9, 6);
            AddYellow(12, 6);
            AddBlue(1, 7);
            AddBlue(3, 7);
            AddBlue(5, 7);
            AddYellow(7, 7);
            AddYellow(9, 7);
            AddGreen(10, 7);
            AddYellow(12, 7);
            AddBlue(2, 8);
            AddBlue(3, 8);
            AddBlue(4, 8);
            AddYellow(7, 8);
            AddYellow(9, 8);
            AddGreen(11, 8);
            AddYellow(12, 8);
            AddBlue(2, 9);
            AddBlue(4, 9);
            AddYellow(9, 9);
            AddYellow(12, 9);
            
            player.prevX = player.X;
            player.prevY = player.Y;
            player.Y = 9;
            player.vector.Y = player.Y * ((int)(30 * 1.3));
        }

        private void AddBlock1(int x, int y)
        {
            Block1 b1 = new Block1();
            b1.vector.X = (b1.X = x) * ((int)(30 * 1.3));
            b1.vector.Y = (b1.Y = y) * ((int)(30 * 1.3));
            block1s.Add(b1);
        }

        private void AddBlock2(int x, int y)
        {
            Block2 b2 = new Block2();
            b2.vector.X = (b2.X = x) * ((int)(30 * 1.3));
            b2.vector.Y = (b2.Y = y) * ((int)(30 * 1.3));
            block2s.Add(b2);
        }
        
        private void AddUZ(int x, int y)
        {
            UpZapp uz = new UpZapp();
            uz.vector.X = (uz.X = x) * ((int)(30 * 1.3));
            uz.vector.Y = (uz.Y = y) * ((int)(30 * 1.3));
            upzapps.Add(uz);
        }
        
        private void AddDZ(int x, int y)
        {
            DownZapp dz = new DownZapp();
            dz.vector.X = (dz.X = x) * ((int)(30 * 1.3));
            dz.vector.Y = (dz.Y = y) * ((int)(30 * 1.3));
            downzapps.Add(dz);
        }
        
        private void AddLZ(int x, int y)
        {
            LeftZapp lz = new LeftZapp();
            lz.vector.X = (lz.X = x) * ((int)(30 * 1.3));
            lz.vector.Y = (lz.Y = y) * ((int)(30 * 1.3));
            leftzapps.Add(lz);
        }

        private void AddRZ(int x, int y)
        {
            RightZapp rz = new RightZapp();
            rz.vector.X = (rz.X = x) * ((int)(30 * 1.3));
            rz.vector.Y = (rz.Y = y) * ((int)(30 * 1.3));
            rightzapps.Add(rz);
        }
        
        private void AddLM(int x, int y)
        {
            LeftMover lm = new LeftMover();
            lm.vector.X = (lm.X = x) *((int)(30*1.3));
            lm.vector.Y = (lm.Y = y) *((int)(30*1.3));
            leftmovers.Add(lm);
        }

        private void AddRM(int x, int y)
        {
            RightMover rm = new RightMover();
            rm.vector.X = (rm.X = x) *((int)(30*1.3));
            rm.vector.Y = (rm.Y = y) *((int)(30*1.3));
            rightmovers.Add(rm);
        }

        private void AddDM(int x, int y)
        {
            DownMover dm = new DownMover();
            dm.vector.X = (dm.X = x) *((int)(30*1.3));
            dm.vector.Y = (dm.Y = y) *((int)(30*1.3));
            downmovers.Add(dm);
        }

        private void AddUM(int x, int y)
        {
            UpMover um = new UpMover();
            um.vector.X = (um.X = x) * ((int)(30 * 1.3));
            um.vector.Y = (um.Y = y) * ((int)(30 * 1.3));
            upmovers.Add(um);
        }

        private void AddBrick(int x, int y)
        {
            Brick brick = new Brick();
            brick.vector.X = (brick.X = x) *((int)(30*1.3));
            brick.vector.Y = (brick.Y = y) *((int)(30*1.3));
            bricks.Add(brick);
        }

        private void AddGreen(int x, int y)
        {
            Green green = new Green();
            green.vector.X = (green.X = x) *((int)(30*1.3));
            green.vector.Y = (green.Y = y) *((int)(30*1.3));
            greens.Add(green);
        }

        private void AddYellow(int x, int y)
        {
            Yellow yellow = new Yellow();
            yellow.vector.X = (yellow.X = x) *((int)(30*1.3));
            yellow.vector.Y = (yellow.Y = y) *((int)(30*1.3));
            yellows.Add(yellow);
        }

        private void AddBlue(int x, int y)
        {
            Blue blue = new Blue();
            blue.vector.X = (blue.X = x) *((int)(30*1.3));
            blue.vector.Y = (blue.Y = y) *((int)(30*1.3));
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
            else if (currentLevel == 5 && loadlevel == true)
            {
                Level5();
                loadlevel = false;
            }
            else if (currentLevel == 6 && loadlevel == true)
            {
                Level6();
                loadlevel = false;
            }
            else if (currentLevel == 7 && loadlevel == true)
            {
                Level7();
                loadlevel = false;
            }
            else if (currentLevel == 8 && loadlevel == true)
            {
                Level8();
                loadlevel = false;
            }
            else if (currentLevel == 9 && loadlevel == true)
            {
                Level9();
                loadlevel = false;
            }
            else if (currentLevel == 10 && loadlevel == true)
            {
                Level10();
                loadlevel = false;
            }
            else if (currentLevel == 11 && loadlevel == true)
            {
                Level11();
                loadlevel = false;
            }
            else if (currentLevel == 12 && loadlevel == true)
            {
                Level12();
                loadlevel = false;
            }
            else if (currentLevel == 13 && loadlevel == true)
            {
                Level13();
                loadlevel = false;
            }
            else if (currentLevel == 14 && loadlevel == true)
            {
                Level14();
                loadlevel = false;
            }
            else if (currentLevel == 15 && loadlevel == true)
            {
                Level15();
                loadlevel = false;
            }
            else if (currentLevel == 16 && loadlevel == true)
            {
                Level16();
                loadlevel = false;
            }
            else if (currentLevel == 17 && loadlevel == true)
            {
                Level17();
                loadlevel = false;
            }

            background.Update(gameTime.ElapsedGameTime.Ticks);

            brick.Update(gameTime.ElapsedGameTime.Ticks);

            green.Update(gameTime.ElapsedGameTime.Ticks);

            yellow.Update(gameTime.ElapsedGameTime.Ticks);

            blue.Update(gameTime.ElapsedGameTime.Ticks);

            // Before handling input
            _currentKeyboardState = Keyboard.GetState();

            if (_currentKeyboardState.IsKeyDown(Keys.F) &&
               _previousKeyboardState.IsKeyUp(Keys.F))
            {
                graphics.ToggleFullScreen();
            }

            if (_currentKeyboardState.IsKeyDown(Keys.Up) &&
               _previousKeyboardState.IsKeyUp(Keys.Up))
            {
                bool cnt = false;
                for (int i = 0; i < block1s.Count; i++)
                {
                    if (block1s[i].X == player.X && block1s[i].Y == player.Y - 1)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < downzapps.Count; i++)
                {
                    if (downzapps[i].X == player.X && downzapps[i].Y == player.Y - 1)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < leftzapps.Count; i++)
                {
                    if (leftzapps[i].X == player.X && leftzapps[i].Y == player.Y - 1)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < rightzapps.Count; i++)
                {
                    if (rightzapps[i].X == player.X && rightzapps[i].Y == player.Y - 1)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < blues.Count; i++)
                {
                    if (blues[i].X == player.X && blues[i].Y == player.Y - 1)
                    {
                        cnt = true;
                    }
                }
                bool ispushed = false;
                bool stuck = false;
                for (int i = 0; i < upzapps.Count; i++)
                {
                    if (upzapps[i].X == player.X && upzapps[i].Y == player.Y - 1)
                    {
                        player.Y -= 1;
                        player.vector.Y = player.Y * 39;
                        stuck = false;
                    }
                }
                for (int i = 0; i < greens.Count; i++)
                {
                    if (greens[i].X == player.X && greens[i].Y == player.Y - 1)
                    {
                        ispushed = pushGreen(greens[i], 0, -1);
                        if (ispushed)
                        {
                            if(greens[i].Y > 0)
                                greens[i].Y -= 1;
                            greens[i].vector.Y = greens[i].Y *((int)(30*1.3));
                        }
                        else
                        {
                            stuck = true;
                        }
                    }
                }
                for (int i = 0; i < yellows.Count; i++)
                {
                    if (yellows[i].X == player.X && yellows[i].Y == player.Y - 1)
                    {
                        ispushed = pushYellow(yellows[i], -1);
                        if (ispushed)
                        {
                            if(yellows[i].Y > 0)
                                yellows[i].Y -= 1;
                            yellows[i].vector.Y = yellows[i].Y *((int)(30*1.3));
                        }
                        else
                        {
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
                    if (!stuck)
                    {
                        player.prevX = player.X;
                        player.prevY = player.Y;
                        player.Y--;
                        player.vector.Y -= ((int)(30 * 1.3));
                    }
                }
            }
            if (_currentKeyboardState.IsKeyDown(Keys.Down) &&
               _previousKeyboardState.IsKeyUp(Keys.Down))
            {
                bool ispushed = false;
                bool stuck = false;
                bool cnt = false;
                for (int i = 0; i < block1s.Count; i++)
                {
                    if (block1s[i].X == player.X && block1s[i].Y == player.Y + 1)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < upzapps.Count; i++)
                {
                    if (upzapps[i].X == player.X && upzapps[i].Y == player.Y + 1)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < leftzapps.Count; i++)
                {
                    if (leftzapps[i].X == player.X && leftzapps[i].Y == player.Y + 1)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < rightzapps.Count; i++)
                {
                    if (rightzapps[i].X == player.X && rightzapps[i].Y == player.Y + 1)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < blues.Count; i++)
                {
                    if (blues[i].X == player.X && blues[i].Y == player.Y + 1)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < downzapps.Count; i++)
                {
                    if (downzapps[i].X == player.X && downzapps[i].Y == player.Y + 1)
                    {
                        bool inc = true;
                        for (int j = 0; j < greens.Count; j++)
                        {
                            if (greens[j].X == player.X && greens[j].Y == player.Y + 2)
                                inc = false;
                        }
                        if (inc)
                            player.Y += 1;
                        else
                            cnt = true;
                        player.vector.Y = player.Y * 39;
                        stuck = false;
                    }
                }
                for (int i = 0; i < greens.Count; i++)
                {
                    if (greens[i].X == player.X && greens[i].Y == player.Y + 1)
                    {
                        ispushed = pushGreen(greens[i], 0, 1);
                        if (ispushed)
                        {
                            if(greens[i].Y < 9)
                                greens[i].Y += 1;
                            greens[i].vector.Y = greens[i].Y *((int)(30*1.3));
                        }
                        else
                        {
                            stuck = true;
                        }
                    }
                }
                for (int i = 0; i < yellows.Count; i++)
                {
                    if (yellows[i].X == player.X && yellows[i].Y == player.Y + 1)
                    {
                        ispushed = pushYellow(yellows[i], 1);
                        if (ispushed)
                        {
                            if(yellows[i].Y < 9)
                                yellows[i].Y += 1;
                            yellows[i].vector.Y = yellows[i].Y *((int)(30*1.3));
                        }
                        else
                        {
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
                    if (!stuck)
                    {
                        player.prevX = player.X;
                        player.prevY = player.Y;
                        player.Y++;
                        player.vector.Y += ((int)(30 * 1.3));
                    }
                }
            }
            if (_currentKeyboardState.IsKeyDown(Keys.Left) &&
               _previousKeyboardState.IsKeyUp(Keys.Left))
            {
                bool ispushed = false;
                bool stuck = false;
                bool cnt = false;
                for (int i = 0; i < block1s.Count; i++)
                {
                    if (block1s[i].X == player.X - 1 && block1s[i].Y == player.Y)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < upzapps.Count; i++)
                {
                    if (upzapps[i].X == player.X - 1 && upzapps[i].Y == player.Y)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < downzapps.Count; i++)
                {
                    if (downzapps[i].X == player.X - 1 && downzapps[i].Y == player.Y)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < rightzapps.Count; i++)
                {
                    if (rightzapps[i].X == player.X - 1 && rightzapps[i].Y == player.Y)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < yellows.Count; i++)
                {
                    if (yellows[i].X == player.X - 1 && yellows[i].Y == player.Y)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < leftzapps.Count; i++)
                {
                    if (leftzapps[i].X == player.X - 1 && leftzapps[i].Y == player.Y)
                    {
                        player.X -= 1;
                        player.vector.X = player.X * 39;
                        stuck = false;
                    }
                }
                for (int i = 0; i < greens.Count; i++)
                {
                    if (greens[i].X == player.X - 1 && greens[i].Y == player.Y)
                    {
                        ispushed = pushGreen(greens[i], -1, 0);
                        if (ispushed)
                        {
                            if(greens[i].X > 0)
                                greens[i].X -= 1;
                            greens[i].vector.X = greens[i].X *((int)(30*1.3));
                        }
                        else
                        {
                            stuck = true;
                        }
                    }
                }
                for (int i = 0; i < blues.Count; i++)
                {
                    if (blues[i].X == player.X - 1 && blues[i].Y == player.Y)
                    {
                        ispushed = pushBlue(blues[i], -1);
                        if (ispushed)
                        {
                            if(blues[i].X > 0)
                                blues[i].X -= 1;
                            blues[i].vector.X = blues[i].X *((int)(30*1.3));
                        }
                        else
                        {
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
                    if (!stuck)
                    {
                        player.prevX = player.X;
                        player.prevY = player.Y;
                        player.X--;
                        player.vector.X -= ((int)(30 * 1.3));
                    }
                }
            }
            if (_currentKeyboardState.IsKeyDown(Keys.Right) &&
               _previousKeyboardState.IsKeyUp(Keys.Right))
            {
                bool ispushed = false;
                bool stuck = false;
                bool cnt = false;
                for (int i = 0; i < block1s.Count; i++)
                {
                    if (block1s[i].X == player.X + 1 && block1s[i].Y == player.Y)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < upzapps.Count; i++)
                {
                    if (upzapps[i].X == player.X + 1 && upzapps[i].Y == player.Y)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < downzapps.Count; i++)
                {
                    if (downzapps[i].X == player.X + 1 && downzapps[i].Y == player.Y)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < leftzapps.Count; i++)
                {
                    if (leftzapps[i].X == player.X + 1 && leftzapps[i].Y == player.Y)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < yellows.Count; i++)
                {
                    if (yellows[i].X == player.X + 1 && yellows[i].Y == player.Y)
                    {
                        cnt = true;
                    }
                }
                for (int i = 0; i < rightzapps.Count; i++)
                {
                    if (rightzapps[i].X == player.X + 1 && rightzapps[i].Y == player.Y)
                    {
                        player.X += 1;
                        player.vector.X = player.X * 39;
                    }
                }
                for (int i = 0; i < greens.Count; i++)
                {
                    if (greens[i].X == player.X + 1 && greens[i].Y == player.Y)
                    {
                        ispushed = pushGreen(greens[i], 1, 0);
                        if (ispushed)
                        {
                            if(greens[i].X < 14)
                                greens[i].X += 1;
                            greens[i].vector.X = greens[i].X *((int)(30*1.3));
                        }
                        else
                        {
                            stuck = true;
                        }
                    }
                }
                for (int i = 0; i < blues.Count; i++)
                {
                    if (blues[i].X == player.X + 1 && blues[i].Y == player.Y)
                    {
                        ispushed = pushBlue(blues[i], 1);
                        if (ispushed)
                        {
                            if(blues[i].X < 14)
                                blues[i].X += 1;
                            blues[i].vector.X = blues[i].X *((int)(30*1.3));
                        }
                        else
                        {
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
                    if (!stuck)
                    {
                        player.prevX = player.X;
                        player.prevY = player.Y;
                        player.X++;
                        player.vector.X += ((int)(30 * 1.3));
                    }
                }
            }
            if (_currentKeyboardState.IsKeyUp(Keys.Up) &&
                _currentKeyboardState.IsKeyUp(Keys.Down) &&
                _currentKeyboardState.IsKeyUp(Keys.Left) &&
                _currentKeyboardState.IsKeyUp(Keys.Right))
            {
                if (downmovers.Count > 0)
                {
                    for (int i = 0; i < downmovers.Count; i++)
                    {
                        bool ispushe = false;
                        bool stuc = false;
                        ispushe = pushDM(player, downmovers[i], 0, 1);
                        if (ispushe)
                        {
                            if (downmovers[i].Y < 9)
                            {
                                downmovers[i].Y += 1;
                                if (player.X == downmovers[i].X && player.Y == downmovers[i].Y)
                                {
                                    downmovers[i].Y -= 1;
                                }
                            }
                            downmovers[i].vector.Y = downmovers[i].Y * ((int)(30 * 1.3));
                        }
                    }
                }
                if (upmovers.Count > 0)
                {
                    for (int i = 0; i < upmovers.Count; i++)
                    {
                        bool ispushe = false;
                        bool stuc = false;
                        ispushe = pushUM(player, upmovers[i], 0, -1);
                        if (ispushe)
                        {
                            if (upmovers[i].Y > 0)
                            {
                                upmovers[i].Y -= 1;
                                if (player.X == upmovers[i].X && player.Y == upmovers[i].Y)
                                {
                                    upmovers[i].Y += 1;
                                }
                            }
                            upmovers[i].vector.Y = upmovers[i].Y * ((int)(30 * 1.3));
                        }
                    }
                }
                if (leftmovers.Count > 0)
                {
                    for (int i = 0; i < leftmovers.Count; i++)
                    {
                        bool ispushe = false;
                        bool stuc = false;
                        ispushe = pushLM(player, leftmovers[i], -1, 0);
                        if (ispushe)
                        {
                            if (leftmovers[i].X > 0)
                            {
                                leftmovers[i].X -= 1;
                                if (player.X == leftmovers[i].X && player.Y == leftmovers[i].Y)
                                {
                                    leftmovers[i].X += 1;
                                }
                            }
                            leftmovers[i].vector.X = leftmovers[i].X * ((int)(30 * 1.3));
                        }
                    }
                }
                if (rightmovers.Count > 0)
                {
                    for (int i = 0; i < rightmovers.Count; i++)
                    {
                        bool ispushe = false;
                        bool stuc = false;
                        ispushe = pushRM(player, rightmovers[i], 1, 0);
                        if (ispushe)
                        {
                            if (rightmovers[i].X < 14)
                            {
                                rightmovers[i].X += 1;
                                if (player.X == rightmovers[i].X && player.Y == rightmovers[i].Y)
                                {
                                    rightmovers[0].X -= 1;
                                }
                            }
                            rightmovers[i].vector.X = rightmovers[i].X * ((int)(30 * 1.3));
                        }
                    }
                }
            }

            for (int i = 0; i < greens.Count; i++)
            {
                if (player.X == greens[i].X && player.Y == greens[i].Y)
                {
                    player.X = player.prevX;
                    player.Y = player.prevY;
                    player.vector.X = player.X * 39;
                    player.vector.Y = player.Y * 39;
                }
            }

            for (int i = 0; i < yellows.Count; i++)
            {
                if (player.X == yellows[i].X && player.Y == yellows[i].Y)
                {
                    player.X = player.prevX;
                    player.Y = player.prevY;
                    player.vector.X = player.X * 39;
                    player.vector.Y = player.Y * 39;
                }
            }

            for (int i = 0; i < blues.Count; i++)
            {
                if (player.X == blues[i].X && player.Y == blues[i].Y)
                {
                    player.X = player.prevX;
                    player.Y = player.prevY;
                    player.vector.X = player.X * 39;
                    player.vector.Y = player.Y * 39;
                }
            }

            for (int i = 0; i < upmovers.Count; i++)
            {
                if (player.X == upmovers[i].X && player.Y == upmovers[i].Y)
                {
                    player.X = player.prevX;
                    player.Y = player.prevY;
                    player.vector.X = player.X * 39;
                    player.vector.Y = player.Y * 39;
                }
            }

            for (int i = 0; i < downmovers.Count; i++)
            {
                if (player.X == downmovers[i].X && player.Y == downmovers[i].Y)
                {
                    player.X = player.prevX;
                    player.Y = player.prevY;
                    player.vector.X = player.X * 39;
                    player.vector.Y = player.Y * 39;
                }
            }

            for (int i = 0; i < leftmovers.Count; i++)
            {
                if (player.X == leftmovers[i].X && player.Y == leftmovers[i].Y)
                {
                    player.X = player.prevX;
                    player.Y = player.prevY;
                    player.vector.X = player.X * 39;
                    player.vector.Y = player.Y * 39;
                }
            }

            for (int i = 0; i < rightmovers.Count; i++)
            {
                if (player.X == rightmovers[i].X && player.Y == rightmovers[i].Y)
                {
                    player.X = player.prevX;
                    player.Y = player.prevY;
                    player.vector.X = player.X * 39;
                    player.vector.Y = player.Y * 39;
                }
            }

            if (_currentKeyboardState.IsKeyDown(Keys.R) && 
                _previousKeyboardState.IsKeyUp(Keys.R) && 
                cheat && 
                attempts > 0)
            {
                if(currentLevel == 1)
                    Level1();
                if (currentLevel == 2)
                    Level2();
                if (currentLevel == 3)
                    Level3();
                if (currentLevel == 4)
                    Level4();
                if (currentLevel == 5)
                    Level5();
                if (currentLevel == 6)
                    Level6();
                if (currentLevel == 7)
                    Level7();
                if (currentLevel == 8)
                    Level8();
                if (currentLevel == 9)
                    Level9();
                if (currentLevel == 10)
                    Level10();
                if (currentLevel == 11)
                    Level11();
                if (currentLevel == 12)
                    Level12();
                if (currentLevel == 13)
                    Level13();
                if (currentLevel == 14)
                    Level14();
                if (currentLevel == 15)
                    Level15();
                if (currentLevel == 16)
                    Level16();
                if (currentLevel == 17)
                    Level17();

                attempts--;

                player.X = 7;
                player.Y = 9;
                player.vector.X = player.X * 39;
                player.vector.Y = player.Y * 39;
            }

            // After handling input
            _previousKeyboardState = _currentKeyboardState;

            if (!(player.X == 7 && player.Y == -1))
            {
                if (player.X < 0 || player.X > 14 || player.Y < 0 || player.Y > 9)
                {
                    player.X = player.prevX;
                    player.Y = player.prevY;
                    player.vector.X = player.X *((int)(30*1.3));
                    player.vector.Y = player.Y *((int)(30*1.3));
                }
            }

            if (player.X == 7 && player.Y == -1 && currentLevel < 18)
            {
                currentLevel = currentLevel + 1;
                loadlevel = true;
                if (currentLevel == 18)
                    drawwin = true;
            }
            else
            {
                drawwin = false;
            }

            if (currentLevel == 18)
            {
                player.X = 7;
                player.Y = -1;
                
                player.vector.X = player.X * 39;
                player.vector.Y = player.Y * 39;

                drawwin = true;
            }

            base.Update(gameTime);
        }

        public Boolean pushRM(Circle player, Shape shp, int x, int y)
        {
            Boolean ispushed = true;
            for (int i = 0; i < upzapps.Count; i++)
            {
                if (shp.X + x == upzapps[i].X && shp.Y + y == upzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < downzapps.Count; i++)
            {
                if (shp.X + x == downzapps[i].X && shp.Y + y == downzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < leftzapps.Count; i++)
            {
                if (shp.X + x == leftzapps[i].X && shp.Y + y == leftzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < rightzapps.Count; i++)
            {
                if (shp.X + x == rightzapps[i].X && shp.Y + y == rightzapps[i].Y)
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
            for (int i = 0; i < downmovers.Count; i++)
            {
                if (shp.X + x == downmovers[i].X && shp.Y + y == downmovers[i].Y)
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
            if (shp.X + x == player.X && shp.Y + y == player.Y)
            {
                ispushed = false;
                return ispushed;
            }
            for (int i = 0; i < rightmovers.Count; i++)
            {
                if (shp.X + x == rightmovers[i].X && shp.Y + y == rightmovers[i].Y)
                {
                    ispushed = pushRM(player, rightmovers[i], x, y);
                    if (ispushed)
                    {
                        if (rightmovers[i].X > 0 && rightmovers[i].X < 14)
                            rightmovers[i].X += x;
                        else
                            if (rightmovers[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (rightmovers[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (rightmovers[i].Y > 0 && rightmovers[i].Y < 9)
                            rightmovers[i].Y += y;
                        else
                            if (rightmovers[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (rightmovers[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        rightmovers[i].vector.X = rightmovers[i].X *((int)(30*1.3));
                        rightmovers[i].vector.Y = rightmovers[i].Y *((int)(30*1.3));
                        return ispushed;
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
                        greens[i].vector.X = greens[i].X * ((int)(30 * 1.3));
                        greens[i].vector.Y = greens[i].Y * ((int)(30 * 1.3));
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
                            if (blues[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (blues[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        blues[i].vector.X = blues[i].X * ((int)(30 * 1.3));
                        return ispushed;
                    }
                }
            }
            return ispushed;
        }

        public Boolean pushBlock1(Circle player, Shape shp, int x, int y)
        {
            Boolean ispushed = true;
            for (int i = 0; i < upzapps.Count; i++)
            {
                if (shp.X + x == upzapps[i].X && shp.Y + y == upzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < downzapps.Count; i++)
            {
                if (shp.X + x == downzapps[i].X && shp.Y + y == downzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < leftzapps.Count; i++)
            {
                if (shp.X + x == leftzapps[i].X && shp.Y + y == leftzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < rightzapps.Count; i++)
            {
                if (shp.X + x == rightzapps[i].X && shp.Y + y == rightzapps[i].Y)
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
            if (shp.X + x == player.X && shp.Y + y == player.Y)
            {
                ispushed = false;
                return ispushed;
            }
            for (int i = 0; i < block1s.Count; i++)
            {
                if (shp.X + x == block1s[i].X && shp.Y + y == block1s[i].Y)
                {
                    ispushed = pushBlock1(player, block1s[i], x, y);
                    if (ispushed)
                    {
                        if (block1s[i].X > 0 && block1s[i].X < 14)
                            block1s[i].X += x;
                        else
                            if (block1s[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block1s[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (block1s[i].Y > 0 && block1s[i].Y < 9)
                            block1s[i].Y += y;
                        else
                            if (block1s[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block1s[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        block1s[i].vector.X = block1s[i].X * ((int)(30 * 1.3));
                        block1s[i].vector.Y = block1s[i].Y * ((int)(30 * 1.3));
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < block2s.Count; i++)
            {
                if (shp.X + x == block2s[i].X && shp.Y + y == block2s[i].Y)
                {
                    ispushed = pushBlock2(player, block2s[i], x, y);
                    if (ispushed)
                    {
                        if (block2s[i].X > 0 && block2s[i].X < 14)
                            block2s[i].X += x;
                        else
                            if (block2s[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block2s[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (block2s[i].Y > 0 && block2s[i].Y < 9)
                            block2s[i].Y += y;
                        else
                            if (block2s[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block2s[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        block2s[i].vector.X = block2s[i].X * ((int)(30 * 1.3));
                        block2s[i].vector.Y = block2s[i].Y * ((int)(30 * 1.3));
                        return ispushed;
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
                        greens[i].vector.X = greens[i].X * ((int)(30 * 1.3));
                        greens[i].vector.Y = greens[i].Y * ((int)(30 * 1.3));
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
                            if (blues[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (blues[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        blues[i].vector.X = blues[i].X * ((int)(30 * 1.3));
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
                            if (yellows[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (yellows[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        yellows[i].vector.Y = yellows[i].Y * ((int)(30 * 1.3));
                        return ispushed;
                    }
                }
            }
            return ispushed;
        }

        public Boolean pushBlock2(Circle player, Shape shp, int x, int y)
        {
            Boolean ispushed = true;
            for (int i = 0; i < upzapps.Count; i++)
            {
                if (shp.X + x == upzapps[i].X && shp.Y + y == upzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < downzapps.Count; i++)
            {
                if (shp.X + x == downzapps[i].X && shp.Y + y == downzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < leftzapps.Count; i++)
            {
                if (shp.X + x == leftzapps[i].X && shp.Y + y == leftzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < rightzapps.Count; i++)
            {
                if (shp.X + x == rightzapps[i].X && shp.Y + y == rightzapps[i].Y)
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
            if (shp.X + x == player.X && shp.Y + y == player.Y)
            {
                ispushed = false;
                return ispushed;
            }
            for (int i = 0; i < block1s.Count; i++)
            {
                if (shp.X + x == block1s[i].X && shp.Y + y == block1s[i].Y)
                {
                    ispushed = pushBlock1(player, block1s[i], x, y);
                    if (ispushed)
                    {
                        if (block1s[i].X > 0 && block1s[i].X < 14)
                            block1s[i].X += x;
                        else
                            if (block1s[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block1s[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (block1s[i].Y > 0 && block1s[i].Y < 9)
                            block1s[i].Y += y;
                        else
                            if (block1s[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block1s[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        block1s[i].vector.X = block1s[i].X * ((int)(30 * 1.3));
                        block1s[i].vector.Y = block1s[i].Y * ((int)(30 * 1.3));
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < block2s.Count; i++)
            {
                if (shp.X + x == block2s[i].X && shp.Y + y == block2s[i].Y)
                {
                    ispushed = pushBlock2(player, block2s[i], x, y);
                    if (ispushed)
                    {
                        if (block2s[i].X > 0 && block2s[i].X < 14)
                            block2s[i].X += x;
                        else
                            if (block2s[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block2s[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (block2s[i].Y > 0 && block2s[i].Y < 9)
                            block2s[i].Y += y;
                        else
                            if (block2s[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block2s[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        block2s[i].vector.X = block2s[i].X * ((int)(30 * 1.3));
                        block2s[i].vector.Y = block2s[i].Y * ((int)(30 * 1.3));
                        return ispushed;
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
                        greens[i].vector.X = greens[i].X * ((int)(30 * 1.3));
                        greens[i].vector.Y = greens[i].Y * ((int)(30 * 1.3));
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
                            if (blues[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (blues[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        blues[i].vector.X = blues[i].X * ((int)(30 * 1.3));
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
                            if (yellows[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (yellows[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        yellows[i].vector.Y = yellows[i].Y * ((int)(30 * 1.3));
                        return ispushed;
                    }
                }
            }
            return ispushed;
        }
        
        public Boolean pushDM(Circle player, Shape shp, int x, int y)
        {
            Boolean ispushed = true;
            for (int i = 0; i < upmovers.Count; i++)
            {
                if (shp.X + x == upmovers[i].X && shp.Y + y == upmovers[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < upzapps.Count; i++)
            {
                if (shp.X + x == upzapps[i].X && shp.Y + y == upzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < downzapps.Count; i++)
            {
                if (shp.X + x == downzapps[i].X && shp.Y + y == downzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < leftzapps.Count; i++)
            {
                if (shp.X + x == leftzapps[i].X && shp.Y + y == leftzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < rightzapps.Count; i++)
            {
                if (shp.X + x == rightzapps[i].X && shp.Y + y == rightzapps[i].Y)
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
            for (int i = 0; i < downmovers.Count; i++)
            {
                if (shp.X + x == downmovers[i].X && shp.Y + y == downmovers[i].Y)
                {
                    ispushed = pushGreen(downmovers[i], x, y);
                    if (ispushed)
                    {
                        if (downmovers[i].X > 0 && downmovers[i].X < 14)
                            downmovers[i].X += x;
                        else
                            if (downmovers[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (downmovers[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (downmovers[i].Y > 0 && downmovers[i].Y < 9)
                            downmovers[i].Y += y;
                        else
                            if (downmovers[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (downmovers[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        downmovers[i].vector.X = downmovers[i].X *((int)(30*1.3));
                        downmovers[i].vector.Y = downmovers[i].Y *((int)(30*1.3));
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < block1s.Count; i++)
            {
                if (shp.X + x == block1s[i].X && shp.Y + y == block1s[i].Y)
                {
                    ispushed = pushBlock1(player, block1s[i], x, y);
                    if (ispushed)
                    {
                        if (block1s[i].X > 0 && block1s[i].X < 14)
                            block1s[i].X += x;
                        else
                            if (block1s[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block1s[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (block1s[i].Y > 0 && block1s[i].Y < 9)
                            block1s[i].Y += y;
                        else
                            if (block1s[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block1s[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        block1s[i].vector.X = block1s[i].X * ((int)(30 * 1.3));
                        block1s[i].vector.Y = block1s[i].Y * ((int)(30 * 1.3));
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < block2s.Count; i++)
            {
                if (shp.X + x == block2s[i].X && shp.Y + y == block2s[i].Y)
                {
                    ispushed = pushBlock2(player, block2s[i], x, y);
                    if (ispushed)
                    {
                        if (block2s[i].X > 0 && block2s[i].X < 14)
                            block2s[i].X += x;
                        else
                            if (block2s[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block2s[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (block2s[i].Y > 0 && block2s[i].Y < 9)
                            block2s[i].Y += y;
                        else
                            if (block2s[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block2s[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        block2s[i].vector.X = block2s[i].X * ((int)(30 * 1.3));
                        block2s[i].vector.Y = block2s[i].Y * ((int)(30 * 1.3));
                        return ispushed;
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
                        greens[i].vector.X = greens[i].X * ((int)(30 * 1.3));
                        greens[i].vector.Y = greens[i].Y * ((int)(30 * 1.3));
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
                            if (yellows[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (yellows[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        yellows[i].vector.Y = yellows[i].Y * ((int)(30 * 1.3));
                        return ispushed;
                    }
                }
            }
            return ispushed;
        }

        public Boolean pushUM(Circle player, Shape shp, int x, int y)
        {
            Boolean ispushed = true;
            for (int i = 0; i < downmovers.Count; i++)
            {
                if (shp.X + x == downmovers[i].X && shp.Y + y == downmovers[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < upzapps.Count; i++)
            {
                if (shp.X + x == upzapps[i].X && shp.Y + y == upzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < downzapps.Count; i++)
            {
                if (shp.X + x == downzapps[i].X && shp.Y + y == downzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < leftzapps.Count; i++)
            {
                if (shp.X + x == leftzapps[i].X && shp.Y + y == leftzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < rightzapps.Count; i++)
            {
                if (shp.X + x == rightzapps[i].X && shp.Y + y == rightzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < upmovers.Count; i++)
            {
                if (shp.X + x == upmovers[i].X && shp.Y + y == upmovers[i].Y)
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
            for (int i = 0; i < block1s.Count; i++)
            {
                if (shp.X + x == block1s[i].X && shp.Y + y == block1s[i].Y)
                {
                    ispushed = pushBlock1(player, block1s[i], x, y);
                    if (ispushed)
                    {
                        if (block1s[i].X > 0 && block1s[i].X < 14)
                            block1s[i].X += x;
                        else
                            if (block1s[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block1s[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (block1s[i].Y > 0 && block1s[i].Y < 9)
                            block1s[i].Y += y;
                        else
                            if (block1s[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block1s[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        block1s[i].vector.X = block1s[i].X * ((int)(30 * 1.3));
                        block1s[i].vector.Y = block1s[i].Y * ((int)(30 * 1.3));
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < block2s.Count; i++)
            {
                if (shp.X + x == block2s[i].X && shp.Y + y == block2s[i].Y)
                {
                    ispushed = pushBlock2(player, block2s[i], x, y);
                    if (ispushed)
                    {
                        if (block2s[i].X > 0 && block2s[i].X < 14)
                            block2s[i].X += x;
                        else
                            if (block2s[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block2s[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (block2s[i].Y > 0 && block2s[i].Y < 9)
                            block2s[i].Y += y;
                        else
                            if (block2s[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block2s[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        block2s[i].vector.X = block2s[i].X * ((int)(30 * 1.3));
                        block2s[i].vector.Y = block2s[i].Y * ((int)(30 * 1.3));
                        return ispushed;
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
                        greens[i].vector.X = greens[i].X * ((int)(30 * 1.3));
                        greens[i].vector.Y = greens[i].Y * ((int)(30 * 1.3));
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
                            if (yellows[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (yellows[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        yellows[i].vector.Y = yellows[i].Y * ((int)(30 * 1.3));
                        return ispushed;
                    }
                }
            }
            return ispushed;
        }

        public Boolean pushLM(Circle player, Shape shp, int x, int y)
        {
            Boolean ispushed = true;
            for (int i = 0; i < upzapps.Count; i++)
            {
                if (shp.X + x == upzapps[i].X && shp.Y + y == upzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < downzapps.Count; i++)
            {
                if (shp.X + x == downzapps[i].X && shp.Y + y == downzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < leftzapps.Count; i++)
            {
                if (shp.X + x == leftzapps[i].X && shp.Y + y == leftzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < rightzapps.Count; i++)
            {
                if (shp.X + x == rightzapps[i].X && shp.Y + y == rightzapps[i].Y)
                {
                    ispushed = false;
                }
            }
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
                        greens[i].vector.X = greens[i].X *((int)(30*1.3));
                        greens[i].vector.Y = greens[i].Y *((int)(30*1.3));
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
                            if (blues[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (blues[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        blues[i].vector.X = blues[i].X * ((int)(30 * 1.3));
                        return ispushed;
                    }
                }
            }
            return ispushed;
        }

        public Boolean pushGreen(Shape shp, int x, int y)
        {
            Boolean ispushed = true;
            for (int i = 0; i < upzapps.Count; i++)
            {
                if (shp.X + x == upzapps[i].X && shp.Y + y == upzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < downzapps.Count; i++)
            {
                if (shp.X + x == downzapps[i].X && shp.Y + y == downzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < leftzapps.Count; i++)
            {
                if (shp.X + x == leftzapps[i].X && shp.Y + y == leftzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < rightzapps.Count; i++)
            {
                if (shp.X + x == rightzapps[i].X && shp.Y + y == rightzapps[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < upmovers.Count; i++)
            {
                if (shp.X + x == upmovers[i].X && shp.Y + y == upmovers[i].Y)
                {
                    ispushed = false;
                }
            }
            for (int i = 0; i < downmovers.Count; i++)
            {
                if (shp.X + x == downmovers[i].X && shp.Y + y == downmovers[i].Y)
                {
                    ispushed = false;
                }
            }
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
            if (shp.X + x == player.X && shp.Y + y == player.Y)
            {
                ispushed = false;
                return ispushed;
            }
            for (int i = 0; i < block1s.Count; i++)
            {
                if (shp.X + x == block1s[i].X && shp.Y + y == block1s[i].Y)
                {
                    ispushed = pushBlock1(player, block1s[i], x, y);
                    if (ispushed)
                    {
                        if (block1s[i].X > 0 && block1s[i].X < 14)
                            block1s[i].X += x;
                        else
                            if (block1s[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block1s[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (block1s[i].Y > 0 && block1s[i].Y < 9)
                            block1s[i].Y += y;
                        else
                            if (block1s[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block1s[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        block1s[i].vector.X = block1s[i].X * ((int)(30 * 1.3));
                        block1s[i].vector.Y = block1s[i].Y * ((int)(30 * 1.3));
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < block2s.Count; i++)
            {
                if (shp.X + x == block2s[i].X && shp.Y + y == block2s[i].Y)
                {
                    ispushed = pushBlock2(player, block2s[i], x, y);
                    if (ispushed)
                    {
                        if (block2s[i].X > 0 && block2s[i].X < 14)
                            block2s[i].X += x;
                        else
                            if (block2s[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block2s[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        if (block2s[i].Y > 0 && block2s[i].Y < 9)
                            block2s[i].Y += y;
                        else
                            if (block2s[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block2s[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        block2s[i].vector.X = block2s[i].X * ((int)(30 * 1.3));
                        block2s[i].vector.Y = block2s[i].Y * ((int)(30 * 1.3));
                        return ispushed;
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
                        greens[i].vector.X = greens[i].X *((int)(30*1.3));
                        greens[i].vector.Y = greens[i].Y *((int)(30*1.3));
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < yellows.Count; i++)
            {
                if (shp.X + x == yellows[i].X && shp.Y + y == yellows[i].Y)
                {
                    if (x != 0 && y == 0)
                    {
                        ispushed = false;
                        return ispushed;
                    }
                    ispushed = pushYellow(yellows[i], y);
                    if (ispushed)
                    {
                        if (yellows[i].Y > 0 && yellows[i].Y < 9)
                            yellows[i].Y += y;
                        else
                            if (yellows[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (yellows[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        yellows[i].vector.Y = yellows[i].Y *((int)(30*1.3));
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < blues.Count; i++)
            {
                if (shp.X + x == blues[i].X && shp.Y + y == blues[i].Y)
                {
                    if (x == 0 && y != 0)
                    {
                        ispushed = false;
                        return ispushed;
                    }
                    ispushed = pushBlue(blues[i], x);
                    if (ispushed)
                    {
                        if (blues[i].X > 0 && blues[i].X < 14)
                            blues[i].X += x;
                        else
                            if (blues[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (blues[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        blues[i].vector.X = blues[i].X *((int)(30*1.3));
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
            if (shp.X == player.X && shp.Y + y == player.Y)
            {
                ispushed = false;
                return ispushed;
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
                            if (yellows[i].Y == 0)
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
                        yellows[i].vector.Y = yellows[i].Y *((int)(30*1.3));
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < block2s.Count; i++)
            {
                if (shp.X == block2s[i].X && shp.Y + y == block2s[i].Y)
                {
                    ispushed = pushBlock2(player, block2s[i], 0, y);
                    if (ispushed)
                    {
                        if (block2s[i].Y > 0 && block2s[i].Y < 9)
                            block2s[i].Y += y;
                        else
                            if (block2s[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block2s[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        block2s[i].vector.Y = block2s[i].Y * ((int)(30 * 1.3));
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < block1s.Count; i++)
            {
                if (shp.X == block1s[i].X && shp.Y + y == block1s[i].Y)
                {
                    ispushed = pushBlock1(player, block1s[i], 0, y);
                    if (ispushed)
                    {
                        if (block1s[i].Y > 0 && block1s[i].Y < 9)
                            block1s[i].Y += y;
                        else
                            if (block1s[i].Y == 0)
                            {
                                if (y < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block1s[i].Y == 9)
                            {
                                if (y > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        block1s[i].vector.Y = block1s[i].Y * ((int)(30 * 1.3));
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
                        greens[i].vector.Y = greens[i].Y * ((int)(30 * 1.3));
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
            if (shp.X + x == player.X && shp.Y == player.Y)
            {
                ispushed = false;
                return ispushed;
            }
            for (int i = 0; i < block2s.Count; i++)
            {
                if (shp.X + x == block2s[i].X && shp.Y == block2s[i].Y)
                {
                    ispushed = pushBlock2(player, block2s[i], x, 0);
                    if (ispushed)
                    {
                        if (block2s[i].X > 0 && block2s[i].X < 14)
                            block2s[i].X += x;
                        else
                            if (block2s[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block2s[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        block2s[i].vector.X = block2s[i].X * ((int)(30 * 1.3));
                        return ispushed;
                    }
                }
            }
            for (int i = 0; i < block1s.Count; i++)
            {
                if (shp.X + x == block1s[i].X && shp.Y == block1s[i].Y)
                {
                    ispushed = pushBlock1(player, block1s[i], x, 0);
                    if (ispushed)
                    {
                        if (block1s[i].X > 0 && block1s[i].X < 14)
                            block1s[i].X += x;
                        else
                            if (block1s[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (block1s[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        block1s[i].vector.X = block1s[i].X * ((int)(30 * 1.3));
                        return ispushed;
                    }
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
                            if (blues[i].X == 0)
                            {
                                if (x < 0)
                                {
                                    ispushed = false;
                                }
                            }
                            else if (blues[i].X == 14)
                            {
                                if (x > 0)
                                {
                                    ispushed = false;
                                }
                            }
                        blues[i].vector.X = blues[i].X *((int)(30*1.3));
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
                        greens[i].vector.X = greens[i].X * ((int)(30 * 1.3));
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
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(background.GetTexture(), new Rectangle(0, 0, 685, 490), Color.White);
            // Create any rectangle you want. Here we'll use the TitleSafeArea for fun.
            Rectangle titleSafeRectangle = new Rectangle(18, 58, 590, 396);
            // Call our method (also defined in this blog-post)
            DrawBorder(titleSafeRectangle, 1, Color.White);
            // Create any rectangle you want. Here we'll use the TitleSafeArea for fun.
            Rectangle exit = new Rectangle(290, 58, 39, 1);
            // Call our method (also defined in this blog-post)
            DrawBorder(exit, 1, Color.Blue);
            Rectangle exitLeft = new Rectangle(289, 0, 1, 58);
            // Call our method (also defined in this blog-post)
            DrawBorder(exitLeft, 1, Color.White);
            Rectangle exitRight = new Rectangle(329, 0, 1, 58);
            // Call our method (also defined in this blog-post)
            DrawBorder(exitRight, 1, Color.White);
            for (int i = 0; i < bricks.Count; i++)
            {
                spriteBatch.Draw(brick.GetTexture(), bricks[i].vector + new Vector2(20, 60), null, Color.Wheat, 0, Vector2.Zero, 0.08f, SpriteEffects.None, 0f);
            }
            for (int i = 0; i < greens.Count; i++)
            {
                spriteBatch.Draw(green.GetTexture(), greens[i].vector + new Vector2(20, 60), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            }
            for (int i = 0; i < blues.Count; i++)
            {
                spriteBatch.Draw(blue.GetTexture(), blues[i].vector + new Vector2(20, 60), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            }
            for (int i = 0; i < yellows.Count; i++)
            {
                spriteBatch.Draw(yellow.GetTexture(), yellows[i].vector + new Vector2(20, 60), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            }
            for (int i = 0; i < downmovers.Count; i++)
            {
                spriteBatch.Draw(downmover, downmovers[i].vector + new Vector2(20, 60), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            }
            for (int i = 0; i < upmovers.Count; i++)
            {
                spriteBatch.Draw(upmover, upmovers[i].vector + new Vector2(20, 60), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            }
            for (int i = 0; i < rightmovers.Count; i++)
            {
                spriteBatch.Draw(rightmover, rightmovers[i].vector + new Vector2(20, 60), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            }
            for (int i = 0; i < leftmovers.Count; i++)
            {
                spriteBatch.Draw(leftmover, leftmovers[i].vector + new Vector2(20, 60), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            }
            for (int i = 0; i < upzapps.Count; i++)
            {
                spriteBatch.Draw(upzapp, upzapps[i].vector + new Vector2(20, 60), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            }
            for (int i = 0; i < downzapps.Count; i++)
            {
                spriteBatch.Draw(downzapp, downzapps[i].vector + new Vector2(20, 60), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            }
            for (int i = 0; i < leftzapps.Count; i++)
            {
                spriteBatch.Draw(leftzapp, leftzapps[i].vector + new Vector2(20, 60), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            }
            for (int i = 0; i < rightzapps.Count; i++)
            {
                spriteBatch.Draw(rightzapp, rightzapps[i].vector + new Vector2(20, 60), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            }
            for (int i = 0; i < block1s.Count; i++)
            {
                spriteBatch.Draw(block1, block1s[i].vector + new Vector2(20, 60), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            }
            for (int i = 0; i < block2s.Count; i++)
            {
                spriteBatch.Draw(block2, block2s[i].vector + new Vector2(20, 60), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            }
            spriteBatch.Draw(circle, player.vector + new Vector2(20, 60), null, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0f);
            if (drawwin)
            {
                spriteBatch.DrawString(spriteFont, "You Won.", new Vector2(0, 0), Color.White);
            }
            else
            {
            }
            spriteBatch.DrawString(cyberFont, "Cyberbox", new Vector2(336, 7), Color.SteelBlue);
            if (!drawwin)
            {
                spriteBatch.DrawString(spriteFont2, "Press 'R' To Retry Level", new Vector2(61, 10), Color.White);
                spriteBatch.DrawString(spriteFont2, "Attempts Remaining: " + attempts, new Vector2(61, 30), Color.White);
            }
            int roomNumberIndex = currentLevel - 1;
            if (currentLevel == 18)
            {
                roomNumberIndex = roomNumberIndex - 1;
            }
            spriteBatch.DrawString(spriteFont2, "Toggle 'F' For Fullscreen", new Vector2(21, 465), Color.White);
            spriteBatch.DrawString(spriteFont3, "Room " + currentLevel + ": " + rooms[roomNumberIndex], new Vector2(250, 465), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Will draw a border (hollow rectangle) of the given 'thicknessOfBorder' (in pixels)
        /// of the specified color.
        ///
        /// By Sean Colombo, from http://bluelinegamestudios.com/blog
        /// </summary>
        /// <param name="rectangleToDraw"></param>
        /// <param name="thicknessOfBorder"></param>
        private void DrawBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {
            // Draw top line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Draw left line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw right line
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder,
                                            rectangleToDraw.Height), borderColor);
            // Draw bottom line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder), borderColor);
        }
    }
}