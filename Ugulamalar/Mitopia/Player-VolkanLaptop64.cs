using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mitopia
{
    sealed class Player:Human, ICanPray
    {
        string dressColor;
        string dressPattern;
        public event EventHandler KeyDown;//only arrow keys

        enum Patterns
        {
            Zincirli,
            Cheavalier,
            Leather
        }

        void ICanPray.Pray()
        {

        }
    }
}
