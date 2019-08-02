using Deedle;
using SuperchargedArray;
using SuperNeuro;
using SuperNeuro.Data;
using SuperNeuro.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperNeruro.Examples
{
    class BostonHousing
    {
        public static void Run()
        {
            var (x, y) = LoadTrain();
            var test = LoadTest();
            Sequential model = new Sequential();
            model.Add(new Dense(13, activation: SuperNeuro.Engine.ActType.ReLU));
            model.Add(new Dense(26, activation: SuperNeuro.Engine.ActType.ReLU));
            model.Add(new Dense(1));

            model.EpochEnd += Model_EpochEnd;
            model.Compile(SuperNeuro.Engine.OptimizerType.Adam, SuperNeuro.Engine.LossType.MeanSquaredError, SuperNeuro.Engine.MetricType.MAE);
            model.Train(new SuperNeuro.Data.DataFrameIter(x, y), 100, 32);

        }

        private static void Model_EpochEnd(object sender, SuperNeuro.Events.EpochEndEventArgs e)
        {
            Console.WriteLine("Epoch: {0}, Loss: {1}, Metric: {2}", e.Epoch, e.Loss, e.Metric);
        }

        private static (DataFrame, DataFrame) LoadTrain()
        {
            //Using deedle which is similar to Pandas in python
            var frame = Frame.ReadCsv("./BostonHousing/train.csv", true);
            frame.DropColumn("ID");

            //Load Deedle frame to Tensor frame
            var yData = frame["medv"].Values.Select(i => ((float)i)).ToArray();

            frame.DropColumn("medv");
            var data = frame.ToArray2D<float>().Cast<float>().ToArray();

            var x = new DataFrame2D(frame.ColumnCount);
            x.Load(data);

            var y = new DataFrame2D(1);
            y.Load(yData);

            return (x, y);
        }

        private static DataFrame LoadTest()
        {
            //Using deedle which is similar to Pandas in python
            var frame = Frame.ReadCsv("./BostonHousing/test.csv", true);
            frame.DropColumn("ID");

            //Load Deedle frame to Tensor frame
            var data = frame.ToArray2D<float>().Cast<float>().ToArray();
            var test = new DataFrame2D(frame.ColumnCount);
            test.Load(data);

            return test;
        }
    }
}
