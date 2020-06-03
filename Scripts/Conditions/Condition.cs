public class Condition : ICondition
{
    public Condition(ConditionsEnum? conditionsEnum = null, float? param = null)
    {
        if (conditionsEnum.HasValue)
        {
            this.conditionsEnum = (ConditionsEnum)conditionsEnum;
        }

        if (param.HasValue)
        {
            this.param = (float)param;
        }
    }

    public ConditionsEnum conditionsEnum { get; set; }
    public float param { get; set; }

    public override bool Equals(object obj)
    {
        return obj is Condition condition &&
                 conditionsEnum == condition.conditionsEnum &&
                 param == condition.param;
    }

    public override int GetHashCode()
    {
        int hashCode = -598103872;
        hashCode = hashCode * -1521134295 + conditionsEnum.GetHashCode();
        hashCode = hashCode * -1521134295 + param.GetHashCode();
        return hashCode;
    }

    public override string ToString()
    {
        return $"ConditionEnum:{conditionsEnum}, param:{param}";
    }
}
