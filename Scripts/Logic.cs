using System.Collections.Generic;

public class Logic : ILogic
{
    public Logic(ICondition condition = null, IAction action = null)
    {
        this.condition = condition;
        this.action = action;
    }

    public ICondition condition { get; set; }
    public IAction action { get; set; }

    public override bool Equals(object obj)
    {
        return obj is Logic logic &&
                EqualityComparer<ICondition>.Default.Equals(condition, logic.condition) &&
                EqualityComparer<IAction>.Default.Equals(action, logic.action);
    }

    public override int GetHashCode()
    {
        int hashCode = 1841655149;
        hashCode = hashCode * -1521134295 + EqualityComparer<ICondition>.Default.GetHashCode(condition);
        hashCode = hashCode * -1521134295 + EqualityComparer<IAction>.Default.GetHashCode(action);
        return hashCode;
    }

    public override string ToString()
    {
        return $"If {condition} then {action}";
    }
}
