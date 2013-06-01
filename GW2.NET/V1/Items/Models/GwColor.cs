using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2DotNET.V1.Items.Models
{
    public struct GwColor
    {
        public int Id { get; set; }
        public ColorDetails Default { get; set; }
        public ColorDetails Cloth { get; set; }
        public ColorDetails Leather { get; set; }
        public ColorDetails Metal { get; set; }

        public struct ColorDetails
        {
            public double Brightness { get; set; }
            public double Contrast { get; set; }
            public double Hue { get; set; }
            public double Saturation { get; set; }
            public double Lightness { get; set; }
        }
    }
}
