using System;
using System.Diagnostics;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTest
{
    [TestClass]
    public class AssemblyStartupCleaner
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Debug.WriteLine("Inside assembly initializer");            
        }

        [AssemblyCleanup]
        public static void AssemblyDone()
        {
            Debug.WriteLine("Inside assembly cleanup");
        }
    }
}
