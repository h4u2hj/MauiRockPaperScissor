using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor
{
    class MyButton : Button
    {
        public int score;
        public int row;

        public MyButton()
        {
            score = 0;
            row = 0;
        }
    }
}