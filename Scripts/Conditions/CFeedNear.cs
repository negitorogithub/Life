using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CFeedNear : MonoBehaviour, IConditionComponent
{
    [NonSerialized]
    public new SphereCollider collider;

    public bool satisfies { get; set; }

    [NonSerialized]
    public UnitParams unitParams;

    private List<GameObject> feedObjectsList = new List<GameObject>();

    private void Update()
    {
        feedObjectsList = feedObjectsList.Where(obj => obj != null).ToList();
        satisfies = feedObjectsList.Count >= 1;
        if (satisfies)
        {
            unitParams.FeedDetectedRadious = collider.radius;
        }
        else
        {
            unitParams.FeedDetectedRadious = 0;
        }
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
