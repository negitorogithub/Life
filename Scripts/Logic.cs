namespace Assets.Scripts
{
    class Logic : ILogic
    {
        public ICondition condition { get; set; }
        public IAction action { get; set; }
    }
}
