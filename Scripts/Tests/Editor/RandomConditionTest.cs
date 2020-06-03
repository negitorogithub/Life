using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class RandomConditionTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Next()
        {
            var set = new HashSet<ICondition>();
            for (int i = 0; i < 100; i++)
            {
                set.Add(RandomCondition.Next());
            }
            Assert.That(set.Count, Is.GreaterThanOrEqualTo(50));
            Assert.That(set.Count, Is.LessThan(100));

        }
    }
}
