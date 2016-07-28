using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinProj_Delegate
{
    class Dolphin
    {
        public delegate void TrickType();

        private TrickType dolphinTrick;
        public TrickType Trick 
        {
            set 
            {
                dolphinTrick = value;
            }
        }

        public void DoTricks() 
        {
            if (dolphinTrick != null) 
            {
                dolphinTrick();
            }
        }
    }
}
