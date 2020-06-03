using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class RandomActionTest
    {
        [Test]
        public void Next()
        {
            var set = new HashSet<IAction>();
            for (int i = 0; i < 100; i++)
            {
                set.Add(RandomAction.Next());
            }
            Assert.That(set.Count, Is.EqualTo(Enum.GetValues(typeof(ActionsEnum)).Length));
        }
    }
}
