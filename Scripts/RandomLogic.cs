public class RandomLogic
{
    public static ILogic Next()
    {
        var result = new Logic();
        result.condition = RandomCondition.Next();
        result.action = RandomAction.Next();
        return result;
    }
}
