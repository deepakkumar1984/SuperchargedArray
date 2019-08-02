using SiaNet.Backend.ArrayFire;
using SiaNet.Backend.ArrayFire.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFWork
{
    public partial class SuperArray
    {
        internal AFArray variable;

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

        internal SuperArray(SiaNet.Backend.ArrayFire.AFArray x)
        {
            variable = x;
        }

        public SuperArray(Shape shape)
        {
            variable = Data.Constant<float>(0, shape.Dims);
        }

        public SuperArray Reshape(Shape shape)
        {
            int prod = -1 * ElementCount;
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

        public SuperArray Transpose(bool conjugate = false)
        {
            if (Shape.Length != 2)
                throw new Exception("Transpose need 2D array. Please use Transpose(int[]) for more than 2D array");

            return new SuperArray(Matrix.Transpose(variable, conjugate));
        }

        public SuperArray Transpose(Shape shape)
        {
            return new SuperArray(Data.Reorder(variable, shape.GetUIntShape()));
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

        public void Fill(float value)
        {
            
        }

        public void Print()
        {
            AFArray y = Global.IsColumnMajor ? variable : Data.ModDims(variable, variable.Dimensions.Select(i => (long)i).Reverse().ToArray());
            y = Matrix.Transpose(y, false);
            Util.Print(y);
        }

        public static SuperArray operator +(SuperArray lhs, SuperArray rhs)
        {
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

        public static SuperArray operator ==(SuperArray lhs, SuperArray rhs)
        {
            return Arith.EqualTo(lhs.variable, rhs.variable);
        }

        public static SuperArray operator ==(SuperArray lhs, float rhs)
        {
            return Arith.EqualTo(lhs.variable, Data.Constant<float>(rhs, lhs.variable.Dimensions));
        }

        public static SuperArray operator ==(float lhs, SuperArray rhs)
        {
            return Arith.EqualTo(Data.Constant<float>(lhs, rhs.variable.Dimensions), rhs.variable);
        }

        public static SuperArray operator !=(SuperArray lhs, SuperArray rhs)
        {
            return Arith.EqualTo(lhs.variable, rhs.variable);
        }

        public static SuperArray operator !=(SuperArray lhs, float rhs)
        {
            return Arith.EqualTo(lhs.variable, Data.Constant<float>(rhs, lhs.variable.Dimensions));
        }

        public static SuperArray operator !=(float lhs, SuperArray rhs)
        {
            return Arith.EqualTo(Data.Constant<float>(lhs, rhs.variable.Dimensions), rhs.variable);
        }

        #region Implicit Methods

        public static implicit operator SuperArray(SiaNet.Backend.ArrayFire.AFArray d)
        {
            return new SuperArray(d);
        }
        #endregion
    }
}
