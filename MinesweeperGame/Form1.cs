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
        private int a = 10;
        private string[,] gameField = new string[10, 10];
        private Button[,] buttons = new Button[10, 10];
        private int mineCount = 12;
        private int clickCount = 0;

        private void GenerateField()
        {
            Random random = new Random();
            while (mineCount != 0)
            {
                int i = random.Next(1, 9);  
                int j = random.Next(1, 9);
                if (gameField[i, j] != "mine")
                {
                    gameField[i, j] = "mine";
                    buttons[i, j].Text = gameField[i, j];
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
                    Button button = new Button();
                    Controls.Add(button);
                    button.Height = 50;
                    button.Width = 50;
                    button.Left = x;
                    button.Top = y;
                    button.Visible = true;
                    button.Enabled = true;
                    buttons[i, j] = button;
                    x += 75;
                }
                y += 75;
                x = 25;
            }
            GenerateField();
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
