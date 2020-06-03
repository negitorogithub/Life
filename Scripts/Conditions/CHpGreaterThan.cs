using System;
using UnityEngine;

public class CHpGreaterThan : MonoBehaviour, IConditionComponent
{
    public bool satisfies { get; set; }
    public float border { get; set; }

    [NonSerialized]
    public HpHolder hpHolder;

    private void Update()
    {
        satisfies = hpHolder.hp > border;
    }
}