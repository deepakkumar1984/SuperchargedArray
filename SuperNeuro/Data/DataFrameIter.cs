namespace SuperNeuro.Data
{
    using SuperchargedArray;
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class DataFrameIter
    {
        private DataFrame frameX;
        private DataFrame frameY;
        private int batchSize { get; set; }
        private int current = 0;

        /// <summary>
        /// Gets the size of the data which is typically the number of records or images to be processed.
        /// </summary>
        /// <value>
        /// The size of the data.
        /// </value>
        public long DataSize
        {
            get
            {
                return frameX.Shape[0];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFrameIter"/> class.
        /// </summary>
        /// <param name="X">The X data frame.</param>
        /// <param name="Y">The Y data frame.</param>
        public DataFrameIter(DataFrame X, DataFrame Y = null)
        {
            frameX = X;
            frameY = Y;
            batchSize = 32;
            current = -batchSize;
        }

        /// <summary>
        /// Sets the size of the batch.
        /// </summary>
        /// <param name="_batchSize">Size of the batch.</param>
        public void SetBatchSize(int _batchSize)
        {
            batchSize = _batchSize;
            current = -batchSize;
        }

        /// <summary>
        /// Gets the next batch of data to process.
        /// </summary>
        /// <returns></returns>
        public (SuperArray, SuperArray) GetBatch()
        {
            SuperArray x = frameX.GetBatch(current, batchSize);
            SuperArray y = frameY.GetBatch(current, batchSize);

            return (x, y);
        }

        /// <summary>
        /// Gets the batch for X data frame.
        /// </summary>
        /// <returns></returns>
        public SuperArray GetBatchX()
        {
            SuperArray x = frameX.GetBatch(current, batchSize);
            return x;
        }

        /// <summary>
        /// Gets the batch Y data frame.
        /// </summary>
        /// <returns></returns>
        public SuperArray GetBatchY()
        {
            SuperArray y = frameY.GetBatch(current, batchSize);
            return y;
        }

        /// <summary>
        /// Navigates to next batch.
        /// </summary>
        /// <returns></returns>
        public bool Next()
        {
            current += batchSize;
            return current < frameX.Shape[0];
        }

        /// <summary>
        /// Resets this batch size.
        /// </summary>
        public void Reset()
        {
            current = -batchSize;
        }

        /// <summary>
        /// Splits the current dataset to train and test.
        /// </summary>
        /// <param name="testDataSize">Size of the test data.</param>
        /// <returns></returns>
        public (DataFrameIter, DataFrameIter) Split(double testDataSize = 0.33f)
        {
            int trainSize = Convert.ToInt32(frameX.Shape[0] * (1 - testDataSize));
            var trainX = frameX[0, trainSize];
            var valX = frameX[trainSize + 1, (int)frameX.Shape[0] - 1];

            var trainY = frameY[0, trainSize];
            var valY = frameY[trainSize + 1, (int)frameX.Shape[0] - 1];

            return (new DataFrameIter(trainX, trainY), new DataFrameIter(valX, valY));
        }

        /// <summary>
        /// Shuffles this data set randomly.
        /// </summary>
        public void Shuffle()
        {

        }
    }
}
