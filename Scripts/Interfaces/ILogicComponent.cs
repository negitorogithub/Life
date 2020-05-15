public interface ILogicComponent
{
    IActionComponent actionComponent { get; set; }
    IConditionComponent conditionComponent { get; set; }
}