using System;
using UniRx;
using UnityEngine;

public class ComponentBuilder : MonoBehaviour
{
    private IMovable movable;
    [SerializeField]
    private GameObject movableObject;
    private IReproducible reproducible;
    [SerializeField]
    private GameObject reproducibleObject;
    [SerializeField]
    private HpHolder hpHolder;
    [SerializeField]
    private UnitParams unitParams;
    private IMasterData masterData;
    [SerializeField]
    private GameObject masterDataObject;

    private void Awake()
    {
        movable = movableObject.GetComponent<IMovable>() ?? throw new Exception();
        reproducible = reproducibleObject.GetComponent<IReproducible>() ?? throw new Exception();
        masterData = masterDataObject.GetComponent<IMasterData>() ?? throw new Exception();
    }

    public ILogicComponent FromLogic(ILogic logic)
    {
        var condition = logic.condition;
        var action = logic.action;
        var conditionComponent = FromCondition(condition);
        var actionComponent = FromAction(action);
        var logicComponent = gameObject.AddComponent<LogicComponent>();
        logicComponent.actionComponent = actionComponent;
        logicComponent.conditionComponent = conditionComponent;
        return logicComponent;
    }

    private IActionComponent FromAction(IAction action)
    {
        switch (action.actionsEnum)
        {

            case ActionsEnum.MOVE_2_NEAREST_FEED:
                {
                    //見えてなくても動けてしまうのを防ぐため、Conditionが設定したunitParamsを使って、感知した距離よりも遠くのFeedを取りにいかないようにしている
                    var collider = gameObject.AddComponent<SphereCollider>();
                    collider.isTrigger = true;
                    collider.radius = unitParams.FeedDetectedRadious;
                    AMove2NearestFeed component = gameObject.AddComponent<AMove2NearestFeed>();
                    component.movable = movable;
                    component.unitParams = unitParams;
                    return component;
                }
            case ActionsEnum.MOVE_AWAY_FROM_NEAREST_FEED:
                {
                    //上に同じ
                    var collider = gameObject.AddComponent<SphereCollider>();
                    collider.isTrigger = true;
                    collider.radius = masterData.UnitNearestSearchColliderRadius;
                    var component = gameObject.AddComponent<AMoveAwayFromNearestFeed>();
                    component.movable = movable;
                    return component;
                }
            case ActionsEnum.MOVE_RANDOMLY:
                {
                    var component = gameObject.AddComponent<AMoveRandomly>();
                    component.movable = movable;
                    return component;
                }
            case ActionsEnum.STOP:
                {
                    var component = gameObject.AddComponent<AStop>();
                    component.movable = movable;
                    return component;
                }
            case ActionsEnum.REPRODUCE:
                {
                    var component = gameObject.AddComponent<AReproduce>();
                    component.reproducible = reproducible;
                    return component;
                }
            default:
                throw new Exception("ActionEnumに対応する実装がありません");
        }
    }

    private IConditionComponent FromCondition(ICondition condition)
    {
        switch (condition.conditionsEnum)
        {
            case ConditionsEnum.FEED_NEAR:
                {
                    var collider = gameObject.AddComponent<SphereCollider>();
                    collider.isTrigger = true;
                    collider.radius = condition.param;
                    var component = gameObject.AddComponent<CFeedNear>();
                    component.collider = collider;
                    component.unitParams = unitParams;
                    component.unitParams_ = unitParams;
                    component.a = 2;
                    return component;
                }
            case ConditionsEnum.HP_LESS_THAN:
                {
                    var component = gameObject.AddComponent<CHpLessThan>();
                    component.hpHolder = hpHolder;
                    component.border = condition.param;
                    return component;
                }
            case ConditionsEnum.HP_GREATER_THAN:
                {
                    var component = gameObject.AddComponent<CHpGreaterThan>();
                    component.hpHolder = hpHolder;
                    component.border = condition.param;
                    return component;
                }
            case ConditionsEnum.DEFAULT:
                {
                    var component = gameObject.AddComponent<CDefault>();
                    return component;
                }
            default:
                throw new Exception("ConditionEnumに対応する実装がありません");
        }
    }
}
