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
        public void Method_Names_Are_Equal()
        {
            Tracer tracer1 = new Tracer(nameof(Program.ProgramMethod), nameof(Program));
            tracer1.StartTrace();
            Program.ProgramMethod();
            tracer1.StopTrace();

            TraceResult result1 = tracer1.GetTraceResult();

            Assert.AreEqual("ProgramMethod", result1.MethodName);
        }

        [TestMethod]
        public void Class_Names_Are_Equal()
        {
            Tracer tracer1 = new Tracer(nameof(Program.ProgramMethod), nameof(Program));
            tracer1.StartTrace();
            Program.ProgramMethod();
            tracer1.StopTrace();

            TraceResult result1 = tracer1.GetTraceResult();

            Assert.AreEqual("Program", result1.ClassName);
        }
    }
}
