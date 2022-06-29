using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGame
{
    internal class SuperButton : Button
    {
        private int x;
        private int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public SuperButton(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public SuperButton()
        {

        }
    }
}
