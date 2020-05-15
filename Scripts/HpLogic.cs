using UnityEngine;
using UniRx;
using System;

public class HpLogic : MonoBehaviour
{
    public GameObject IEatsObject;
    public GameObject IReproducibleObject;
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
        IReproducible reproducible = IReproducibleObject.GetComponent<IReproducible>() ?? throw new Exception("IReproducibleObjectはIReproducibleを継承してください");
        reproducible.reproducedSubject.Subscribe(_ => hpHolder.hp -= masterData.ReproductionHpDecrease);
    }
    // Update is called once per frame
    void Update()
    {
        hpHolder.hp -= LivingHpDecrease(Time.deltaTime);
        hpHolder.hp -= MovingHpDecrease(rigidBody.velocity.magnitude * Time.deltaTime);
    }

    public float LivingHpDecrease(float deltaTimeSecond)
    {
        return masterData.LivingHpDecreasePerSecond * deltaTimeSecond;
    }   

    public float MovingHpDecrease(float deltaMeter)
    {
        return masterData.MovingHpDecreasePerMeter * deltaMeter;
    }
}

