using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using SlimDX;
using SlimDX.Direct3D9;
//using SlimDX.Direct3D11;
//using SharpDX;
//using SharpDX.Direct3D9;
//using SharpDX.Mathematics;


namespace nsOyun1
{
    class Oyunform:Form
    {
        Device device = null;
        //grafik burda alıglnacak
        public void grafik_algila()
        {
            try
            {
                //paramterre nesnesi tanımlıyoz
                PresentParameters parametre = new PresentParameters();
                Direct3D d3 = new Direct3D();//-----------------bunu ben uydurdum
                parametre.Windowed = true;//pencere olack
                parametre.SwapEffect = SwapEffect.Discard;//....
                //şimdi device nesnesi creating
                device = new Device(d3, 0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, parametre);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                device.Clear(ClearFlags.Target, Color.Aqua, 0.0f, 19);
                //hedef pencere temizlensin ve ekrana arka pan rengi verilsin
                device.BeginScene();//Direc3Dye ekrana bişeyler çilizeceğini söyledik
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
