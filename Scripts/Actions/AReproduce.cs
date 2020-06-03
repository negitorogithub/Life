using UnityEngine;

public class AReproduce : MonoBehaviour, IActionComponent
{
    public IReproducible reproducible;

    public void do_()
    {
        reproducible.Reproduce();
    }
}