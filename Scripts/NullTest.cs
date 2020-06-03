using System;
using UnityEngine;

public class NullTest : MonoBehaviour
{
    [NonSerialized]
    internal float a;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"{gameObject.name}{a}");
    }
}
