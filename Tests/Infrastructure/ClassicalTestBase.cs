using Kata.App.Infastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.Tests.Infrastructure
{
    public class ClassicalTestBase<T>
        where T : class
    {
        protected T SUT;
        
        [TestInitialize]
        public void Init()
        {
            var container = IoCConfiguration.BuildContainer();
            SUT = container.GetInstance<T>();

            Arrange();
            Act();
        }

        [TestCleanup]
        public void TestCleanup() 
        {
            Finally();
        }

        public virtual void Arrange() {}
        public virtual void Act() {}
        public virtual void Finally() {}
    }
}