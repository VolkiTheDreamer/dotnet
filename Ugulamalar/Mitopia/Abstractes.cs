using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mitopia
{
    // enum ile state tanımla, ölü, arafta, canlı v.s. her objenni bir statei olsun
        /*
         * modifier yoksa:ezilemez
         * abstract:ezilmeli
         * virtual:ezilebilir
         */
    abstract class Moving: IMortal
    {        
        //main goal is to provide common moving methods
        void Walk()
        {

        }

        void Glide()
        {

        }
        public virtual void Fly() //some inheritants cannot fly. onlarda empty yapcaz
        {

        }
        void Jump()
        {

        }
        void Duck()
        {

        }
        public virtual void Die() //IMortals nedeniyle implemented. Not everybody dies in the same way, tanrıalr ışınlar, bazısı toz, bazsı toprak
        {

        }

        public abstract void Shout(); //everyone has different voices

        public abstract void Attack(); //everyone has different attack style

        void BeAttacked()
        {
            /*
             If saldirilansey  is ICanGetCaugjt then onu yakalan metorunu cagur else msgbox “ben yakalanmam”(buonteme marker interface deniyor. Bhnun yerine attribiute kullan. Gerci bu oneriyi empty interfaceler icin yapiyolar.nkrmal interfaveler icin gecerli olmayabilir)
             */
        }

        public abstract void UseSuperPower(); //everyone has different superpower style, in fact, some doesn have super power, onları empty yap
    }

    abstract class God : Moving, ICannotGetCaucght, IImmortal
    {
        //they dont have endurance property as ther r immortal
        string specialPower;
    }

    abstract class Creature:Moving, ICanGetCaught, IMortal
    {            
        private string superPower;
        private int attackPower;
        
        //properties
        public string SuperPower { get; } //filed gerekli zira adece get
        public int Endurance { get; set; } //fielda gerek yok, otomatik property with both set and get
        public int AttackPower { get; set; }

        public void GetCaught()
        {

        }

    }

        abstract class Monster: Creature
        {

        }

        abstract class Animal: Creature
        {

        }

        abstract class Human: Creature
        {

        }

    
}
