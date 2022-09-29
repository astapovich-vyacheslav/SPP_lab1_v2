using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TracerLib;
using lab1;
using System.IO;
using System.Runtime;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FastPower_Faster_Than_SlowPower()
        {

            TestMethods tests = new TestMethods();
            Tracer tracer1 = new Tracer(nameof(tests.SlowPower), nameof(Tracer));
            tracer1.StartTrace();
            tests.SlowPower(2, 100000);
            tracer1.StopTrace();

            Tracer tracer2 = new Tracer(nameof(tests.FastPower), nameof(Tracer));
            tracer2.StartTrace();
            tests.FastPower(2, 100000);
            tracer2.StopTrace();

            TraceResult result1 = tracer1.GetTraceResult(), result2 = tracer2.GetTraceResult();
            
            Assert.IsTrue(result1.Time > result2.Time);
        }

        [TestMethod]
        public void ExternalMethod_Slower_Than_InternalMethod()
        {
            TestMethods tests = new TestMethods();
            Tracer tracer1 = new Tracer(nameof(tests.ExternalMethod), nameof(Tracer));
            tracer1.StartTrace();
            tests.ExternalMethod();
            tracer1.StopTrace();

            Tracer tracer2 = new Tracer(nameof(tests.InternalMethod1), nameof(Tracer));
            tracer2.StartTrace();
            tests.InternalMethod1();
            tracer2.StopTrace();

            TraceResult result1 = tracer1.GetTraceResult(), result2 = tracer2.GetTraceResult();

            Assert.IsTrue(result1.Time > result2.Time);
        }

        [TestMethod]
        public void Time_For_Separate_Methods_Equals_Time_For_Conjucted_Methods()
        {
            TestMethods tests = new TestMethods();
            Tracer tracer1 = new Tracer(nameof(tests.InternalMethod1), nameof(Tracer));
            tracer1.StartTrace();
            tests.InternalMethod1();
            tracer1.StopTrace();

            Tracer tracer2 = new Tracer(nameof(tests.InternalMethod2), nameof(Tracer));
            tracer2.StartTrace();
            tests.InternalMethod2();
            tracer2.StopTrace();

            Tracer tracer3 = new Tracer(nameof(tests.InternalMethod1), nameof(Tracer));
            tracer3.StartTrace();
            tests.InternalMethod1();
            tests.InternalMethod2();
            tracer3.StopTrace();

            TraceResult result1 = tracer1.GetTraceResult(), result2 = tracer2.GetTraceResult(), result3 = tracer3.GetTraceResult();
            Console.WriteLine(result1.Time);
            Console.WriteLine(result2.Time);
            int separateTime = result1.Time + result2.Time;
            int conjuctedTime = result3.Time;
            Assert.IsTrue(separateTime < conjuctedTime + 10 && separateTime > conjuctedTime - 10);
        }
    }
}
