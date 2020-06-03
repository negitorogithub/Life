using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ConditionTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Equals()
        {
            Assert.That(new Condition(), Is.EqualTo(new Condition()));
            Assert.That(new Condition(ConditionsEnum.DEFAULT), Is.EqualTo(new Condition(ConditionsEnum.DEFAULT)));
            Assert.That(new Condition(ConditionsEnum.FEED_NEAR), Is.EqualTo(new Condition(ConditionsEnum.FEED_NEAR)));
            Assert.That(new Condition(ConditionsEnum.FEED_NEAR, 10), Is.EqualTo(new Condition(ConditionsEnum.FEED_NEAR,10)));
            Assert.That(new Condition(ConditionsEnum.FEED_NEAR, 10), Is.Not.EqualTo(new Condition(ConditionsEnum.FEED_NEAR,33)));
        }
    }
}
