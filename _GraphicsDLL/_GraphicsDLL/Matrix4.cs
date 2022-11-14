using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _GraphicsDLL
{
    public class Matrix4
    {
        double[,] M = new double[4, 4];

        public Matrix4()
        {            
        }
        public Matrix4(Matrix4 m)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    this.M[i, j] = m.M[i, j];
        }

        public void LoadIdentity()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    this.M[i, j] = 0.0;

            this.M[0, 0] = 1.0;
            this.M[1, 1] = 1.0;
            this.M[2, 2] = 1.0;
            this.M[3, 3] = 1.0;
        }

        public double this[int i, int j]
        {
            get { return this.M[i, j]; }
            set { this.M[i, j] = value; }
        }

        public static Matrix4 operator +(Matrix4 a, Matrix4 b)
        {
            throw new NotImplementedException();
        }
        public static Matrix4 operator *(Matrix4 a, Matrix4 b)
        {
            Matrix4 res = new Matrix4();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    res[i, j] = sum;
                }
            }
            return res;
        }
        public static Vector4 operator *(Matrix4 a, Vector4 v)
        {
            Vector4 res = new Vector4();
            res.x = a[0, 0] * v.x + a[0, 1] * v.y + a[0, 2] * v.z + a[0, 3] * v.w;
            res.y = a[1, 0] * v.x + a[1, 1] * v.y + a[1, 2] * v.z + a[1, 3] * v.w;
            res.z = a[2, 0] * v.x + a[2, 1] * v.y + a[2, 2] * v.z + a[2, 3] * v.w;
            res.w = a[3, 0] * v.x + a[3, 1] * v.y + a[3, 2] * v.z + a[3, 3] * v.w;
            return res;
        }

        public static Matrix4 Parallel(Vector4 v)
        {
            Matrix4 res = new Matrix4();
            res[0, 0] = 1.0;
            res[1, 1] = 1.0;
            res[3, 3] = 1.0;
            res[0, 2] = -v.x / v.z;
            res[1, 2] = -v.y / v.z;
            return res;
        }

        public static Matrix4 RotX(double alpha)
        {
            Matrix4 matrix = new Matrix4();
            matrix[0, 0] = 1.0;
            matrix[1, 1] = Math.Cos(alpha);
            matrix[1, 2] = -Math.Sin(alpha);
            matrix[2, 1] = Math.Sin(alpha);
            matrix[2, 2] = Math.Cos(alpha);
            matrix[3, 3] = 1.0;
            return matrix;
        }
        public static Matrix4 RotY(double alpha)
        {
            Matrix4 matrix = new Matrix4();
            matrix[0, 0] = Math.Cos(alpha);
            matrix[1, 1] = 1;
            matrix[2, 0] = -Math.Sin(alpha);
            matrix[0, 2] = Math.Sin(alpha);
            matrix[2, 2] = Math.Cos(alpha);
            matrix[3, 3] = 1.0;
            return matrix;
        }
        public static Matrix4 RotZ(double alpha)
        {
            Matrix4 matrix = new Matrix4();
            matrix[2, 2] = 1.0;
            matrix[0, 0] = Math.Cos(alpha);
            matrix[0, 1] = -Math.Sin(alpha);
            matrix[1, 0] = Math.Sin(alpha);
            matrix[1, 1] = Math.Cos(alpha);
            matrix[3, 3] = 1.0;
            return matrix;
        }
    }
}
