using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SuperchargedArray
{
    /// <summary>
    /// Arith Array is a base tensor for the Arithmetica. 
    /// It's a multi dimensional array with implementation with basic arithmetics, trignometric, hyperbolic, rounding, 
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public partial class NDArray : IDisposable
    {
        /// <summary>
        /// The sizes
        /// </summary>
        private long[] shape;
        /// <summary>
        /// The strides
        /// </summary>
        private long[] strides;
        /// <summary>
        /// The storage
        /// </summary>
        private Storage storage;
        /// <summary>
        /// The storage offset
        /// </summary>
        private long storageOffset;

        /// <summary>
        /// The is disposed
        /// </summary>
        private bool isDisposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="NDArray"/> class.
        /// </summary>
        /// <param name="shape">The shape.</param>
        public NDArray(params long[] shape)
            : this(shape, DType.Single)
        {

        }

        /// <summary>
        /// Construct a new array, using the given allocator to construct a storage. The new array
        /// will be contiguous in memory. The array's elements will not be initialized.
        /// </summary>
        /// <param name="allocator"></param>
        /// <param name="elementType"></param>
        /// <param name="shape"></param>
        /// <summary>
        /// Initializes a new instance of the <see cref="NDArray"/> class.
        /// </summary>
        /// <param name="allocator">The allocator.</param>
        /// <param name="elementType">Type of the element.</param>
        /// <param name="sizes">The sizes.</param>
        public NDArray(long[] shape, DType elementType)
            : this(shape, Helper.GetContiguousStride(shape), elementType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NDArray"/> class.
        /// </summary>
        /// <param name="allocator">The allocator.</param>
        /// <param name="elementType">Type of the element.</param>
        /// <param name="sizes">The sizes.</param>
        /// <param name="strides">The strides.</param>
        public NDArray(long[] sizes, long[] strides, DType elementType)
        {
            this.shape = sizes;
            this.strides = strides;
            this.storageOffset = 0;
            this.storage = new Storage(elementType, Helper.GetStorageSize(sizes, strides));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NDArray"/> class.
        /// </summary>
        /// <param name="sizes">The sizes.</param>
        /// <param name="strides">The strides.</param>
        /// <param name="storage">The storage.</param>
        /// <param name="storageOffset">The storage offset.</param>
        private NDArray(long[] sizes, long[] strides, Storage storage, long storageOffset)
        {
            this.shape = sizes;
            this.strides = strides;
            this.storage = storage;
            this.storageOffset = storageOffset;
            this.storage.AddRef();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Formatter.FormatTensorTypeAndSize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <exception cref="ObjectDisposedException">ArithArray</exception>
        public void Dispose()
        {
            if (!isDisposed)
            {
                isDisposed = true;
                this.storage.Release();
            }
            else
            {
                throw new ObjectDisposedException("ArithArray");
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            var o = obj as NDArray;
            if (o == null) return false;

            return
                Object.ReferenceEquals(this.storage, o.storage) &&
                this.storageOffset == o.storageOffset &&
                ArrayResultBuilder.ArrayEqual(this.shape, o.shape) &&
                ArrayResultBuilder.ArrayEqual(this.strides, o.strides);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return
                storage.GetHashCode() ^
                storageOffset.GetHashCode() ^
                shape.Aggregate(0, (acc, item) => acc ^ item.GetHashCode()) ^
                strides.Aggregate(0, (acc, item) => acc ^ item.GetHashCode());
        }

        /// <summary>
        /// Gets the type of the element.
        /// </summary>
        /// <value>The type of the element.</value>
        public DType ElementType { get { return storage.ElementType; } }
        /// <summary>
        /// Gets the sizes.
        /// </summary>
        /// <value>The sizes.</value>
        public long[] Shape { get { return shape; } }

        /// <summary>
        /// Gets the strides.
        /// </summary>
        /// <value>The strides.</value>
        public long[] Strides { get { return strides; } }

        /// <summary>
        /// Gets the storage.
        /// </summary>
        /// <value>The storage.</value>
        internal Storage Storage { get { return storage; } }

        /// <summary>
        /// Gets the storage offset.
        /// </summary>
        /// <value>The storage offset.</value>
        public long StorageOffset { get { return storageOffset; } }

        /// <summary>
        /// Gets the dimension count.
        /// </summary>
        /// <value>The dimension count.</value>
        public int DimensionCount { get { return shape.Length; } }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <value>
        /// The elements.
        /// </value>
        public long Elements
        {
            get { return ElementCount(); }
        }

        /// <summary>
        /// Gets a value indicating whether [possible vector].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [possible vector]; otherwise, <c>false</c>.
        /// </value>
        internal bool PossibleVector
        {
            get
            {
                bool result = false;
                if (Shape[1] == 1)
                    result = true;

                return result;
            }
        }

        /// <summary>
        /// Returns a new ArithArray object which points to the same storage as this,
        /// incrementing the refcount of the storage object.
        /// </summary>
        /// <returns>ArithArray.</returns>
        public NDArray CopyRef()
        {
            return new NDArray(shape, strides, storage, storageOffset);
        }

        /// <summary>
        /// Formats this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Format()
        {
            return Formatter.Format(this);
        }

        /// <summary>
        /// The element count
        /// </summary>
        private long? elementCount = null;
        
        /// <summary>
        /// Elements the count.
        /// </summary>
        /// <returns>System.Int64.</returns>
        public long ElementCount()
        {
            if (elementCount.HasValue)
                return elementCount.Value;

            elementCount = Helper.ElementCount(shape);
            return elementCount.Value;
        }

        /// <summary>
        /// Determines whether this instance is contiguous.
        /// </summary>
        /// <returns><c>true</c> if this instance is contiguous; otherwise, <c>false</c>.</returns>
        public bool IsContiguous()
        {
            long z = 1;
            for (int d = shape.Length - 1; d >= 0; d--)
            {
                if (shape[d] != 1)
                {
                    if (strides[d] == z)
                        z *= shape[d];
                    else
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Determines whether [is same size as] [the specified other].
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if [is same size as] [the specified other]; otherwise, <c>false</c>.</returns>
        public bool IsSameSizeAs(NDArray other)
        {
            return ArrayResultBuilder.ArrayEqual(this.shape, other.shape);
        }

        /// <summary>
        /// Note: this does not check whether indices are in range
        /// </summary>
        /// <param name="indices">The indices.</param>
        /// <returns>System.Single.</returns>
        /// <exception cref="ArgumentException">
        /// Number of indices must equal number of array dimensions
        /// or
        /// Index " + i + " with value " + indices[i] + " is out of range
        /// </exception>
        public float GetElementAsFloat(params long[] indices)
        {
            if (indices.Length != DimensionCount) throw new ArgumentException("Number of indices must equal number of array dimensions");
            for (int i = 0; i < indices.Length; ++i)
            {
                if (indices[i] < 0 || indices[i] >= Shape[i])
                    throw new ArgumentException("Index " + i + " with value " + indices[i] + " is out of range");
            }

            long offset = 0;
            for (int i = 0; i < indices.Length; ++i)
            {
                offset += indices[i] * strides[i];
            }

            return storage.GetElementAsFloat(storageOffset + offset);
        }

        /// <summary>
        /// Note: this does not check whether indices are in range
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="indices">The indices.</param>
        /// <exception cref="ArgumentException">
        /// Number of indices must equal number of array dimensions
        /// or
        /// Index " + i + " with value " + indices[i] + " is out of range
        /// </exception>
        public void SetElementAsFloat(float value, params long[] indices)
        {
            if (indices.Length != DimensionCount) throw new ArgumentException("Number of indices must equal number of array dimensions");
            for (int i = 0; i < indices.Length; ++i)
            {
                if (indices[i] < 0 || indices[i] >= Shape[i])
                    throw new ArgumentException("Index " + i + " with value " + indices[i] + " is out of range");
            }

            long offset = 0;
            for (int i = 0; i < indices.Length; ++i)
            {
                offset += indices[i] * strides[i];
            }

            storage.SetElementAsFloat(storageOffset + offset, value);
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Single"/> with the specified indices.
        /// </summary>
        /// <value>
        /// The <see cref="System.Single"/>.
        /// </value>
        /// <param name="indices">The indices.</param>
        /// <returns></returns>
        public float this[params long[] indices]
        {
            get
            {
                return GetElementAsFloat(indices);
            }
            set
            {
                SetElementAsFloat(value, indices);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Single"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="System.Single"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public float this[long index]
        {
            get
            {
                return Storage.GetElementAsFloat(StorageOffset + index);
            }
            set
            {
                Storage.SetElementAsFloat(StorageOffset + index, value);
            }
        }

        /// <summary>
        /// Views the specified sizes.
        /// </summary>
        /// <param name="sizes">The sizes.</param>
        /// <returns>ArithArray.</returns>
        /// <exception cref="InvalidOperationException">
        /// Cannot use View on a non-contiguous tensor000
        /// or
        /// Output array must have the same number of elements as the input
        /// </exception>
        internal NDArray View(params long[] sizes)
        {
            if (!this.IsContiguous()) throw new InvalidOperationException("Cannot use View on a non-contiguous array");

            if (this.ElementCount() != Helper.ElementCount(sizes))
            {
                throw new InvalidOperationException("Output array must have the same number of elements as the input");
            }

            return new NDArray(sizes, Helper.GetContiguousStride(sizes), this.storage, this.storageOffset);
        }

        /// <summary>
        /// Reshapes the specified sizes.
        /// </summary>
        /// <param name="sizes">The sizes.</param>
        /// <returns></returns>
        public NDArray Reshape(params long[] sizes)
        {
            long prod = -1 * sizes.Aggregate(1L, (a, b) => a * b);
            for (int i = 0; i < sizes.Length; i++)
            {
                if (sizes[i] == -1)
                {
                    sizes[i] = ElementCount() / prod;
                    break;
                }
            }

            return View(sizes);
        }

        /// <summary>
        /// Flattens the array
        /// </summary>
        /// <returns></returns>
        public NDArray Ravel()
        {
            return View(ElementCount());
        }

        /// <summary>
        /// Narrows the specified dimension.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="size">The size.</param>
        /// <returns>ArithArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// dimension
        /// or
        /// startIndex
        /// or
        /// size
        /// </exception>
        public NDArray Narrow(int dimension, long startIndex, long size)
        {
            if (dimension < 0 || dimension >= DimensionCount) throw new ArgumentOutOfRangeException("dimension");
            if (startIndex < 0 || startIndex >= shape[dimension]) throw new ArgumentOutOfRangeException("startIndex");
            if (size <= 0 || startIndex + size > shape[dimension]) throw new ArgumentOutOfRangeException("size");

            var newOffset = storageOffset + startIndex * strides[dimension];
            var newSizes = (long[])shape.Clone();
            newSizes[dimension] = size;
            var newStrides = Helper.GetContiguousStride(newSizes);
            

            return new NDArray(newSizes, strides, storage, newOffset);
        }

        /// <summary>
        /// Selects the specified dimension.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <param name="index">The index.</param>
        /// <returns>ArithArray.</returns>
        /// <exception cref="InvalidOperationException">Select requires 2 or more dimensions</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// dimension
        /// or
        /// index
        /// </exception>
        public NDArray Select(int dimension, long index)
        {
            if (DimensionCount == 1) throw new InvalidOperationException("Select requires 2 or more dimensions");
            if (dimension < 0 || dimension >= DimensionCount) throw new ArgumentOutOfRangeException("dimension");
            if (index < 0 || index >= shape[dimension]) throw new ArgumentOutOfRangeException("index");

            var result = Narrow(dimension, index, 1);
            result.shape = ArrayRemove(shape, dimension);
            result.strides = ArrayRemove(strides, dimension);

            return result;
        }

        public NDArray Transpose()
        {
            if (DimensionCount != 2) throw new InvalidOperationException("Parameterless Transpose is only valid on 2d tensors");
            return Transpose(0, 1, true);
        }

        /// <summary>
        /// Transposes this instance without NewContiguous.
        /// </summary>
        /// <returns>ArithArray.</returns>
        /// <exception cref="InvalidOperationException">Parameterless Transpose is only valid on 2d tensors</exception>
        internal NDArray IntTranspose()
        {
            if (DimensionCount != 2) throw new InvalidOperationException("Parameterless Transpose is only valid on 2d tensors");

            return Transpose(0, 1);
        }

        /// <summary>
        /// Transposes the specified dimension1.
        /// </summary>
        /// <param name="dimension1">The dimension1.</param>
        /// <param name="dimension2">The dimension2.</param>
        /// <returns>ArithArray.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// dimension1
        /// or
        /// dimension2
        /// </exception>
        private NDArray Transpose(int dimension1, int dimension2, bool NewContiguous = false)
        {
            if (dimension1 < 0 || dimension1 >= DimensionCount) throw new ArgumentOutOfRangeException("dimension1");
            if (dimension2 < 0 || dimension2 >= DimensionCount) throw new ArgumentOutOfRangeException("dimension2");

            if (dimension1 == dimension2)
            {
                storage.AddRef();
                return this;
            }

            var newSizes = (long[])shape.Clone();
            var newStrides = (long[])strides.Clone();
            ArraySwap(newSizes, dimension1, dimension2);
            ArraySwap(newStrides, dimension1, dimension2);

            if (NewContiguous)
                return Helper.NewContiguous(new NDArray(newSizes, newStrides, storage, storageOffset)).Reshape(newSizes);

            return new NDArray(newSizes, newStrides, storage, storageOffset);
        }

        /// <summary>
        /// Permutes the specified dims.
        /// </summary>
        /// <param name="dims">The dims.</param>
        /// <returns>ArithArray.</returns>
        /// <exception cref="InvalidOperationException">The number of permutation indices must equal the number of array dimensions</exception>
        public NDArray Transpose(params int[] dims)
        {
            if (dims.Length != this.DimensionCount)
                throw new InvalidOperationException("The number of permutation indices must equal the number of array dimensions");

            var result = this.CopyRef();
            foreach (var swap in SwapsForPermutation(dims))
            {
                var resultOld = result;
                result = result.Transpose(swap.Item1, swap.Item2, true);
                resultOld.Dispose();
            }

            return result;
        }

        /// <summary>
        /// Expand one or more singleton dimensions (dimensions with size 1) by using a stride of 0
        /// </summary>
        /// <param name="newSizes">The new sizes.</param>
        /// <returns>ArithArray.</returns>
        /// <exception cref="InvalidOperationException">
        /// number of elements of newSizes must match the dimension count of array
        /// or
        /// Can only expand singleton dimensions (dimensions of size 1)
        /// </exception>
        public NDArray Expand(params long[] newSizes)
        {
            if (newSizes.Length != DimensionCount)
                throw new InvalidOperationException("number of elements of newSizes must match the dimension count of array");

            var newStrides = (long[])strides.Clone();
            for (int i = 0; i < newSizes.Length; ++i)
            {
                if (newSizes[i] != Shape[i])
                {
                    if (Shape[i] != 1)
                        throw new InvalidOperationException("Can only expand singleton dimensions (dimensions of size 1)");

                    newStrides[i] = 0;
                }
            }

            return new NDArray(newSizes, newStrides, this.storage, this.storageOffset);
        }


        /// <summary>
        /// Return a new array where **all** singleton dimensions have been removed
        /// </summary>
        /// <returns>ArithArray.</returns>
        public NDArray Squeeze()
        {
            var newSizeStrides = shape.Zip(strides, Tuple.Create)
                .Where(x => x.Item1 != 1)
                .ToArray();

            var newSizes = newSizeStrides.Select(x => x.Item1).ToArray();
            var newStrides = newSizeStrides.Select(x => x.Item2).ToArray();

            return new NDArray(newSizes, newStrides, storage, storageOffset);
        }


        /// <summary>
        /// Return a new array where the given singleton dimension has been removed
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <returns>ArithArray.</returns>
        /// <exception cref="InvalidOperationException">Squeeze requires 2 or more dimensions</exception>
        /// <exception cref="ArgumentOutOfRangeException">dimension</exception>
        public NDArray Squeeze(int dimension)
        {
            if (DimensionCount == 1) throw new InvalidOperationException("Squeeze requires 2 or more dimensions");
            if (dimension < 0 || dimension >= DimensionCount) throw new ArgumentOutOfRangeException("dimension");

            var newSizes = ArrayRemove(shape, dimension);
            var newStrides = ArrayRemove(strides, dimension);

            return new NDArray(newSizes, newStrides, storage, storageOffset);
        }

        /// <summary>
        /// Returns a array which contains all slices of size size in the given dimension. The step between two slices is given by step.
        /// The result array has an additional dimension of size size.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <param name="size">The size.</param>
        /// <param name="step">The step.</param>
        /// <returns>ArithArray.</returns>
        /// <exception cref="InvalidOperationException">Cannot unfold an empty array</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// dimension is out of range - dimension
        /// or
        /// size cannot be larger than the size of dimension - size
        /// or
        /// step must be at least 1 - step
        /// </exception>
        public NDArray Unfold(int dimension, long size, long step)
        {
            if (DimensionCount == 0) throw new InvalidOperationException("Cannot unfold an empty array");
            if (dimension < 0 || dimension >= DimensionCount) throw new ArgumentOutOfRangeException("dimension is out of range", "dimension");
            if (size > shape[dimension]) throw new ArgumentOutOfRangeException("size cannot be larger than the size of dimension", "size");
            if (step <= 0) throw new ArgumentOutOfRangeException("step must be at least 1", "step");

            var newSize = new long[DimensionCount + 1];
            var newStrides = new long[DimensionCount + 1];
            Array.Copy(shape, newSize, DimensionCount);
            Array.Copy(strides, newStrides, DimensionCount);

            newSize[DimensionCount] = size;
            newStrides[DimensionCount] = this.strides[dimension];

            newSize[dimension] = (this.shape[dimension] - size) / step + 1;
            newStrides[dimension] = step * this.strides[dimension];

            return new NDArray(newSize, newStrides, this.Storage, this.StorageOffset);
        }


        // Pad array by prepending with 1 until its length equals newSize
        /// <summary>
        /// Pad1s the prepend.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="newSize">The new size.</param>
        /// <returns>System.Int64[].</returns>
        private static long[] Pad1Prepend(long[] array, int newSize)
        {
            var result = new long[newSize];

            // Fill new extra elements with 1
            for (int i = 0; i < newSize - array.Length; ++i)
            {
                result[i] = 1;
            }

            // Copy array to the last array.Length elements of result
            Array.Copy(array, 0, result, newSize - array.Length, array.Length);

            return result;
        }

        /// <summary>
        /// Prepend singleton dimensions until DimensionCount equals newDimCount. Pads to dim count.
        /// </summary>
        /// <param name="newDimCount">The new dim count.</param>
        /// <returns>ArithArray.</returns>
        private NDArray PadToDimCount(int newDimCount)
        {
            var newSizes = Pad1Prepend(this.shape, newDimCount);

            var newStrides = Helper.GetContiguousStride(newSizes);
            Array.Copy(this.strides, 0, newStrides, newStrides.Length - this.strides.Length, this.strides.Length);

            return new NDArray(newSizes, newStrides, this.storage, this.storageOffset);
        }

        /// <summary>
        /// Repeats the array along the dimension.
        /// </summary>
        /// <param name="repetitions">The repetitions.</param>
        /// <returns>ArithArray.</returns>
        /// <exception cref="InvalidOperationException">
        /// repetitions must be at least the same length as the number of array dimensions
        /// or
        /// All dimensions must be repeated at least once
        /// </exception>
        public NDArray RepeatTensor(params long[] repetitions)
        {
            if (repetitions.Length < this.DimensionCount)
                throw new InvalidOperationException("repetitions must be at least the same length as the number of array dimensions");
            if (repetitions.Any(x => x < 1)) throw new InvalidOperationException("All dimensions must be repeated at least once");

            var paddedSrc = this.PadToDimCount(repetitions.Length);
            var resultSize = paddedSrc.Shape.Zip(repetitions, (s, r) => s * r).ToArray();

            var result = new NDArray(resultSize, this.ElementType);

            var urTensor = result.CopyRef();
            for (int i = 0; i < paddedSrc.DimensionCount; ++i)
            {
                var oldUrTensor = urTensor;
                urTensor = urTensor.Unfold(i, paddedSrc.Shape[i], paddedSrc.Shape[i]);
                oldUrTensor.Dispose();
            }

            paddedSrc = paddedSrc.PadToDimCount(urTensor.DimensionCount);
            var expandedSrc = paddedSrc.Expand(urTensor.Shape);
            Helper.Copy(urTensor, expandedSrc);

            return result;
        }

        public NDArray Tile(long repetitions)
        {
            return Global.OP.Tile(this, repetitions);
        }

        public NDArray GetRegion(long[] dimensionStarts, long[] dimensionSizes)
        {
            var result = this.CopyRef();
            for (int i = 0; i < dimensionStarts.Length; ++i)
            {
                result = result.Narrow(i, dimensionStarts[i], dimensionSizes[i]);
            }

            return Helper.AsContiguous(result);
        }

        /// <summary>
        /// Copies from.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <exception cref="InvalidOperationException">
        /// ArithArray must be contiguous to copy from CLR array
        /// or
        /// ArithArray and array must have the same number of elements
        /// or
        /// ArithArray and array must have the same element types
        /// </exception>
        public void LoadFrom(Array array)
        {
            var elementType = DTypeBuilder.FromCLRType(array.GetType().GetElementType());

            if (!this.IsContiguous()) throw new InvalidOperationException("ArithArray must be contiguous to copy from CLR array");
            if (this.ElementCount() != array.LongLength) throw new InvalidOperationException("ArithArray and array must have the same number of elements");
            if (this.ElementType != elementType) throw new InvalidOperationException("ArithArray and array must have the same element types");

            var handle = GCHandle.Alloc(array, GCHandleType.Pinned);
            try
            {
                var length = Buffer.ByteLength(array);
                this.Storage.CopyToStorage(this.StorageOffset, handle.AddrOfPinnedObject(), length);
            }
            finally
            {
                handle.Free();
            }
        }


        /// <summary>
        /// Froms the array.
        /// </summary>
        /// <param name="allocator">The allocator.</param>
        /// <param name="array">The array.</param>
        /// <returns>ArithArray.</returns>
        public static NDArray FromArray(Array array)
        {
            // From the CLI spec(section 8.9.1):
            // Array elements shall be laid out within the array object in row - major order
            // (i.e., the elements associated with the rightmost array dimension shall be laid out contiguously from lowest to highest index).
            // The actual storage allocated for each array element can include platform - specific padding.

            // This is already in the order we want - and here we will (potentially incorrectly) assume that there is no
            // 'platform-specific padding'. This appears to be a reasonable assumption on both CLR and Mono.
            // Assuming no platform-specific padding allows us to use memcpy instead of iterating and copying each element

            var elementType = DTypeBuilder.FromCLRType(array.GetType().GetElementType());

            var dimSizes =
                Enumerable.Range(0, array.Rank)
                .Select(x => (long)array.GetLength(x))
                .ToArray();

            var result = new NDArray(dimSizes, elementType);
            result.LoadFrom(array);
            return result;
        }


        /// <summary>
        /// Arrays the swap.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="index1">The index1.</param>
        /// <param name="index2">The index2.</param>
        private static void ArraySwap<T>(T[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        // Return a copy of an array, but with the item at index removed
        /// <summary>
        /// Arrays the remove.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="index">The index.</param>
        /// <returns>T[].</returns>
        private static T[] ArrayRemove<T>(T[] source, long index)
        {
            var result = new T[source.Length - 1];
            for (int i = 0; i < result.Length; ++i)
            {
                if (i < index)
                {
                    result[i] = source[i];
                }
                else
                {
                    result[i] = source[i + 1];
                }
            }
            return result;
        }

        // Convert a permutation into a sequence of swap operations.
        // perm must contain a permuation of the indices [0, perm.Length)
        // The returned tuples indicate pairs of indices that should be swapped. The swaps
        // must be performed in the given order.
        /// <summary>
        /// Swapses for permutation.
        /// </summary>
        /// <param name="perm">The perm.</param>
        /// <returns>IEnumerable<Tuple<System.Int32, System.Int32&gt;&gt;.</returns>
        /// <exception cref="InvalidOperationException">Invalid permutation</exception>
        private static IEnumerable<Tuple<int, int>> SwapsForPermutation(int[] perm)
        {
            int j;
            for (int i = 0; i < perm.Length; ++i)
            {
                var p = perm[i];
                if (p != i && p != -1)
                {
                    j = i;
                    do
                    {
                        if (perm[j] < 0 || perm[j] >= perm.Length)
                            throw new InvalidOperationException("Invalid permutation");

                        yield return Tuple.Create(j, perm[j]);


                        var jOld = j;
                        j = perm[j];
                        perm[jOld] = -1;
                    } while (perm[j] != i);
                    perm[j] = j;
                }
            }
        }


        /// <summary>
        /// Serializes the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void Serialize(System.IO.Stream stream)
        {
            Serializer.Serialize(this, stream);
        }

        /// <summary>
        /// Deserializes the specified allocator.
        /// </summary>
        /// <param name="allocator">The allocator.</param>
        /// <param name="stream">The stream.</param>
        /// <returns>ArithArray.</returns>
        public static NDArray Deserialize(System.IO.Stream stream)
        {
            return Serializer.Deserialize(stream);
        }

        public void Print(uint count = 0, string title = "")
        {

            if (!string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("-----{0}------", title);
            }

            if (count > 0)
            {
                var t = Narrow(0, 0, count);
                Console.WriteLine(t.Format());
            }
            else
            {
                Console.WriteLine(Format());
            }

            if (!string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("--------------", title);
            }
        }

        public Array ToArray()
        {
            Array result = Array.CreateInstance(ElementType.ToCLRType(), Shape);

            var datagch = GCHandle.Alloc(result, GCHandleType.Pinned);
            Storage.CopyFromStorage(datagch.AddrOfPinnedObject(), StorageOffset, Storage.ByteLength);
            datagch.Free();

            return result;
        }

        public List<float> DataFloat
        {
            get
            {
                return ToArray().Cast<float>().ToList();
            }
        }

        public T[] Data<T>()
        {
            return ToArray().Cast<T>().ToArray();
        }

        public void Fill(float value)
        {
            Global.OP.Fill(this, value);
        }

        public static NDArray Constant(float value, DType dtype, params long[] sizes)
        {
            NDArray array = new NDArray(sizes, dtype);
            Global.OP.Fill(array, value);
            return array;
        }

        public static NDArray Arange(float start, float stop, int step = 1)
        {
            NDArray result = null;
            List<float> data = new List<float>();
            while (start < stop)
            {
                data.Add(start);
                start += step;
            }

            result = new NDArray(1, data.Count);
            result.LoadFrom(data.ToArray());
            return result;
        }

        #region Operators

        public static NDArray operator +(NDArray lhs, NDArray rhs)
        {
            return Global.OP.Add(lhs, rhs);
        }

        public static NDArray operator +(NDArray lhs, float rhs) { return Global.OP.Add(lhs, rhs); }

        public static NDArray operator +(float lhs, NDArray rhs) { return Global.OP.Add(rhs, lhs); }

        public static NDArray operator -(NDArray lhs, NDArray rhs)
        {
            return Global.OP.Sub(lhs, rhs);
        }

        public static NDArray operator -(NDArray lhs, float rhs) { return Global.OP.Sub(lhs, rhs); }

        public static NDArray operator -(float lhs, NDArray rhs) { return Global.OP.Sub(lhs, rhs); }

        public static NDArray operator *(NDArray lhs, NDArray rhs)
        {
            return Global.OP.Mul(lhs, rhs);
        }

        public static NDArray operator *(NDArray lhs, float rhs) { return Global.OP.Mul(lhs, rhs); }

        public static NDArray operator *(float lhs, NDArray rhs) { return Global.OP.Mul(rhs, lhs); }

        public static NDArray operator /(NDArray lhs, NDArray rhs)
        {
            return Global.OP.Div(lhs, rhs);
        }

        public static NDArray operator /(NDArray lhs, float rhs) { return Global.OP.Div(lhs, rhs); }

        public static NDArray operator /(float lhs, NDArray rhs) { return Global.OP.Div(rhs, lhs); }

        public static NDArray operator >(NDArray lhs, NDArray rhs) { return Global.OP.GreaterThan(lhs, rhs); }

        public static NDArray operator >(NDArray lhs, float rhs) { return Global.OP.GreaterThan(lhs, rhs); }

        public static NDArray operator <(NDArray lhs, NDArray rhs)
        {
            return Global.OP.GreaterThan(rhs, lhs);
        }

        public static NDArray operator <(NDArray lhs, float rhs)
        {
            NDArray rhs_t = NDArray.Constant(rhs, lhs.ElementType, lhs.shape);
            return Global.OP.GreaterThan(rhs_t, lhs);
        }

        public static NDArray operator >=(NDArray lhs, NDArray rhs) { return Global.OP.GreaterOrEqual(lhs, rhs); }

        public static NDArray operator >=(NDArray lhs, float rhs) { return Global.OP.GreaterOrEqual(lhs, rhs); }

        public static NDArray operator <=(NDArray lhs, NDArray rhs)
        {
            return Global.OP.GreaterOrEqual(rhs, lhs);
        }

        public static NDArray operator <=(NDArray lhs, float rhs)
        {
            NDArray rhs_t = NDArray.Constant(rhs, lhs.ElementType, lhs.shape);
            return Global.OP.GreaterOrEqual(rhs_t, lhs);
        }
        #endregion

        #region Implicit Methods
        public static implicit operator NDArray(Array d)
        {
            NDArray result = new NDArray(d.GetShape(), d.GetDType());
            result.LoadFrom(d);
            return result;
        }
        #endregion
    }
}
