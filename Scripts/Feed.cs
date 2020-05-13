using UnityEngine;

public class Feed : MonoBehaviour, IFeed
{
    public void OnEated()
    {
        Destroy(gameObject);
    }
}
