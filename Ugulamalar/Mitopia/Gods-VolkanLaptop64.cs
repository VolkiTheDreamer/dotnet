using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mitopia
{

    class GodKhronos : IPrayable
    {
        void IPrayable.BePrayed()
        {
            MessageBox.Show("Dursun zaman");
        }
    }

        class GodZeus: GodKhronos
        {
           
        }

        class GodHades:GodKhronos
        {

        }

    class GodRa
    {

    }

        class GodOsiris: GodRa
        {

        }

        class GodHorus: GodRa
        {

        }
}
