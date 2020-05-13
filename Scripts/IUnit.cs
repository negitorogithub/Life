public interface IUnit 
{
    HpHolder HpHolder { get; set; }
    IMovable Movable { get; set; }
    IEats Eats { get; set; }
    IReproductive Reproductive { get; set; }
}
