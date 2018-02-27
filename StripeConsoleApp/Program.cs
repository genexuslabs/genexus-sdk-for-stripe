using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StripeSDK;

namespace StripeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass testClass = new StripeConsoleApp.TestClass();
            testClass.TestBalance();
            //testClass.TestCreateSubscription();
            Console.Read();            
        }        
    }
}