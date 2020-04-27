using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mitopia
{
    /*
 interfacelerde field olmaz, prpoerty olur
  Interface içinde property, event (olay), method, indexer, temsilci (delagate) gibi üyeler tanımlanabilir fakat constructor, destructor ve operator overloading gibi işlemler olamaz. Ayrıca bir interface içinde static metotlar veya static değişkenler tanımlanamaz
*/
    public interface IMortal
    {
        int Life { get; set; } //field yoki property var
        void Die();//ölürken farkı hal, ses "ah" falan desin
        event EventHandler Click;//işaretlendiklerinde rengi değişsin
        event EventHandler Dying; //ölme olayı olunca bi şeyler değişsin v.s
    }

    public interface IImmortal
    {
        //empty olmasın, bunun yerine atrrübute kullanalım
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

    public interface IPrayable
    {
        void BePrayed();
    }

    public interface ICanPray
    {
        void Pray();
    }
}
