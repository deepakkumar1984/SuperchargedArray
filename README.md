# SuperchargedArray

The .NET default built-in System.Array is very limited in terms of processing and usability. Here is the extended version of the Array with accelerated speed to execute operations on almost any hardware supporting OpenCL like Intel CPU, NVIDIA, AMD, Intel GPU, FPGA etc.

## Easy to use:
Create an array and perform some math operations. Currenly supporting float and double. 

Below is how you will do in .NET standard Array. I am trying to implement a math operation for 3x2 Matrix array with elementwise operations. 

```csharp

//Create an array with values
Array a = new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };

//Create a array with constant value 2
Array b = new float[3, 2];
for (int i = 0; i < b.GetLength(0); i++)
{
    for (int j = 0; j < b.GetLength(1); j++)
    {
        b.SetValue(2, i, j);
    }
}

//Perform Math operation on the array: 2A + Log(B) + Exp(A)
Array r = new float[3, 2];
for (int i = 0; i < b.GetLength(0); i++)
{
    for (int j = 0; j < b.GetLength(1); j++)
    {
        float A = (float)a.GetValue(i, j);
        float B = (float)b.GetValue(i, j);

        float rvalue = 2 * A - MathF.Log(B) + MathF.Exp(A);
        r.SetValue(rvalue, i, j);
    }
}

//Print the Array
for (int i = 0; i < r.GetLength(0); i++)
{
    for (int j = 0; j < r.GetLength(1); j++)
    {
        Console.Write(r.GetValue(i, j) + "  ");
    }

    Console.WriteLine();
}
```

A super simplified version with SuperchargedArray
```csharp
var K = Global.OP;
//Create an array with values
SuperArray a = new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };

//Create a array with constant value 2
SuperArray b = new float[3, 2];
//SuperArray b = new SuperArray(3, 2);
b.Fill(2);

//Perform Math operation on the array: 2A + Log(B) + Exp(A)
var r = 2 * a - K.Log(b) + K.Exp(a);

//Print the Array
r.Print();
```


## Accelerated Version
SuperchargedArray is not all about simplicity, it is well defined to execute the code on special hardwares like Intel GPU, NVIDIA, AMD cards. Below is the simple performance test done to process 100 million executions. And see the result:

```csharp
public void Run()
{
    int count = 100000000;
    Random rnd = new Random();

    //Create variable A with random values
    float[] a = new float[count];
    Parallel.For(0, count, (i) => {
        a[i] = (float)rnd.NextDouble();
    });

    //Create variable B with constant value 0.5
    float[] b = new float[count];
    Parallel.For(0, count, (i) => {
        b[i] = 0.5f;
    });

    RunStandardLoop(count, a, b);
    Console.WriteLine();

    var devices = Accelerator.Devices;
    foreach (var item in devices)
    {
        RunArrayAccelerated(count, a, b, item.ID);
        Console.WriteLine();
    }

    RunArrayDefault(count, a, b, 33);
    RunArrayDefault(count, a, b, 66);
    RunArrayDefault(count, a, b, 100);
    Console.WriteLine();
}

public void RunStandardLoop(int count, Array a, Array b)
{
    Stopwatch sw = new Stopwatch();
    sw.Start();

    //Execute math operation Truncate(a * Sin(b) + Cos(a) * Exp(b)) and store the result to R
    Array r = new float[count];
    for (int i = 0; i < count; i++)
    {
        var rv = MathF.Truncate((float)a.GetValue(i) * MathF.Sin((float)b.GetValue(i)) + MathF.Cos((float)a.GetValue(i)) * MathF.Exp((float)b.GetValue(i)));
        r.SetValue(rv, i);
    }

    sw.Stop();
    Console.WriteLine(".NET For Loop Time (in ms): " + sw.ElapsedMilliseconds);
}

public void RunArrayDefault(int count, SuperArray a, SuperArray b, int cpu)
{
    SuperchargedArray.Accelerated.Global.UseDefault(cpu);
    Stopwatch sw = new Stopwatch();
    sw.Start();

    var K = SuperchargedArray.Global.OP;

    var r = K.Trunc(a * K.Sin(b) + K.Cos(a) * K.Exp(b));
    sw.Stop();

    Console.WriteLine("With Parallel Thread Time (in ms): {1}", cpu, sw.ElapsedMilliseconds);
}

public void RunArrayAccelerated(int count, SuperArray a, SuperArray b, int deviceid)
{
    try
    {
        Accelerator.UseDevice(deviceid);
        Stopwatch sw = new Stopwatch();
        sw.Start();

        var K = SuperchargedArray.Accelerated.Global.OP;

        var r = K.Trunc(a * K.Sin(b) + K.Cos(a) * K.Exp(b));
        sw.Stop();

        Console.WriteLine("With Accelerator (in ms): " + sw.ElapsedMilliseconds);
        Accelerator.Dispose();
    }
    catch(Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}
```

### Execution Result:

Test result to execute math ops y = trunc(a * Sin(b) + cos(a) * exp(b)) for 100 million elements

.NET For Loop Time (in ms): 22317

GeForce GTX 1080 Ti                    : 8741 ms

Intel(R) UHD Graphics 630              : 6723 ms

Intel(R) Core(TM) i7-8700 CPU @ 3.20GHz: 7380 ms

33% of CPU parallel processing                  : 14332 ms

66% of CPU parallel processing                  : 7716 ms

100% of CPU parallel processing:				: 6420 ms

The .NET standard loop takes about 22 seconds, whereas with 100% CPU parallel approach using ArrayExtension it finishes off in 6 sec which is one-fourth of time taken. But for long running process using full CPU is not ideal. With ArrayExtension.Accelerated, which internally uses SIMD (Single Instruction Multiple Data), you can achive greater speed without using 100% of the hardware. But you can always fine-tune to use 100% of the hardware and achieve ultimate speed.

