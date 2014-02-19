using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GenericSocketHelper;
using Rhino.Mocks;
using System.Reflection;
using ModelsContainer;


namespace UnitTests
{
    [TestFixture]
    public class UnitTests
    {            
        [Test]    
        public void TestNameOfModelAssembly()
        {
            Assembly asm = typeof(person).Assembly;
            string name = asm.GetName().Name;
            Assert.AreEqual("ModelsContainer", name);           
        }

    }
}
