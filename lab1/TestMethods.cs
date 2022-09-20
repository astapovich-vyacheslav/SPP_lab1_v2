using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerLib;

namespace lab1
{
    public class TestMethods
    {
        public void SlowPower(int x, int p)
        {
            int result = 1;
            for (int i = 0; i < p; i++)
                result *= x;
            //return result;
        }

        public void FastPower(int x, int p)
        {
            int result = 1;
            while (p != 0)
            {
                if (p % 2 == 1)
                {
                    result *= x;
                }
                x *= x;
                p /= 2;
            }
            //return result;
        }

        public void InternalMethod1()
        {
            for (int i = 0; i < 100; i++)
                if (i % 7 == 0)
                    for (int j = i; j > 0; j--) { }
            //return new MethodInfo();
        }

        public void InternalMethod2()
        {
            for (int i = 0; i < 1000; i++)
                if (i % 7 == 0)
                    for (int j = i; j > 0; j--) { }
            //return new MethodInfo();
        }

        public MethodInfo Execute(Action method, string name)
        {
            Tracer tracer = new Tracer(name, GetType().ToString());
            tracer.StartTrace();
            method();
            tracer.StopTrace();
            return new MethodInfo(tracer.GetTraceResult());
        }

        public MethodInfo ExternalMethod()
        {
            var outputObject = new MethodInfo();
            MethodInfo objectToAdd = Execute(InternalMethod1, nameof(InternalMethod1));
            outputObject.InnerMethods.Add(objectToAdd);
            objectToAdd = Execute(InternalMethod2, nameof(InternalMethod2));
            outputObject.InnerMethods.Add(objectToAdd);
            return outputObject;
        }
    }
}
