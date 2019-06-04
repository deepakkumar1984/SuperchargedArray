using SuperchargedArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayExt.Accel.Testing
{
    public class BasicExample
    {
        public static void RunStandard()
        {
            //Create an array with values
            Array a = new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };

            //Create a array with constant value 2
            Array b = new float[3, 2];
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    b.SetValue(2, i, j);
                }
            }

            //Perform Math operation on the array: 2A + Log(B) + Exp(A)
            Array r = new float[3, 2];
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    float A = (float)a.GetValue(i, j);
                    float B = (float)b.GetValue(i, j);

                    float rvalue = 2 * A - MathF.Log(B) + MathF.Exp(A);
                    r.SetValue(rvalue, i, j);
                }
            }

            //Print the Array
            for (int i = 0; i < r.GetLength(0); i++)
            {
                for (int j = 0; j < r.GetLength(1); j++)
                {
                    Console.Write(r.GetValue(i, j) + "  ");
                }

                Console.WriteLine();
            }
        }

        public static void RunArraySimplified()
        {
            var K = Global.OP;
            //Create an array with values
            NDArray a = new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };

            //Create a array with constant value 2
            NDArray b = new float[3, 2];
            //NDArray b = new NDArray(3, 2);
            b.Fill(2);

            //Perform Math operation on the array: 2A + Log(B) + Exp(A)
            var r = 2 * a - K.Log(b) + K.Exp(a);

            //Print the Array
            r.Print();
        }
    }
}
