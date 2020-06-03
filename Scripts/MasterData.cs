using UnityEngine;
public class MasterData : MonoBehaviour, IMasterData
{
    [field: SerializeField]
    public float UnitHp { get; set; }

    [field: SerializeField]
    public float Speed { get; set; }

    [field: SerializeField]
    public float FeedHpIncrease { get; set; }

    [field: SerializeField]
    public float LivingHpDecreasePerSecond { get; set; }

    [field: SerializeField]
    public float MovingHpDecreasePerMeter { get; set; }

    [field: SerializeField]
    public float ReproductionHpDecrease { get; set; }

    [field: SerializeField]
    public float RandomMoveIntervalSecond { get; set; }
    [field: SerializeField]
    public float UnitNearestSearchColliderRadius { get; set; }
    [field: SerializeField]
    public float PopFeedIntervalSecond { get; set; }
}