using UnityEngine;
public interface IMovable
{
    void Move2(GameObject target);
    void MoveAwayFrom(GameObject target);
    void MoveRandomly();
    void Stop();
    MovingState MovingState { get; set; }
}
