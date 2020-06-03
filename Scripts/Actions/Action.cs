public class Action:IAction
{
    public Action(ActionsEnum? actionsEnum = null)
    {
        if (actionsEnum != null)
        {
            this.actionsEnum = (ActionsEnum)actionsEnum;
        }
    }

    public ActionsEnum actionsEnum { get; set; }

    public override bool Equals(object obj)
    {
        if (( obj == null ) || !GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            var p = (Action)obj;
            return p.actionsEnum == actionsEnum;
        }
    }

    public override int GetHashCode()
    {
        return 1488738505 + actionsEnum.GetHashCode();
    }

    public override string ToString()
    {
        return $"ActionsEnum:{actionsEnum}";
    }
}
