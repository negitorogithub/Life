using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicComponent : MonoBehaviour, ILogicComponent
{
    public IActionComponent actionComponent { get; set; }
    public IConditionComponent conditionComponent { get ; set ; }

    void ApplyLogic()
    {
        if (conditionComponent.satisfies) actionComponent.do_();
    }
}
