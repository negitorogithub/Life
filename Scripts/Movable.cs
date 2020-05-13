using UnityEngine;
using System;
using UniRx;

public class Movable : MonoBehaviour, IMovable
{
    Rigidbody rigidBody;
    public GameObject masterDataObject;
    IMasterData masterData;
    public ReactiveProperty<MovingState> StateReactive { get; set; }
    IObservable<long> intervalObservable;
    public GameObject target;
    Vector3 randomYVector;
    void Awake()
    {
        StateReactive = new ReactiveProperty<MovingState>(MovingState.STOPPING);
    }

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        masterData = masterDataObject.GetComponent<IMasterData>() ?? throw new Exception();
        intervalObservable = Observable.Interval(TimeSpan.FromSeconds(masterData.RandomMoveIntervalSecond));
        intervalObservable.Subscribe(_ =>
        {
            randomYVector = new Vector3(0, new System.Random().Next(0, 360), 0);
        });
    }

    void FixedUpdate()
    {
        //TODO:Stateパターンでもっときれいに書けるかも
        switch (StateReactive.Value)
        {
            case MovingState.MOVING_2_TARGET:
                if (target == null)
                {
                    StateReactive.Value = MovingState.STOPPING;
                    break;
                }
                gameObject.transform.forward = target.transform.position - gameObject.transform.position;
                rigidBody.velocity = gameObject.transform.forward * masterData.Speed;
                break;
            case MovingState.MOVING_AWAY_FROM_TARGET:
                if (target == null)
                {
                    StateReactive.Value = MovingState.STOPPING;
                    break;
                }
                gameObject.transform.forward = -(target.transform.position - gameObject.transform.position);
                rigidBody.velocity = gameObject.transform.forward * masterData.Speed;
                break;
            case MovingState.MOVING_RANDOMLY:
                gameObject.transform.rotation = Quaternion.Euler(randomYVector);
                rigidBody.velocity = gameObject.transform.forward * masterData.Speed;
                break;
            case MovingState.STOPPING:
                rigidBody.velocity = Vector3.zero;
                break;
        }
        //transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    }
    public void Move2(GameObject target)
    {
        StateReactive.Value = MovingState.MOVING_2_TARGET;
        this.target = target;
    }

    public void MoveAwayFrom(GameObject target)
    {
        StateReactive.Value = MovingState.MOVING_AWAY_FROM_TARGET;
        this.target = target;
    }

    public void MoveRandomly()
    {
        StateReactive.Value = MovingState.MOVING_RANDOMLY;
    }

    public void Stop()
    {
        StateReactive.Value = MovingState.STOPPING;
    }

    
}
