using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RandomLogicTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Next()
        {
            var set = new HashSet<ILogic>();
            for (int i = 0; i < 100; i++)
            {
                set.Add(RandomLogic.Next());
            }
            Assert.That(set.Count, Is.GreaterThan(50));
            Assert.That(set.Count, Is.LessThan(100));
        }

    }
}
