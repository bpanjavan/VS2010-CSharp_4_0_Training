using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace CSharp_4_0_Training
{
    [TestClass]
    public class CoContraVariance
    {
        [TestMethod]
        public void CoVariance()
        {
            // cast string list as object list
            List<string> colString = new List<string>(new string[]{"alpha", "beta"});

            // can't do this
            //List<object> colObject = (List<object>)colString;
            // colObject.Add(42)

            // BUT can do this
            IEnumerable<object> colObject = (IEnumerable<object>)colString;
        }

        [TestMethod]
        public void ContraVariance()
        {
            Func<object> myFunction = () => "0";
            Func<string> myFunctionObject = (Func<string>)myFunction; // really I can do this?

        }

        [TestMethod]
        public void ContraVariance_2()
        {
            Func<object> myFunction = () => 42;

            // I can't believe this compiles
            DemoMethod((Func<string>)myFunction, "demo");
        }

        private void DemoMethod(Func<string> myFunctionThatReturnsString, string myString)
        {
            Debug.WriteLine(myFunctionThatReturnsString.Invoke());
        }

    }
}
