using System;
using UnityEngine;

public class HpHolder : MonoBehaviour
{
    [NonSerialized]
    public float maxHp;
    [NonSerialized]
    public float hp;
    public GameObject masterDataObject;
    private IMasterData masterData;

    void Start()
    {
        masterData = masterDataObject.GetComponent<IMasterData>() ?? throw new Exception();
        maxHp = hp = masterData.UnitHp;
    }

}
