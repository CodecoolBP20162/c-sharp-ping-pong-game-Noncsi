using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class PONG : Form
    {
        bool isPaused = false;
        public int startPointX = 750;
        public int startPointY = 10;
        public int speedLeft = 3;
        public int speedTop = 3;
        public int score = 0;
        public bool GodMode = false; // Press G in Pause mode, and you can move your stick

        public PONG()
        {
            InitializeComponent();
            Stick.Top = Field.Bottom - 50; // Puts the stick to the correct place
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetPixelatedFont();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.G) GodMode = true;
            if (e.KeyCode == Keys.Escape) Close();                    
            if (e.KeyCode == Keys.Space)
            {
                if(isPaused == false) // Pause: ON
                {
                    isPaused = true;
                    PausedLabel.Show();
                    Time.Stop();
                }
                else
                {
                    isPaused = false;
                    PausedLabel.Hide();
                    Time.Start(); 
                }
            }           
        }

        private void Stick_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isPaused)
            {
                // Stick detection
                if (e.KeyCode == Keys.Left) Stick.Left = Stick.Location.X - 20; // if left key is pressed, move the stick left
                else if (e.KeyCode == Keys.Right) Stick.Left = Stick.Location.X + 20; // if right key is pressed, move the stick right
            }
            if (isPaused && GodMode)
            {
                if (e.KeyCode == Keys.Left) Stick.Left = Stick.Location.X - 20; // if left key is pressed, move the stick left
                else if (e.KeyCode == Keys.Right) Stick.Left = Stick.Location.X + 20; // if right key is pressed, move the stick right
            }
        }

        void SetPixelatedFont()
        {
            PrivateFontCollection pixelFont = new PrivateFontCollection();
            pixelFont.AddFontFile("C:/Users/Noncsi/Documents/Visual Studio 2017/Projects/PingPong/PingPong/pixel_font.ttf");
            ScoreTable.Font = new System.Drawing.Font(pixelFont.Families[0], 10, FontStyle.Regular);   
            PausedLabel.Font = new System.Drawing.Font(pixelFont.Families[0], 30, FontStyle.Regular);
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            Cursor.Hide();
            PausedLabel.Hide();
            ScoreTable.Text = "SCORE : " + score;
            Ball.Left += speedLeft;
            Ball.Top += speedTop;

            // If you touch it with the stick
            if (Ball.Bottom >= Stick.Top && Ball.Left >= Stick.Left && Ball.Right <= Stick.Right && Ball.Bottom <= Stick.Bottom)
            {
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
                    Ball.Left = startPointX;
                    Ball.Top = startPointY;
                    Time.Start();
                }
                else if (dialogResult == DialogResult.No) Close();
            }
        }
    }
}
