using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCL.Tensor
{
    internal class Storage : RefCounter
    {
        /// <summary>
        /// The buffer
        /// </summary>
        public IntPtr buffer;

        /// <summary>
        /// Gets the type of the element.
        /// </summary>
        /// <value>The type of the element.</value>
        public DType ElementType { get; private set; }
        /// <summary>
        /// Gets the element count.
        /// </summary>
        /// <value>The element count.</value>
        public long ElementCount { get; private set; }

        /// <summary>
        /// Gets the length of the byte.
        /// </summary>
        /// <value>The length of the byte.</value>
        public long ByteLength { get { return ElementCount * ElementType.Size(); } }

        /// <summary>
        /// Determines whether [is owner exclusive].
        /// </summary>
        /// <returns><c>true</c> if [is owner exclusive]; otherwise, <c>false</c>.</returns>
        public bool IsOwnerExclusive()
        {
            return this.GetCurrentRefCount() == 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CpuStorage"/> class.
        /// </summary>
        /// <param name="allocator">The allocator.</param>
        /// <param name="elementType">Type of the element.</param>
        /// <param name="elementCount">The element count.</param>
        public Storage(DType elementType, long elementCount)
        {
            this.ElementType = elementType;
            this.ElementCount = elementCount;
            this.buffer = Marshal.AllocHGlobal(new IntPtr(this.ByteLength));
        }

        /// <summary>
        /// This method is called when the reference count reaches zero. It will be called at most once to allow subclasses to release resources.
        /// </summary>
        protected override void Destroy()
        {
            Marshal.FreeHGlobal(buffer);
            buffer = IntPtr.Zero;
        }

        /// <summary>
        /// Locations the description.
        /// </summary>
        /// <returns>System.String.</returns>
        public string LocationDescription()
        {
            return "CPU";
        }

        /// <summary>
        /// PTRs at element.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>IntPtr.</returns>
        public IntPtr PtrAtElement(long index)
        {
            return new IntPtr(buffer.ToInt64() + (index * ElementType.Size()));
        }

        /// <summary>
        /// Gets the element as float.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>System.Single.</returns>
        /// <exception cref="NotSupportedException">Element type " + ElementType + " not supported</exception>
        public float GetElementAsFloat(long index)
        {
            unsafe
            {
                if (ElementType == DType.Float32) return ((float*)buffer.ToPointer())[index];
                else if (ElementType == DType.Float64) return (float)((double*)buffer.ToPointer())[index];
                else if (ElementType == DType.Int32) return (float)((int*)buffer.ToPointer())[index];
                else if (ElementType == DType.Byte) return (float)((byte*)buffer.ToPointer())[index];
                else
                    throw new NotSupportedException("Element type " + ElementType + " not supported");
            }
        }

        /// <summary>
        /// Sets the element as float.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="NotSupportedException">Element type " + ElementType + " not supported</exception>
        public void SetElementAsFloat(long index, float value)
        {
            unsafe
            {
                if (ElementType == DType.Float32) ((float*)buffer.ToPointer())[index] = value;
                else if (ElementType == DType.Float64) ((double*)buffer.ToPointer())[index] = value;
                else if (ElementType == DType.Int32) ((int*)buffer.ToPointer())[index] = (int)value;
                else if (ElementType == DType.Byte) ((byte*)buffer.ToPointer())[index] = (byte)value;
                else
                    throw new NotSupportedException("Element type " + ElementType + " not supported");
            }
        }

        /// <summary>
        /// Copies to storage.
        /// </summary>
        /// <param name="storageIndex">Index of the storage.</param>
        /// <param name="src">The source.</param>
        /// <param name="byteCount">The byte count.</param>
        public void CopyToStorage(long storageIndex, IntPtr src, long byteCount)
        {
            var dstPtr = PtrAtElement(storageIndex);
            MemoryCopier.Copy(dstPtr, src, (ulong)byteCount);
        }

        /// <summary>
        /// Copies from storage.
        /// </summary>
        /// <param name="dst">The DST.</param>
        /// <param name="storageIndex">Index of the storage.</param>
        /// <param name="byteCount">The byte count.</param>
        public void CopyFromStorage(IntPtr dst, long storageIndex, long byteCount)
        {
            var srcPtr = PtrAtElement(storageIndex);
            MemoryCopier.Copy(dst, srcPtr, (ulong)byteCount);
        }
    }
}
