using UnityEngine;
using System.Collections;
using UniRx;

public class Eats : MonoBehaviour, IEats
{
    public Subject<GameObject> EatedSubject { get; set; }

    void Awake()
    {
        EatedSubject = new Subject<GameObject>();
    }

    void OnCollisionStay(Collision collision)
    {
        IFeed feed = collision.gameObject.GetComponent<IFeed>();
        if (feed == null)
        {
            return;
        }
        EatedSubject.OnNext(collision.gameObject);
        feed.OnEated();
    }
}
