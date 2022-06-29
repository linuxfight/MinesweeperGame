using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGame
{
    public partial class Form1 : Form
    {
        //private int a = 10;
        private string[,] gameField = new string[10, 10];
        private Button[,] superButtons = new SuperButton[10, 10];
        private PictureBox[,] pictureBoxes = new PictureBox[10, 10];
        private int mineCount = 12;
        private int clickCount = 0;

        private void GenerateField(int x, int y)
        {
            Random random = new Random();
            while (mineCount != 0)
            {
                int i = random.Next(1, 9);  
                int j = random.Next(1, 9);
                if (gameField[i, j] != "mine" && i != x && j != y)
                {
                    gameField[i, j] = "mine";
                    pictureBoxes[i, j].Image = Image.FromFile("Mine.png");
                    mineCount--;
                }
            }
        }

        private void DisableMenu()
        {
            button1.Visible = false;
            button2.Enabled = false;
            button2.Visible = false;
            button3.Enabled = false;
            button3.Visible = false;
        }

        private void StartGame()
        {
            int x = 25;
            int y = 25;
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    SuperButton superButton = new SuperButton(i, j);
                    Controls.Add(superButton);
                    superButton.Height = 50;
                    superButton.Width = 50;
                    superButton.Left = x;
                    superButton.Top = y;
                    superButton.Visible = true;
                    superButton.Enabled = true;
                    superButtons[i, j] = superButton;
                    superButton.Click += SuperButton_Click;
                    x += 75;
                }
                y += 75;
                x = 25;
            }
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    Controls.Add(pictureBox);
                    pictureBox.Height = 50;
                    pictureBox.Width = 50;
                    pictureBox.Left = x;
                    pictureBox.Top = y;
                    pictureBox.Visible = false;
                    pictureBox.Enabled = false;
                    pictureBoxes[i, j] = pictureBox;
                    x += 75;
                }
                y += 75;
                x = 25;
            }
        }

        private void SuperButton_Click(object sender, EventArgs e)
        {
            SuperButton superButton = (SuperButton)sender;
            if (clickCount == 0)
                GenerateField(superButton.X, superButton.Y);
            clickCount++;
            superButtons[superButton.X, superButton.Y].Enabled = false;
            superButtons[superButton.X, superButton.Y].Visible = false;
            pictureBoxes[superButton.X, superButton.Y].Visible = true;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisableMenu();
            StartGame();
            Size = new Size(650, 650);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчики игры: Ctrl. C.V. (Родкевич Артём и Кунгуров Никита)");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
