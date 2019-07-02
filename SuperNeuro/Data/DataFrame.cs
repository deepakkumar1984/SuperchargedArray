namespace SuperNeuro.Data
{
    using System;
    using SuperNeuro.Engine;
    using System.Linq;
    using SuperchargedArray;

    /// <summary>
    /// Data frame to load data like CSV, images and text in binary format. The instance is then send to Train or Predict method
    /// </summary>
    public class DataFrame
    {
        internal SuperArray variable;

        private ArrayOps K = Global.OP;

        public DataFrame()
        {
            
        }

        internal DataFrame(SuperArray t)
        {
            variable = t;
        }

        /// <summary>
        /// Gets the shape of the data frame.
        /// </summary>
        /// <value>
        /// The shape.
        /// </value>
        public long[] Shape
        {
            get
            {
                return variable.Shape;
            }
        }

        /// <summary>
        /// Reshapes the data frame to specified new shape.
        /// </summary>
        /// <param name="newShape">The new shape.</param>
        public void Reshape(params long[] newShape)
        {
            variable = variable.Reshape(newShape);
        }

        public virtual void Load(params float[] data)
        {
            variable.LoadFrom(data);
        }

        public void Load(float[] data, long[] shape)
        {
            variable.Reshape(shape);
        }

        public Array DataArray
        {
            get
            {
                return variable.Data<float>();
            }
        }

        /// <summary>
        /// Gets the <see cref="DataFrame"/> with the specified start and end index.
        /// </summary>
        /// <value>
        /// The <see cref="DataFrame"/>.
        /// </value>
        /// <param name="start">The start index.</param>
        /// <param name="end">The end index.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">End must be greater than start</exception>
        public DataFrame this[int start, int end]
        {
            get
            {
                if (end <= start)
                {
                    throw new ArgumentException("End must be greater than start");
                }

                var count = end - start + 1;
                if (count > 0)
                    return variable[start, count];

                return null;
            }
        }

        /// <summary>
        /// Gets the <see cref="DataFrame"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="DataFrame"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public DataFrame this[int index]
        {
            get
            {
                var result = variable.Narrow(0, 1, 1);
                return new DataFrame(result);
            }
        }

        /// <summary>
        /// Get batch data with specified start index and size
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="size">The size.</param>
        /// <param name="axis">The axis.</param>
        /// <returns></returns>
        public SuperArray GetBatch(int start, int size, int axis = 0)
        {
            SuperArray data = null;
            
            if (start + size <= Shape[0])
            {
                return variable.Narrow(0, start, start + size - 1);
                //data = UnderlayingVariable[new SuperArray(Enumerable.Range(start, size).ToArray())];
            }
            else
            {
                //int count = (int)Shape[0] - start;
                //data = UnderlayingVariable[new SuperArray(Enumerable.Range(start, count).ToArray())];

                return variable.Narrow(0, start, Shape[0] - 1);
            }

            //return K.CreateVariable(data.Data<float>(), BackendUtil.Int2Long(data.shape));
        }

        /// <summary>
        /// Prints the dataframe, by default first 5 records are printed. Helpful to understand the data structure.
        /// </summary>
        /// <param name="count">The count of records to print.</param>
        /// <param name="title">The title to display.</param>
        public void Head(int count = 5, string title = "")
        {
            if (count > variable.Shape[0])
            {
                count = (int)variable.Shape[0];
            }

            if(!string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("-----------------{0}----------------", title);
            }

            Console.WriteLine(variable.Narrow(0, 0, count).ToString());
        }

        /// <summary>
        /// Round to nearest integer number
        /// </summary>
        public void Round()
        {
        }

        public void Max(int? dim = null)
        {
            if (dim.HasValue)
                variable = K.Max(variable, dim.Value);
            else
                variable = K.Max(variable);
        }

        public void Min(int? dim = null)
        {
            if (dim.HasValue)
                variable = K.Min(variable, dim.Value);
            else
                variable = K.Min(variable);
        }

        public void Argmax()
        {
            variable = K.Argmax(variable, 0);
        }

        public static implicit operator DataFrame(float d)
        {
            return new DataFrame(d);
        }

        public static implicit operator DataFrame(double d)
        {
            return new DataFrame(d);
        }
    }
}
