using System;

public class RandomAction
{
    private static readonly Random random = RandomGlobal.random;

    public static IAction Next()
    {
        var result = new Action
        {
            actionsEnum = RandomEnumValue<ActionsEnum>()
        };
        return result;
    }
    static T RandomEnumValue<T>()
    {
        var v = Enum.GetValues(typeof(T));
        return (T)v.GetValue(random.Next(v.Length));
    }
}