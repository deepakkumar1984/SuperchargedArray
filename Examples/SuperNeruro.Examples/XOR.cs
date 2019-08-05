using SuperNeuro;
using SuperNeuro.Data;
using SuperNeuro.Layers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperNeruro.Examples
{
    public class XOR
    {
        public static void Run()
        {
            var (x, y) = LoadTrain();
            Sequential model = new Sequential();
            model.Add(new Dense(32, activation: SuperNeuro.Engine.ActType.ReLU));
            model.Add(new Dense(32, activation: SuperNeuro.Engine.ActType.ReLU));
            model.Add(new Dense(1, activation: SuperNeuro.Engine.ActType.Sigmoid));

            model.EpochEnd += Model_EpochEnd;
            model.Compile(SuperNeuro.Engine.OptimizerType.Adam, SuperNeuro.Engine.LossType.BinaryCrossEntropy, SuperNeuro.Engine.MetricType.BinaryAccurary);
            model.Train(new SuperNeuro.Data.DataFrameIter(x, y), 100, 32);

            var test = model.Predict(LoadTest());
            test.Head();

        }

        private static void Model_EpochEnd(object sender, SuperNeuro.Events.EpochEndEventArgs e)
        {
            Console.WriteLine("Epoch: {0}, Loss: {1}, Metric: {2}", e.Epoch, e.Loss, e.Metric);
        }

        private static (DataFrame, DataFrame) LoadTrain()
        {
            var x = new DataFrame2D(2);
            x.Load(new float[] { 0, 0, 0, 1, 1, 0, 1, 1 });

            var y = new DataFrame2D(1);
            y.Load(new float[] { 0, 1, 1, 0 });

            return (x, y);
        }

        private static DataFrame LoadTest()
        {
            var x = new DataFrame2D(2);
            x.Load(new float[] { 0, 1, 1, 1 });

            return x;
        }

    }
}
