using System;
using NUnit.Framework;

namespace Sakura.Core.Bodies.Tests
{
    [TestFixture]
    public class A_body
    {
        [Test]
        public void Throws_when_created_with_the_nil_UUID()
        {
            var ID = Guid.Empty;
            Assert.Throws<ArgumentException>(() =>
            {
                new Body(ID);
            });
        }
    }
}
