using UnityEngine;
using System.Collections;

public class Movable : MonoBehaviour, IMovable
{
    Rigidbody rigidBody;

    public MovingState MovingState { get; set; }

    public void Move2(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public void MoveAwayFrom(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public void MoveRandomly()
    {
        throw new System.NotImplementedException();
    }

    public void Stop()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
