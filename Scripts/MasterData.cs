using UnityEngine;
using UnityEditor;

public class MasterData : IMasterData
{
    public float UnitHp { get; set; }
    public float Speed { get; set; }
    public float FeedHpIncrease { get; set; }
    public float LivingHpDecreasePerSecond { get; set; }
    public float MovingHpDecreasePerMeter { get; set; }
    public float ReproductionHpDecrease { get; set; }
}