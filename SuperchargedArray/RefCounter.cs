/*
MIT License

Copyright (c) 2019 Tech Quantum

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 
*/
namespace SuperchargedArray
{
    using System;
    using System.Threading;

    /// <summary>
    /// Provides a thread safe reference counting implementation. Inheritors need only implement the Destroy() method,
    /// which will be called when the reference count reaches zero. The reference count automatically starts at 1.
    /// </summary>
    internal abstract class RefCounter
    {
        /// <summary>
        /// The reference count
        /// </summary>
        private int refCount = 1;

        /// <summary>
        /// Construct a new reference counted object. The reference count automatically starts at 1.
        /// </summary>
        public RefCounter()
        {
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="RefCounter"/> class.
        /// </summary>
        ~RefCounter()
        {
            try
            {
                if (refCount > 0)
                {
                    Destroy();
                    refCount = 1;
                }
            }
            catch
            { }
        }

        /// <summary>
        /// This method is called when the reference count reaches zero. It will be called at most once to allow subclasses to release resources.
        /// </summary>
        protected abstract void Destroy();

        /// <summary>
        /// Returns true if the object has already been destroyed; false otherwise.
        /// </summary>
        /// <returns>true if the object is destroyed; false otherwise.</returns>
        protected bool IsDestroyed()
        {
            return refCount == 0;
        }

        /// <summary>
        /// Throws an exception if the object has been destroyed, otherwise does nothing.
        /// </summary>
        /// <exception cref="InvalidOperationException">Reference counted object has been destroyed</exception>
        protected void ThrowIfDestroyed()
        {
            if (IsDestroyed())
            {
                throw new InvalidOperationException("Reference counted object has been destroyed");
            }
        }

        /// <summary>
        /// Gets the current reference count.
        /// </summary>
        /// <returns>System.Int32.</returns>
        protected int GetCurrentRefCount()
        {
            return refCount;
        }

        /// <summary>
        /// Increments the reference count. If the object has previously been destroyed, an exception is thrown.
        /// </summary>
        /// <exception cref="InvalidOperationException">Cannot AddRef - object has already been destroyed</exception>
        public void AddRef()
        {
            int curRefCount;
            int original;
            var spin = new SpinWait();
            while (true)
            {
                curRefCount = refCount;
                if (curRefCount == 0) throw new InvalidOperationException("Cannot AddRef - object has already been destroyed");
                var desiredRefCount = curRefCount + 1;
                original = Interlocked.CompareExchange(ref refCount, desiredRefCount, curRefCount);
                if (original == curRefCount) break;
                spin.SpinOnce();
            }
        }

        /// <summary>
        /// Decrements the reference count. If the reference count reaches zero, the object is destroyed.
        /// If the object has previously been destroyed, an exception is thrown.
        /// </summary>
        /// <exception cref="InvalidOperationException">Cannot release object - object has already been destroyed</exception>
        public void Release()
        {
            int original;
            int curRefCount;
            var spin = new SpinWait();
            while (true)
            {
                curRefCount = refCount;
                if (curRefCount == 0) throw new InvalidOperationException("Cannot release object - object has already been destroyed");
                var desiredRefCount = refCount - 1;
                original = Interlocked.CompareExchange(ref refCount, desiredRefCount, curRefCount);
                if (original == curRefCount) break;
                spin.SpinOnce();
            }

            if (refCount <= 0)
                Destroy();
        }
    }
}
