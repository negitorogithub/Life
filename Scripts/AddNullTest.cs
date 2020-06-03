using UniRx;
using UnityEngine;

public class AddNullTest : MonoBehaviour
{
    public Object obj2Inst;

    // Start is called before the first frame update
    void Start()
    {
        var nullTest = gameObject.AddComponent<NullTest>();
        nullTest.a = 4;
        Observable.TimerFrame(200).Subscribe(_ =>
        {
            var dupulicated = Instantiate(obj2Inst, transform.position, Quaternion.identity);
        });
    }
}
