using System;
using UnityEngine;

public class CHpLessThan : MonoBehaviour, IConditionComponent
{
    public bool satisfies { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    [NonSerialized]
    public HpHolder hpHolder;
}