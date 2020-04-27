using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mitopia
{
    class Ghost: Creature, IMortal, ICannotGetCaucght
    {
        //normally, this inherits Creater and it implements ICanGetCacught, but this one cannot. OVerride türü bişey ypamak lazım, dene?
        public void Die() { }
    }
}
