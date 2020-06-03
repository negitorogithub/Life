using UnityEngine;

public class CDefault : MonoBehaviour, IConditionComponent
{
    public bool satisfies { get; set; } = true;
}