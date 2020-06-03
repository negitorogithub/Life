using UnityEngine;
using UniRx;
using System;

public class Reproducible : MonoBehaviour, IReproducible
{
    public Subject<Unit> reproducedSubject { get; set; }

    private GameObject Object2Reproduce;
    [SerializeField]
    private string path;

    public void Reproduce()
    {
        var instantiatePosition = gameObject.transform.position + new Vector3(gameObject.transform.lossyScale.x,0,0);
        Instantiate(Object2Reproduce,instantiatePosition,Quaternion.identity);
        reproducedSubject.OnNext(Unit.Default);
    }

    void Awake()
    {
        reproducedSubject = new Subject<Unit>();
        Object2Reproduce = (GameObject)Resources.Load(path);
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
