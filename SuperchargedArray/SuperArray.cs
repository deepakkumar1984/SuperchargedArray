using SuperchargedArray;
using SuperchargedArray.Backend;
using SuperchargedArray.Backend.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperchargedArray
{
    public partial class SuperArray : IDisposable
    {
        public AFArray variable;

        public Shape Shape
        {
            get
            {
                return new Shape(variable.Dimensions);
            }
        }

        public int ElementCount
        {
            get
            {
                return Shape.Dims.Aggregate(1, (a, b) => a * b);
            }
        }

        public Type DataType
        {
            get
            {
                return variable.ElemType;
            }
        }

        public bool IsVector => variable.IsVector;
        public bool IsScalar => variable.IsScalar;
        public bool IsRow => variable.IsRow;
        public bool IsColumn => variable.IsColumn;
        public bool IsEmpty => variable.IsEmpty;

        public SuperArray(SuperchargedArray.Backend.AFArray x)
        {
            variable = x;
        }

        public SuperArray(Shape shape)
        {
            variable = Data.Constant<float>(0, shape.Dims);
        }

        public SuperArray(params int[] dims)
        {
            variable = Data.Constant<float>(0, dims);
        }

        public SuperArray Reshape(Shape shape)
        {
            int prod = -1 * shape.Dims.Aggregate((a, b) => a * b);
            
            for (int i = 0; i < shape.Length; i++)
            {
                if (shape[i] == -1)
                {
                    shape[i] = ElementCount / prod;
                    break;
                }
            }

            return new SuperArray(Data.ModDims(variable, shape.GetLongShape()));
        }

        public SuperArray Reshape(params int[] dims)
        {
            return Reshape(new Shape(dims));
        }

        public SuperArray Ravel()
        {
            return Reshape(ElementCount);
        }

        public SuperArray Transpose(bool conjugate = false)
        {
            if (Shape.Length > 2)
                throw new Exception("Transpose need 1D or 2D array. Please use Transpose(int[]) for more than 2D array");

            return new SuperArray(Matrix.Transpose(variable, conjugate));
        }

        public SuperArray Transpose(Shape shape)
        {
            return new SuperArray(Data.Reorder(variable, shape.GetUIntShape()));
        }

        public SuperArray Transpose(params uint[] shape)
        {
            return new SuperArray(Data.Reorder(variable, shape));
        }

        public Array GetData<T>()
        {
            if (Shape.Length == 1)
                return Data.GetData<T>(variable);
            else if (Shape.Length == 2)
                return Data.GetData2D<T>(variable);
            else if (Shape.Length == 3)
                return Data.GetData3D<T>(variable);
            else if (Shape.Length == 4)
                return Data.GetData4D<T>(variable);

            return null;
        }

        public List<T> List<T>()
        {
            return Data.GetData<T>(variable).ToList();
        }

        public static SuperArray Constant<T>(T value, Shape shape)
        {
            return Data.Constant<T>(value, shape.Dims);
        }

        public SuperArray Rows(int start, int end)
        {
            return variable.Rows(start, end);
        }

        public SuperArray Cols(int start, int end)
        {
            return variable.Cols(start, end);
        }

        public SuperArray this[int start, int end]
        {
            get
            {
                return variable.Cols(start, end);
            }
        }

        public void Print()
        {
            AFArray y = Device.IsColumnMajor ? variable : Data.ModDims(variable, variable.Dimensions.Select(i => (long)i).Reverse().ToArray());
            y = Matrix.Transpose(y, false);
            Util.Print(y);
        }

        public SuperArray Repeat(int n, int axis)
        {
            return Ops.Tile(this, n, axis);
        }

        public void Dispose()
        {
            variable.Dispose();
        }

        public static SuperArray operator +(SuperArray lhs, SuperArray rhs)
        {
            if (lhs.IsScalar && rhs.IsScalar)
                return Data.CreateArray(new float[] { lhs.List<float>()[0] + rhs.List<float>()[0] });
            else if (lhs.IsScalar)
                return Data.Constant<float>(lhs.List<float>()[0], rhs.variable.Dimensions) + rhs;
            else if (rhs.IsScalar)
                return lhs.variable + Data.Constant<float>(rhs.List<float>()[0], lhs.variable.Dimensions);

            (lhs, rhs) = BroadcastTensor(lhs, rhs);
            return lhs.variable + rhs.variable;
        }

        public static SuperArray operator +(SuperArray lhs, float rhs)
        {
            return lhs.variable + Data.Constant<float>(rhs, lhs.variable.Dimensions);
        }

        public static SuperArray operator +(float lhs, SuperArray rhs)
        {
            return Data.Constant<float>(lhs, rhs.variable.Dimensions) + rhs;
        }

        public static SuperArray operator -(SuperArray lhs, SuperArray rhs)
        {
            if (lhs.IsScalar && rhs.IsScalar)
                return Data.CreateArray(new float[] { lhs.List<float>()[0] - rhs.List<float>()[0] });
            else if (lhs.IsScalar)
                return Data.Constant<float>(lhs.List<float>()[0], rhs.variable.Dimensions) - rhs;
            else if (rhs.IsScalar)
                return lhs.variable - Data.Constant<float>(rhs.List<float>()[0], lhs.variable.Dimensions);

            (lhs, rhs) = BroadcastTensor(lhs, rhs);
            return lhs.variable - rhs.variable;
        }

        public static SuperArray operator -(SuperArray lhs, float rhs)
        {
            return lhs.variable - Data.Constant<float>(rhs, lhs.variable.Dimensions);
        }

        public static SuperArray operator -(float lhs, SuperArray rhs)
        {
            return Data.Constant<float>(lhs, rhs.variable.Dimensions) - rhs;
        }

        public static SuperArray operator *(SuperArray lhs, SuperArray rhs)
        {
            if (lhs.IsScalar && rhs.IsScalar)
                return Data.CreateArray(new float[] { lhs.List<float>()[0] * rhs.List<float>()[0] });
            else if (lhs.IsScalar)
                return Data.Constant(lhs.List<float>()[0], rhs.variable.Dimensions) * rhs;
            else if (rhs.IsScalar)
                return lhs.variable * Data.Constant<float>(rhs.List<float>()[0], lhs.variable.Dimensions);

            (lhs, rhs) = BroadcastTensor(lhs, rhs);
            return lhs.variable * rhs.variable;
        }

        public static SuperArray operator *(SuperArray lhs, float rhs)
        {
            return lhs.variable * Data.Constant<float>(rhs, lhs.variable.Dimensions);
        }

        public static SuperArray operator *(float lhs, SuperArray rhs)
        {
            return Data.Constant<float>(lhs, rhs.variable.Dimensions) * rhs;
        }

        public static SuperArray operator /(SuperArray lhs, SuperArray rhs)
        {
            if (lhs.IsScalar && rhs.IsScalar)
                return Data.CreateArray(new float[] { lhs.List<float>()[0] / rhs.List<float>()[0] });
            else if (lhs.IsScalar)
                return Data.Constant<float>(lhs.List<float>()[0], rhs.variable.Dimensions) / rhs;
            else if (rhs.IsScalar)
                return lhs.variable / Data.Constant<float>(rhs.List<float>()[0], lhs.variable.Dimensions);
            

            (lhs, rhs) = BroadcastTensor(lhs, rhs);
            return lhs.variable / rhs.variable;
        }

        public static SuperArray operator /(SuperArray lhs, float rhs)
        {
            return lhs.variable / Data.Constant<float>(rhs, lhs.variable.Dimensions);
        }

        public static SuperArray operator /(float lhs, SuperArray rhs)
        {
            return Data.Constant<float>(lhs, rhs.variable.Dimensions) / rhs;
        }

        public static SuperArray operator >(SuperArray lhs, SuperArray rhs)
        {
            (lhs, rhs) = BroadcastTensor(lhs, rhs);
            return lhs.variable > rhs.variable;
        }

        public static SuperArray operator >(SuperArray lhs, float rhs)
        {
            return lhs.variable > Data.Constant<float>(rhs, lhs.variable.Dimensions);
        }

        public static SuperArray operator >(float lhs, SuperArray rhs)
        {
            return Data.Constant<float>(lhs, rhs.variable.Dimensions) > rhs;
        }

        public static SuperArray operator <(SuperArray lhs, SuperArray rhs)
        {
            (lhs, rhs) = BroadcastTensor(lhs, rhs);
            return lhs.variable < rhs.variable;
        }

        public static SuperArray operator <(SuperArray lhs, float rhs)
        {
            return lhs.variable < Data.Constant<float>(rhs, lhs.variable.Dimensions);
        }

        public static SuperArray operator <(float lhs, SuperArray rhs)
        {
            return Data.Constant<float>(lhs, rhs.variable.Dimensions) < rhs;
        }

        public static SuperArray operator >=(SuperArray lhs, SuperArray rhs)
        {
            (lhs, rhs) = BroadcastTensor(lhs, rhs);
            return lhs.variable >= rhs.variable;
        }

        public static SuperArray operator >=(SuperArray lhs, float rhs)
        {
            return lhs.variable >= Data.Constant<float>(rhs, lhs.variable.Dimensions);
        }

        public static SuperArray operator >=(float lhs, SuperArray rhs)
        {
            return Data.Constant<float>(lhs, rhs.variable.Dimensions) >= rhs;
        }

        public static SuperArray operator <=(SuperArray lhs, SuperArray rhs)
        {
            (lhs, rhs) = BroadcastTensor(lhs, rhs);
            return lhs.variable <= rhs.variable;
        }

        public static SuperArray operator <=(SuperArray lhs, float rhs)
        {
            return lhs.variable <= Data.Constant<float>(rhs, lhs.variable.Dimensions);
        }

        public static SuperArray operator <=(float lhs, SuperArray rhs)
        {
            return Data.Constant<float>(lhs, rhs.variable.Dimensions) <= rhs;
        }

        #region Implicit Methods

        public static implicit operator SuperArray(SuperchargedArray.Backend.AFArray d)
        {
            return new SuperArray(d);
        }
        #endregion

        private static ValueTuple<SuperArray, SuperArray> BroadcastTensor(SuperArray lhs, SuperArray rhs)
        {
            if (lhs.ElementCount == rhs.ElementCount && !lhs.IsVector && !lhs.IsVector)
            {
                if (lhs.Shape[0] == rhs.Shape[0] && (lhs.Shape[1] == 1 || rhs.Shape[1] == 1))
                {
                    if (lhs.Shape[1] == 1)
                    {
                        lhs = lhs.Repeat(rhs.Shape[1], 0);
                    }

                    if (rhs.Shape[1] == 1)
                    {
                        rhs = rhs.Repeat(lhs.Shape[1], 0);
                    }
                }

                if (lhs.Shape[1] == rhs.Shape[1] && (lhs.Shape[0] == 1 || rhs.Shape[0] == 1))
                {
                    if (lhs.Shape[0] == 1)
                    {
                        lhs = lhs.Repeat(rhs.Shape[0], 1);
                    }

                    if (rhs.Shape[0] == 1)
                    {
                        rhs = rhs.Repeat(lhs.Shape[0], 1);
                    }
                }

                if (lhs.Shape[1] == 1 && rhs.Shape[0] == 1)
                {
                    if (lhs.Shape[1] == 1)
                    {
                        lhs = lhs.Repeat(rhs.Shape[1], 0);
                    }

                    if (rhs.Shape[0] == 1)
                    {
                        rhs = rhs.Repeat(lhs.Shape[0], 1);
                    }
                }

                if (lhs.Shape[0] == 1 || rhs.Shape[1] == 1)
                {
                    if (lhs.Shape[0] == 1)
                    {
                        lhs = lhs.Repeat(rhs.Shape[0], 1);
                    }

                    if (rhs.Shape[1] == 1)
                    {
                        rhs = rhs.Repeat(lhs.Shape[1], 0);
                    }
                }
            }
            else if (lhs.IsVector && !rhs.IsVector)
            {
                lhs = lhs.Repeat(rhs.Shape[0], 0).Reshape(rhs.Shape);
            }
            else if (rhs.IsVector && !lhs.IsVector)
            {
                rhs = rhs.Repeat(lhs.Shape[0], 0).Reshape(lhs.Shape);
            }

            if (lhs.Shape.Length == 1 && rhs.Shape.Length > 1)
            {
                lhs = lhs.Reshape(rhs.Shape);
            }
            else if (rhs.Shape.Length == 1 && lhs.Shape.Length > 1)
            {
                rhs = rhs.Reshape(lhs.Shape);
            }

            return (lhs, rhs);
        }
    }
}
