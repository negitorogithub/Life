using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour
{
    public ILogics logics;
    public ILogicsComponent logicsComponent;
    public ComponentBuilder componentBuilder;
    void Start()
    {
        GenerateLogics();
        logics.List.ForEach(logic => logicsComponent.list.Add(componentBuilder.FromLogic(logic)));
    }

    private void GenerateLogics()
    {
        var logic = new Logic();
        var condition = new Condition();
        var action = new Action();
        condition.conditionsEnum = ConditionsEnum.FEED_NEAR;
        condition.param = 10;
        action.actionsEnum = ActionsEnum.MOVE_2_NEAREST_FEED;
        logic.condition = condition;
        logic.action = action;

        logics = new Logics();
        logics.List.Add(logic);

        logicsComponent = gameObject.AddComponent<LogicsComponent>();
    }
}
