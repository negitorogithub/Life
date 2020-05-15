using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LogicsComponent : MonoBehaviour, ILogicsComponent
{
    public List<ILogicComponent> list { get; set; } = new List<ILogicComponent>();
    // Update is called once per frame
    void Update()
    {
        list.Find(logicComponent => logicComponent.conditionComponent.satisfies)?.actionComponent.do_();
    }
}
