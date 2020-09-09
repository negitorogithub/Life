using System;
public class RandomCondition
{
    private const int MinHp = 0;
    private const int DefaultHp = 100;
    private static readonly Random random = RandomGlobal.random;

    public static ICondition Next()
    {
        var result = new Condition();
        result.conditionsEnum = RandomEnumValue<ConditionsEnum>();
        switch (result.conditionsEnum)
        {
            case ConditionsEnum.FEED_NEAR:
                result.param = UnityEngine.Random.Range(0, 100);
                break;
            case ConditionsEnum.HP_LESS_THAN:
                result.param = UnityEngine.Random.Range(MinHp, DefaultHp);
                break;
            case ConditionsEnum.HP_GREATER_THAN:
                result.param = UnityEngine.Random.Range(MinHp, DefaultHp);
                break;
            case ConditionsEnum.DEFAULT:
                break;
            default:
                break;
        }
        return result;
    }
    static T RandomEnumValue<T>()
    {
        var v = Enum.GetValues(typeof(T));
        return (T)v.GetValue(random.Next(v.Length));
    }
}
