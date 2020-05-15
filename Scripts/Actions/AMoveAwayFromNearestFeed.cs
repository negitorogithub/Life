using System;
using UnityEngine;

public class AMoveAwayFromNearestFeed : MonoBehaviour, IActionComponent
{
    [NonSerialized]
    public IMovable movable;
    [NonSerialized]
    public new Collider collider;
    public void do_()
    {

    }
}