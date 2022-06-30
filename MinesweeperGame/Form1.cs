using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGame
{
    public partial class Form1 : Form
    {
        private int size_X = 8;
        private int size_Y = 8;
        private string[,] gameField;
        private Button[,] superButtons;
        private PictureBox[,] pictureBoxes;
        
        private int mineCount = 12;
        private int clickCount = 0;
        private string labelTimeText = "Время: 0";
        private int gameTime = 0;
        private Label time = new Label();
        private Label minelabel = new Label();


        private void GenerateField(int x, int y)
        {
            Random random = new Random();
            while (mineCount != 0)
            {
                int i = random.Next(0, size_X);
                int j = random.Next(0, size_Y);
                if (gameField[i, j] != "mine" && i != x && j != y)
                {
                    gameField[i, j] = "mine";
                    pictureBoxes[i, j].Image = Image.FromFile("Mine.png");
                    superButtons[i, j].Text = "mine";   // debug
                    mineCount--;
                }
                
            }

        }

        int GetNumMines(int x, int y)
        {
            int count = 0;

            int x_count = gameField.GetLength(1);
            int y_count = gameField.GetLength(0);

            if (x > 0)   // <-
            {
                if (gameField[y, x - 1] == "mine")
                {
                    count++;
                }
            }

            if (y < y_count - 1)//down
            {
                if (gameField[y+1,x] == "mine") 
                {
                    count++;
                }
            }

            if (x > 0 && y > 0)  // up left
            {
                if (gameField[y-1, x - 1] == "mine")
                {
                    count++;
                }
            }

            if (y > 0 ) //up
            {
                if (gameField[y-1, x] == "mine")
                {
                    count++;
                }
            }

            if (x < x_count - 1) //->
            {
                if (gameField[y, x + 1] == "mine")
                {
                    count++;
                }
            }

            if (x < x_count - 1 && y < y_count - 1)  //->
            {
                if (gameField[y + 1, x + 1] == "mine")
                {
                    count++;
                }
            }

            if (x > 0 && y < y_count - 1)
            {
                if (gameField[y+1, x - 1] == "mine")
                {
                    count++;
                }
            }

            if (x < x_count && y > y_count)
            {
                if (gameField[x + 1, y - 1] == "mine")
                {
                    count++;
                }
            }

            return count;
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
            for (int i = 0; i < size_X; i++)
            {
                for (int j = 0; j < size_Y; j++)
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

                    //проверка на кол-во мин рядом

                    
                }
                y += 75;
                x = 25;
            }
            x = 25;
            y = 25;
            for (int i = 0; i < size_X; i++)
            {
                for (int j = 0; j < size_Y; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.BringToFront();
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
            //superButtons[superButton.X, superButton.Y].Enabled = false;
            //superButtons[superButton.X, superButton.Y].Visible = false;
            pictureBoxes[superButton.X, superButton.Y].Visible = true;

            int num = GetNumMines(superButton.Y, superButton.X);
            superButton.Text = num.ToString();

            //MessageBox.Show(num.ToString());
;        }

        public Form1()
        {
            InitializeComponent();

            gameField = new string[size_X, size_Y];
            superButtons = new SuperButton[size_X, size_Y];
            pictureBoxes = new PictureBox[size_X, size_Y];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisableMenu();
            StartGame();
            Size = new Size(650, 700);
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            time.Text = "Время: 0";
            time.Visible = true;
            time.Top = 630;
            time.Left = 25;
            this.Controls.Add(time);

            //Label MineNum = new Label();
            minelabel.Text = "Количество мин: 12";
            minelabel.Visible = true;
            minelabel.Width = 200;
            minelabel.Top = 630;   // 630
            minelabel.Left = 500;   // 100
            minelabel.BringToFront();
            this.Controls.Add(minelabel);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            gameTime++;
            time.Text = "Время: " + gameTime;
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
