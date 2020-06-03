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
        logics = new Logics();
        for (int i = 0; i < 3; i++)
        {
            var logic = RandomLogic.Next();
            logics.List.Add(logic);
            Debug.Log(logic);
        }

        /*
        {
            var condition = new Condition(ConditionsEnum.FEED_NEAR, 40);
            var action = new Action(ActionsEnum.MOVE_2_NEAREST_FEED);
            var logic = new Logic(condition, action);
            logics.List.Add(logic);
        }
        {
            var condition = new Condition(ConditionsEnum.HP_GREATER_THAN, 120);
            var action = new Action(ActionsEnum.REPRODUCE);
            var logic = new Logic(condition, action);
            logics.List.Add(logic);
        }
        {
            var condition = new Condition(ConditionsEnum.DEFAULT);
            var action = new Action(ActionsEnum.STOP);
            var logic = new Logic(condition, action);
            logics.List.Add(logic);
        }
        */
        logicsComponent = gameObject.AddComponent<LogicsComponent>();
    }
}
