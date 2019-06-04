using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPokerConsoleApp
{
    // Template design pattern abstract class
    abstract class Template
    {
        public void TemplateMethod()
        {
            DoStart();
            while (!IsEnd())
            {
                PlayGame();
            }
            DoEnd();
        }

        protected abstract void DoStart();

        protected abstract bool IsEnd();

        protected abstract void PlayGame();

        protected abstract void DoEnd();
    }
}
