using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp_4_0_Training
{
    [TestClass]
    public class Overload_Resolution
    {
        [TestMethod]
        public void Overload_Resolution_001()
        {
            DoSomething(25);            // One Param, overload resolution chooses strongly types int method over "loose" typed generic
            DoSomething(x : 37);        // Looks like COULD be 2 param, but resolves to one param
            DoSomething(25, y:45);        // Two Param
            DoSomething(y:45,x:25);     // Two Param
            //DoSomething(y: 87);         // won't compile missing non-optional param x

            DoSomething(x: 42.0);       // automatic infer double value
            DoSomething(true);          // generic
            DoSomething(g:65);          // name parameter explicitly, compiler decides to use generic version due to parameter name
        }

        private void DoSomething(int x)
        {
            Debug.WriteLine("One param (int) DoSomething: x={0}", x);
        }

        private void DoSomething(int x, int y = 20)
        {
            Debug.WriteLine("Two param DoSomething: x={0}, y={1}", x, y);
        }

        private void DoSomething(double x)
        {
            Debug.WriteLine("One param (double) DoSomething: x={0}", x);
           
        }

        private void DoSomething<T>(T g)
        {
            Debug.WriteLine("One param (generic) DoSomething: g={0}", g);

        }

        [TestMethod]
        public void Overload_Resolution_002()
        {
            var myRifle = new Rifle();
            Debug.WriteLine("Type of myRifle: {0}", myRifle.GetType().ToString());
            myRifle.Fire();

            var myAssaultRifle = new AssaultRifle();
            myAssaultRifle.Fire();
            var myAssaultRiflePoweredDown = (Rifle) myAssaultRifle;
            myAssaultRiflePoweredDown.Fire(power:10, magazine:5);   // this is weird
        }

        public class Rifle
        {
            public virtual void Fire(int power = 10, int magazine = 5)
            {
                Debug.WriteLine("Rifle firing, Power:{0}, Magazine:{1}", power, magazine);
            }


        }

        public class AssaultRifle : Rifle
        {
            public override void Fire(int magazine = 15, int power = 20)
            {
                Debug.WriteLine("Assuault Rifle firing, Power: {0}, Magazine:{1}", power, magazine);
            }
        }

    }
}











