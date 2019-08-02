using System;
using System.Collections.Generic;
using System.Text;

namespace SuperNeuro.Engine
{
    /// <summary>
    /// Type of activation functions
    /// </summary>
    public enum ActType
    {
        /// <summary>
        /// The linear activation
        /// </summary>
        Linear,
        /// <summary>
        /// The Rectilinear activation
        /// </summary>
        ReLU,
        /// <summary>
        /// The sigmoid activation
        /// </summary>
        Sigmoid,
        /// <summary>
        /// The tanh activation
        /// </summary>
        Tanh,
        /// <summary>
        /// The elu activation
        /// </summary>
        Elu,
        /// <summary>
        /// The exponential activation
        /// </summary>
        Exp,
        /// <summary>
        /// The hard sigmoid activation
        /// </summary>
        HardSigmoid,
        /// <summary>
        /// The leaky ReLU activation
        /// </summary>
        LeakyReLU,
        /// <summary>
        /// The parameterized ReLU activation
        /// </summary>
        PReLU,
        /// <summary>
        /// The RReLU activation
        /// </summary>
        RReLU,

        /// <summary>
        /// The scaled elu activation
        /// </summary>
        SeLU,
        /// <summary>
        /// The softmax activation
        /// </summary>
        Softmax,
        /// <summary>
        /// The softplus activation
        /// </summary>
        Softplus,
        /// <summary>
        /// The soft sign activation
        /// </summary>
        SoftSign
    }

    /// <summary>
    /// Type of optimizer functions
    /// </summary>
    public enum OptimizerType
    {
        /// <summary>
        /// Stochastic gradient descent
        /// </summary>
        SGD,
        /// <summary>
        /// RMSProp Optimizer
        /// </summary>
        RMSprop,
        /// <summary>
        /// AdaGrad optimizer
        /// </summary>
        Adagrad,
        /// <summary>
        /// AdaDelta Optimizer
        /// </summary>
        Adadelta,
        /// <summary>
        /// The AdaMax optimizer
        /// </summary>
        Adamax,
        /// <summary>
        /// The adamAdam Optimizer
        /// </summary>
        Adam
    }

    public enum LossType
    {
        /// <summary>
        /// The mean squared error loss
        /// </summary>
        MeanSquaredError,
        /// <summary>
        /// The mean absolute error loss
        /// </summary>
        MeanAbsoluteError,
        /// <summary>
        /// The mean absolute percentage error
        /// </summary>
        MeanAbsolutePercentageError,
        /// <summary>
        /// The mean absolute log error loss
        /// </summary>
        MeanAbsoluteLogError,
        /// <summary>
        /// The squared hinge loss
        /// </summary>
        SquaredHinge,
        /// <summary>
        /// The hinge loss
        /// </summary>
        Hinge,
        /// <summary>
        /// The binary cross entropy loss
        /// </summary>
        BinaryCrossEntropy,
        /// <summary>
        /// The categorial cross entropy loss
        /// </summary>
        CategorialCrossEntropy,
        /// <summary>
        /// The CTC loss
        /// </summary>
        CTC,
        /// <summary>
        /// The kullback leibler divergence loss
        /// </summary>
        KullbackLeiblerDivergence,
        /// <summary>
        /// The log cosh loss
        /// </summary>
        Logcosh,
        /// <summary>
        /// The poisson loss
        /// </summary>
        Poisson,
        /// <summary>
        /// The cosine proximity loss
        /// </summary>
        CosineProximity
    }

    /// <summary>
    /// Types of metric functions
    /// </summary>
    public enum MetricType
    {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// The accuracy metric
        /// </summary>
        Accuracy,
        /// <summary>
        /// The binary accurary metric
        /// </summary>
        BinaryAccurary,
        /// <summary>
        /// The mean squared error metric
        /// </summary>
        MSE,
        /// <summary>
        /// The mean absolute  metric
        /// </summary>
        MAE,
        /// <summary>
        /// The mean absolute percentage metric
        /// </summary>
        MAPE,
        /// <summary>
        /// The mean square log metric
        /// </summary>
        MSLE
    }

    /// <summary>
    /// Type of pooling in layers
    /// </summary>
    public enum PoolingPoolType
    {
        /// <summary>
        /// Max Pooling
        /// </summary>
        Max,
        /// <summary>
        /// Average Pooling
        /// </summary>
        Avg
    }

    /// <summary>
    /// Types of padding used for images to add constant values to the borders
    /// </summary>
    public enum PaddingType
    {
        /// <summary>
        /// The valid which mean padding size = 1
        /// </summary>
        Valid,
        /// <summary>
        /// The same which means no padding
        /// </summary>
        Same,
        /// <summary>
        /// The full which means padding size = 2
        /// </summary>
        Full
    }
}
