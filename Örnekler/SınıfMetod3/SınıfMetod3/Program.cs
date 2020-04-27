using System;
namespace Property_Makale
{
    class Otomobil
    {
        private int model;
        public string marka;
        public string renk;
        public Otomobil(int mdl, string mrk, string rnk)
        {
            if (mdl > DateTime.Now.Year)
                this.model = DateTime.Now.Year;
            else this.model = mdl;

            this.marka = mrk;
            this.renk = rnk;
        }
        public void OzellikleriGoster()
        {
            Console.WriteLine("\nOtomobilimizin Özellikleri: ");
            Console.WriteLine("\t Marka: " + marka);
            Console.WriteLine("\t Model: " + model);
            Console.WriteLine("\t Renk: " + renk + "\n");
        }
        public void ModelDegistir(int yeniModel)
        {
            if ((yeniModel > DateTime.Now.Year) || (yeniModel < 1900))
                Console.WriteLine("Otomobilin modeli su an ki yildan büyük veya 1900'den küçük olamaz ! ");
            else this.model = yeniModel;
        }
    }
    class OtomobilTest
    {
        static void Main(string[] args)
        {
            Otomobil oto1 = new Otomobil(2000, "BMW", "Siyah");
            oto1.OzellikleriGoster();
            oto1.ModelDegistir(1980);
            oto1.OzellikleriGoster();
            Console.ReadLine();
        }
        
    }
}