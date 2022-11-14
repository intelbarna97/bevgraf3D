using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _GraphicsDLL
{
    public class Vector4
    {
        public double x, y, z, w;

        public Vector4() : this(0.0, 0.0, 0.0, 0.0) { }
        public Vector4(Vector4 v) : this(v.x, v.y, v.z, v.w) { }
        public Vector4(double x, double y, double z)
            : this(x, y, z, 1.0)
        { }
        public Vector4(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public void ToCartesian()
        {
            this.x /= this.w;
            this.y /= this.w;
            this.z /= this.w;
            this.w = 1.0;
        }

        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, 1.0);
        }
        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, 1.0);
        }
        public static Vector4 operator *(Vector4 a, double l)
        {
            return new Vector4(a.x * l, a.y * l, a.z * l, 1.0);
        }
        public static Vector4 operator *(double l, Vector4 a)
        {
            return new Vector4(a.x * l, a.y * l, a.z * l, 1.0);
        }
    }
}
