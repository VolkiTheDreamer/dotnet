using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
//using SlimDX;
using SlimDX.Direct3D9;

namespace Oyun1
{
    class CustomVertex
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct TransformedColored
        {
            public Vector4 Position;
            public int Color;
            public static readonly VertexFormat format = VertexFormat.Diffuse | VertexFormat.PositionRhw;
        }
    }
}
