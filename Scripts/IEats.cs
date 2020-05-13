using UniRx;
using UnityEngine;

public interface IEats
{
    Subject<GameObject> EatedSubject { get; set; }
}
