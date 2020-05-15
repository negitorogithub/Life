using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AMove2NearestFeed : MonoBehaviour, IActionComponent
{ 
    [NonSerialized]
    public IMovable movable;
    [NonSerialized]
    public new Collider collider;
    [NonSerialized]
    public UnitParams unitParams;

    private List<GameObject> feedObjectsList = new List<GameObject>();

    public void do_()
    {
        var selfPosition = gameObject.transform.position;
        var sorted = feedObjectsList
            .Where(obj => obj != null)
            .OrderBy(obj => Vector3.Distance(obj.transform.position, selfPosition));
        if (sorted.ToList().Count == 0) return;
        var nearest = sorted.ElementAt(0);
        movable.Move2(nearest);
    }

    private void OnTriggerEnter(Collider other)
    {
        var feed = other.gameObject.GetComponent<IFeed>();
        if (feed == null) return;
        feedObjectsList.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        var feed = other.gameObject.GetComponent<IFeed>();
        if (feed == null) return;
        feedObjectsList.Remove(other.gameObject);
    }


}