using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class LogicsComponent : MonoBehaviour, ILogicsComponent
{
    public List<ILogicComponent> list { get; set; } = new List<ILogicComponent>();
    // Update is called once per frame
    void Start()
    {
        Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(_ =>
        {
            list.Find(logicComponent => logicComponent.conditionComponent.satisfies)?.actionComponent.do_();
        });
    }
}
