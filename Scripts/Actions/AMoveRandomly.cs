using UnityEngine;

public class AMoveRandomly : MonoBehaviour, IActionComponent
{
    internal IMovable movable;

    public void do_()
    {
        movable.MoveRandomly();
    }
}