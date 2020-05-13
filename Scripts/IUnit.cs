public interface IUnit 
{
    HpHolder HpHolder { get; set; }
    IMovable Movable { get; set; }
    IEats Eats { get; set; }
    IReproducive Reproductive { get; set; }
}
