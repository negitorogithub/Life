using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoroyOnHp0 : MonoBehaviour
{
    public HpHolder hpHolder;
    private void Update()
    {
        if (hpHolder.hp <= 0)
        {
            Destroy(hpHolder.gameObject);
        }
    }
}
