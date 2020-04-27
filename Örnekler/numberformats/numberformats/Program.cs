using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numberformats
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //C:Currency, C1:1 basamak duayrlıklı, C2:2 basamak, Cn:n basamak
                decimal value = 123.456m;
                Console.WriteLine(value.ToString("C2"));// Displays $123.46
            }
            {
                //aşağıdaki giib composite formatting de olabilir
                decimal value = 123.456m;
                Console.WriteLine("Your account balance is {0:C2}.", value);// "Your account balance is $123.46."
            }

            {
                double value = 12345.6789;
                Console.WriteLine(value.ToString("C", CultureInfo.CurrentCulture));

                Console.WriteLine(value.ToString("C3", CultureInfo.CurrentCulture));

                Console.WriteLine(value.ToString("C3",
                                    CultureInfo.CreateSpecificCulture("da-DK")));
                // The example displays the following output on a system whose
                // current culture is English (United States):
                //       $12,345.68
                //       $12,345.679
                //       kr 12.345,679
            }

            //diğer specifiers şöyle: G, F, E, N, P, R, X
            {
                double dblValue = -12445.6789;
                Console.WriteLine(dblValue.ToString("N", CultureInfo.InvariantCulture));
                // Displays -12,445.68
                Console.WriteLine(dblValue.ToString("N1",
                                  CultureInfo.CreateSpecificCulture("sv-SE")));
                // Displays -12 445,7

                int intValue = 123456789;
                Console.WriteLine(intValue.ToString("N1", CultureInfo.InvariantCulture));
                // Displays 123,456,789.0 
            }

            {
                double number = .2468013;
                Console.WriteLine(number.ToString("P", CultureInfo.InvariantCulture));
                // Displays 24.68 %
                Console.WriteLine(number.ToString("P",
                                  CultureInfo.CreateSpecificCulture("hr-HR")));
                // Displays 24,68%     
                Console.WriteLine(number.ToString("P1", CultureInfo.InvariantCulture));
                // Displays 24.7 %
            }

            {
                // Display string representations of numbers for en-us culture
                CultureInfo ci = new CultureInfo("en-us");

                // Output floating point values
                double floating = 10761.937554;
                Console.WriteLine("C: {0}",
                        floating.ToString("C", ci));           // Displays "C: $10,761.94"
                Console.WriteLine("E: {0}",
                        floating.ToString("E03", ci));         // Displays "E: 1.076E+004"
                Console.WriteLine("F: {0}",
                        floating.ToString("F04", ci));         // Displays "F: 10761.9376"         
                Console.WriteLine("G: {0}",
                        floating.ToString("G", ci));           // Displays "G: 10761.937554"
                Console.WriteLine("N: {0}",
                        floating.ToString("N03", ci));         // Displays "N: 10,761.938"
                Console.WriteLine("P: {0}",
                        (floating / 10000).ToString("P02", ci)); // Displays "P: 107.62 %"
                Console.WriteLine("R: {0}",
                        floating.ToString("R", ci));           // Displays "R: 10761.937554"            
                Console.WriteLine();

                // Output integral values
                int integral = 8395;
                Console.WriteLine("C: {0}",
                        integral.ToString("C", ci));           // Displays "C: $8,395.00"
                Console.WriteLine("D: {0}",
                        integral.ToString("D6", ci));          // Displays "D: 008395" 
                Console.WriteLine("E: {0}",
                        integral.ToString("E03", ci));         // Displays "E: 8.395E+003"
                Console.WriteLine("F: {0}",
                        integral.ToString("F01", ci));         // Displays "F: 8395.0"    
                Console.WriteLine("G: {0}",
                        integral.ToString("G", ci));           // Displays "G: 8395"
                Console.WriteLine("N: {0}",
                        integral.ToString("N01", ci));         // Displays "N: 8,395.0"
                Console.WriteLine("P: {0}",
                        (integral / 10000.0).ToString("P02", ci)); // Displays "P: 83.95 %"
                Console.WriteLine("X: 0x{0}",
                        integral.ToString("X", ci));           // Displays "X: 0x20CB"
                Console.WriteLine();
            }

        }
    }
}
