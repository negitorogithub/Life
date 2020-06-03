using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class LogicTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Equals()
        {
            Assert.That(new Logic(), Is.EqualTo(new Logic()));
            Assert.That(new Logic(new Condition()), Is.EqualTo(new Logic(new Condition())));
            Assert.That(new Logic(action: new Action()), Is.EqualTo(new Logic(action: new Action())));
            Assert.That(new Logic(new Condition(),new Action()), Is.EqualTo(new Logic(new Condition(), new Action())));
            Assert.That(new Logic(new Condition(ConditionsEnum.DEFAULT),new Action()), Is.EqualTo(new Logic(new Condition(ConditionsEnum.DEFAULT), new Action())));
            
            Assert.That(new Logic(new Condition(ConditionsEnum.DEFAULT),new Action(ActionsEnum.REPRODUCE)), 
                Is.EqualTo(new Logic(new Condition(ConditionsEnum.DEFAULT), new Action(ActionsEnum.REPRODUCE))));

            Assert.That(new Logic(new Condition(ConditionsEnum.HP_GREATER_THAN, 10), new Action(ActionsEnum.REPRODUCE)),
                Is.EqualTo(new Logic(new Condition(ConditionsEnum.HP_GREATER_THAN, 10), new Action(ActionsEnum.REPRODUCE))));   

            Assert.That(new Logic(new Condition(ConditionsEnum.HP_GREATER_THAN), new Action(ActionsEnum.REPRODUCE)),
                Is.Not.EqualTo(new Logic(new Condition(ConditionsEnum.DEFAULT), new Action(ActionsEnum.REPRODUCE))));

            Assert.That(new Logic(new Condition(ConditionsEnum.HP_GREATER_THAN, 10), new Action(ActionsEnum.REPRODUCE)),
                Is.Not.EqualTo(new Logic(new Condition(ConditionsEnum.HP_GREATER_THAN, 33), new Action(ActionsEnum.REPRODUCE))));

            Assert.That(new Logic(new Condition(ConditionsEnum.HP_GREATER_THAN), new Action(ActionsEnum.REPRODUCE)),
                Is.Not.EqualTo(new Logic(new Condition(ConditionsEnum.HP_GREATER_THAN), new Action(ActionsEnum.STOP))));

        }
    }
}
