using UniRx;

public interface IReproducible
{
    void Reproduce();
    Subject<Unit> reproducedSubject { get; set; }
}
