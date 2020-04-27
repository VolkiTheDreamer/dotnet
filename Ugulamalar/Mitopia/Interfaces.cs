using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mitopia
{
    public interface IMortal
    {
        void Die();
    }

    public interface IImmortal
    {
        //empty olmasın
    }

    public interface ICanGetCaught
    {
        void GetCaught();
    }

    public interface ICannotGetCaucght
    {
        //empty
    }

    public interface IEvolvable
    {
        void Evolve();
    }
}
