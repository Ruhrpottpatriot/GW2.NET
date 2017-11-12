
namespace GW2NET.MumbleLink
{
    using System;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;

    internal class Vector3DConverter : IConverter<float[], Vector3D>
    {
        public Vector3D Convert(float[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            if (value.Length != 3)
            {
                throw new ArgumentException("Precondition: value.Length == 3", "value");
            }

            return new Vector3D(value[0], value[1], value[2]);
        }
    }
}
