using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ActionTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Equals()
        {
            Assert.That(new Action(ActionsEnum.MOVE_2_NEAREST_FEED), Is.EqualTo(new Action(ActionsEnum.MOVE_2_NEAREST_FEED)));
            Assert.That(new Action(ActionsEnum.MOVE_2_NEAREST_FEED), Is.Not.EqualTo(new Action(ActionsEnum.MOVE_AWAY_FROM_NEAREST_FEED)));
        }

    }
}
