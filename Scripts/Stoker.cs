using UnityEngine;

public class Stoker : MonoBehaviour
{

    public Transform transformToStoke;
    private Vector3 transformDelta;
    private Vector3 rotationDelta;

    // Use this for initialization
    void Start()
    {
        transformDelta = transform.position - transformToStoke.position;
        rotationDelta = transform.rotation.eulerAngles - transformToStoke.rotation.eulerAngles;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = transformToStoke.position + transformDelta;
        //transform.rotation = transformToStoke.rotation;
    }
}