using UnityEngine;
using UniRx;
using System;

public class HpLogic : MonoBehaviour
{
    public GameObject IEatsObject;
    public GameObject IMasterDataObject;
    public HpHolder hpHolder;
    private Rigidbody rigidBody;
    private IMasterData masterData;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>() ?? throw new Exception("RigidBodyをアタッチしてください");

        masterData = IMasterDataObject.GetComponent<IMasterData>() ?? throw new Exception("IMasterDataObjectはIMasterDataを継承してください");

        IEats iEats = IEatsObject.GetComponent<IEats>() ?? throw new Exception("IEatsはIEatsを継承してください");
        iEats.EatedSubject.Subscribe(
            _ => hpHolder.hp += masterData.FeedHpIncrease);
    }

    // Update is called once per frame
    void Update()
    {
        hpHolder.hp -= LivingHpDecrease(Time.deltaTime);
        hpHolder.hp -= MovingHpDecrease(rigidBody.velocity.magnitude * Time.deltaTime);
        Debug.Log(hpHolder.hp);
    }

    float LivingHpDecrease(float deltaTime)
    {
        return masterData.LivingHpDecreasePerSecond * deltaTime;
    }   

    float MovingHpDecrease(float deltaMeter)
    {
        return masterData.MovingHpDecreasePerMeter * deltaMeter;
    }
}

