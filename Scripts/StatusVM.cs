using UnityEngine;

public class StatusVM : MonoBehaviour
{
    public HpHolder hpHolder;
    public float hp { get; private set; }
    private void Update()
    {
        hp = hpHolder.hp;
    }

}
