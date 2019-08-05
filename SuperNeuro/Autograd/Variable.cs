using SuperchargedArray;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SuperNeuro.Autograd
{
    public class Variable
    {
        private static Variable instance = null;

        private static readonly object padlock = new object();

        private SuperArray Data { get; set; }

        private Func<List<Variable>, Variable> GradFunc;

        private static List<Variable> DAG;

        private List<Variable> inputs;

        private List<Variable> grads;

        private static Dictionary<string, bool> caches;

        public bool CalcGrad { get; set; }

        public bool IsGradAvailable
        {
            get
            {
                if (!instance.CalcGrad)
                    return false;

                return instance.grads.Count >= 1;

            }
        }

        public static Variable Instance(SuperArray data, bool calcGrad = true)
        {
            lock(padlock)
            {
                if(instance == null)
                {
                    instance = new Variable(data, calcGrad);
                }

                return instance;
            }
        }

        internal Variable(SuperArray data, bool calcGrad = true)
        {
            Data = data;
            CalcGrad = calcGrad;

            grads = new List<Variable>();
            inputs = new List<Variable>();
            ID = new Guid().ToString();
            DAG = new List<Variable>();
            caches = new Dictionary<string, bool>();
        }

        public SuperArray Array()
        {
            return Data;
        }

        public Variable Grad()
        {
            if (!instance.CalcGrad)
                throw new Exception("Gradient calculation disabled!");

            if (instance.grads.Count == 0)
                throw new Exception("Gradient hasn't been calculated yet.");

            return instance.grads[0];
        }

        public string ID
        {
            get; set;
        }

        public Shape Shape
        {
            get
            {
                return Data.Shape;
            }
        }

        public Type DType
        {
            get
            {
                return Data.DataType;
            }
        }

        public void ZeroGrad()
        {
            instance.grads.Clear();
        }

        public void SetCalcGrad(bool calcGrad)
        {
            CalcGrad = calcGrad;
        }

        public void AddGrad(Variable childGrad)
        {
            if (CalcGrad)
                instance.grads.Add(childGrad);
        }

        public void CalcGradInputs(bool retain_grad_graph = false)
        {
            EvalGrad();
            if(instance.GradFunc != null)
            {
                instance.grads[0] = instance.GradFunc(instance.inputs);
            }
        }

        public void Backward(Variable grad, bool retain_grad_graph = false)
        {
            AddGrad(grad);
            List<Variable> dag = Variable.Build(this);
            foreach (var item in dag)
            {
                item.CalcGradInputs(retain_grad_graph);
            }
        }

        public void Backward(bool retain_grad_graph = false)
        {
            var ones = new Variable(SuperArray.Constant(1, Shape), false);
            Backward(ones, retain_grad_graph);
        }

        private void EvalGrad(bool retain_grad_graph = false)
        {
            if (!instance.CalcGrad)
                return;

            Variable grad = instance.grads[0];
            if(instance.grads.Count > 1)
            {
                for(int i=1;i<instance.grads.Count;i++)
                {
                    grad.Data = grad.Data + instance.grads[i].Data;
                }
            }

            grad.SetCalcGrad(retain_grad_graph);
            instance.grads = new List<Variable>() { grad };
        }

        private List<Variable> GetInputs()
        {
            return instance.inputs;
        }

        private static void BuildSubGraph(Variable var)
        {
            string id = var.ID;
            if (caches.Keys.ToList().IndexOf(id) != caches.Count - 1)
            {
                return;
            }

            foreach (var input in var.GetInputs())
            {
                Variable.BuildSubGraph(input);
            }

            caches[id] = true;
            DAG.Add(var);
        }

        private static List<Variable> Build(Variable var)
        {
            BuildSubGraph(var);
            return DAG;
        }
    }
}

