using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp_4_0_Training
{
    [TestClass]
    public class Parameter_Overloading
    {
        
        /// <summary>
        /// Different scenarios of passing in the optional parameters vs. not
        /// </summary>
        [TestMethod]
        public void OptionalParameters()
        {
            Method(42, "The answer");
            Method(42);
            Method();
        }

        [TestMethod]
        public void NamedParameters()
        {
            Method(42, b: "The answer");            
            Method(b:"The answer given first", a:56);   // Can flip them around since they're named

            Method(b:GetB(), a:GetA());                 //the method calls are EAGER loaded in the order that they appear
        }

        [TestMethod]
        public void Constructor_OptionalParameters()
        {
            var x = new Rifle(model: "FAMAS");
            x.Output();

            var y = new Rifle();
            y.Output();

            // Infinite Loop do NOT comment this in!!
            //GetAttackPower();
        }

        private static int GetAttackPower()
        {
            var x = new Rifle(attackPower: GetAttackPower());
            return x.AttackPower;
        }

        /// <summary>
        /// Helper method for optional parameters demo
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void Method(int a = 20, string b = "Test")
        {
            Debug.WriteLine("a: {0}, b: {1}", a, b);
        }

        private int GetA()
        {
            Debug.WriteLine("Getting A");
            return 10;
        }
        private  string GetB()
        {
            Debug.WriteLine("Getting B");
            return "This is B";
        }

        private class Rifle
        {
            public Rifle(int attackPower = 100, string model="M16")
            {
                this.AttackPower = attackPower;
                this.Model = model;
            }

            public int AttackPower { get; set; }
            public string Model { get; set; }

            public void Output()
            {
                Debug.WriteLine("AttackPower: {0}, Model={1}", AttackPower, Model);
            }

        }
    }
}
