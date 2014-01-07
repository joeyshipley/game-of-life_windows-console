using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.Tests.Infrastructure
{
    public class MockistTestBase<T>
        where T : class
    {
        protected AutoMoqer Mocks;
        protected T SUT;
        
        [TestInitialize]
        public void Init()
        {
            Mocks = new AutoMoqer();
            SUT = Mocks.Resolve<T>();

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