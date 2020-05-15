using System;
using UnityEngine;

class CHpGreaterThan : MonoBehaviour, IConditionComponent
{
    public bool satisfies { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    [NonSerialized]
    public HpHolder hpHolder;
}