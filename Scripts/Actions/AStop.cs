using UnityEngine;

public class AStop : MonoBehaviour, IActionComponent
{
    internal IMovable movable;

    public void do_()
    {
        movable.Stop();
    }
}