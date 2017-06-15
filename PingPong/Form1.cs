using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace PingPong
{
    public partial class PONG : Form
    {
        string path = "C:/Users/Noncsi/Documents/Visual Studio 2017/Projects/PingPong/PingPong/highscore.txt";
        string HighScore;
        bool isPaused = false;
        int randomInt;
        public int startPointYBall = 10;
        public int speedLeft = 3;
        public int speedTop = 3;
        public int score;
        public bool GodMode = false; // Press G in Pause mode, and you can move your stick
        SoundPlayer pongSound;

        public PONG()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadRecordFromFile();
            RandomBallXGenerator();
            SetFontAndSound();
            // Stick properties
            Stick.Left = Field.Bottom / 2;
            Stick.Top = Field.Bottom - 50;
            Stick.Width = 250;
            Stick.Height = 20;
            // Ball properties
            Ball.Left = randomInt;
            Ball.Top = startPointYBall;
            Ball.Width = 20;
            Ball.Height = 20;
        }

        void RandomBallXGenerator()
        {
            Random random = new Random();
            this.randomInt = random.Next(0, Field.Width - 30);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // God Mode
            if (e.KeyCode == Keys.G)
                if (GodMode == false) GodMode = true;
                else
                {
                    GodMode = false;
                    GodModeLabel.Hide();
                }

            // Escape
            if (e.KeyCode == Keys.Escape) Close();

            // Pause
            if (e.KeyCode == Keys.Space)
            {
                if (isPaused == false)
                {
                    isPaused = true; // Pause: ON
                    PausedLabel.Show();
                    Time.Stop();
                }
                else
                {
                    isPaused = false;  // Pause: OFF
                    PausedLabel.Hide();
                    Time.Start();
                }
            }
        }

        // Stick mover
        private void Stick_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isPaused)
            {
                if (e.KeyCode == Keys.Left) Stick.Left = Stick.Location.X - 20; // if left key is pressed, move the stick left
                else if (e.KeyCode == Keys.Right) Stick.Left = Stick.Location.X + 20; // if right key is pressed, move the stick right
            }
            if (isPaused && GodMode)
            {
                GodModeLabel.Show();
                if (e.KeyCode == Keys.Left) Stick.Left = Stick.Location.X - 20; // if left key is pressed, move the stick left
                else if (e.KeyCode == Keys.Right) Stick.Left = Stick.Location.X + 20; // if right key is pressed, move the stick right
            }
        }

        // Set custom font and sound
        void SetFontAndSound()
        {
            // Font
            PrivateFontCollection pixelFont = new PrivateFontCollection();
            pixelFont.AddFontFile("C:/Users/Noncsi/Documents/Visual Studio 2017/Projects/PingPong/PingPong/pixel_font.ttf");
            ScoreTable.Font = new System.Drawing.Font(pixelFont.Families[0], 10, FontStyle.Regular);
            PausedLabel.Font = new System.Drawing.Font(pixelFont.Families[0], 30, FontStyle.Regular);
            GodModeLabel.Font = new System.Drawing.Font(pixelFont.Families[0], 10, FontStyle.Regular);
            highScoreLabel.Font = new System.Drawing.Font(pixelFont.Families[0], 10, FontStyle.Regular);
            // Sound
            this.pongSound = new SoundPlayer("C:/Users/Noncsi/Documents/Visual Studio 2017/Projects/PingPong/PingPong/pong.wav");

        }

        void HideLabels()
        {
            GodModeLabel.Hide();
            Cursor.Hide();
            PausedLabel.Hide();
        }

        // The game
        private void Time_Tick(object sender, EventArgs e)
        {
            HideLabels();
            ScoreTable.Text = "SCORE : " + score;
            highScoreLabel.Text = "HIGH SCORE : " + HighScore;
            Ball.Left += speedLeft;
            Ball.Top += speedTop;

            // If you touch it with the stick
            if (Ball.Bottom >= Stick.Top && Ball.Left >= Stick.Left && Ball.Right <= Stick.Right && Ball.Bottom <= Stick.Bottom)
            {
                pongSound.Play();
                speedLeft += 1;
                speedTop += 1;
                speedTop = -speedTop;
                score += 1;
            }

            // The bouncing of the ball
            if (Ball.Left <= Field.Left) speedLeft = -speedLeft;
            if (Ball.Right >= Field.Right) speedLeft = -speedLeft;
            if (Ball.Top <= Field.Top) speedTop = -speedTop;

            // if the ball touches the floor
            if (Ball.Bottom >= Field.Bottom)
            {
                Time.Stop();
                Cursor.Show();
                DialogResult dialogResult = MessageBox.Show("You lost. New game?", "GAME OVER", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SaveRecordIntoFile();
                    ReadRecordFromFile();
                    score = 0;
                    Ball.Left = randomInt;
                    Ball.Top = startPointYBall;
                    speedLeft = 3;
                    speedTop = 3;                  
                    Time.Start();
                }
                else if (dialogResult == DialogResult.No)
                {
                    SaveRecordIntoFile();
                    Close();
                }

            }
        }

        void SaveRecordIntoFile()
        {
            if (score > Int32.Parse(HighScore))
            {
                File.WriteAllText(path, score.ToString());
            }
        }

        void ReadRecordFromFile()
        {
            string HighScoreRead = File.ReadAllText(path);
            this.HighScore = HighScoreRead;
        }
        
    }
}