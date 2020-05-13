public interface IMasterData
{

    float UnitHp { get; set; }

    float Speed { get; set; }
    float FeedHpIncrease { get; set; }
    float LivingHpDecreasePerSecond { get; set; }
    float MovingHpDecreasePerMeter { get; set; }
    float ReproductionHpDecrease { get; set; }
    float RandomMoveIntervalSecond { get; set; }
}
