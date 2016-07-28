using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinProj_Delegate
{
    class Apple
    {
        public delegate void AppleType();
        private AppleType AppleTrick;

        public AppleType Trick 
        {
            set { AppleTrick = value; }
        }

        public void DoTrick()
        {
            if (AppleTrick != null) 
            {
                AppleTrick();
            }   
        }
    }
}
