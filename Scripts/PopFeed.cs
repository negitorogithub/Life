using UnityEngine;
using UniRx;
using System;

public class PopFeed : MonoBehaviour
{
    public GameObject feed;
    public GameObject MasterDataObject;
    public float PopSquareMeter;
    private IMasterData masterData;


    // Start is called before the first frame update
    void Start()
    {
        masterData = MasterDataObject.GetComponent<IMasterData>() ?? throw new Exception();
        var popIntervalSecond = masterData.PopFeedIntervalSecond;
        Observable.Interval(TimeSpan.FromSeconds(popIntervalSecond)).Subscribe(_ => 
        {
            PopRandomly(PopSquareMeter);
        });
    }

    private void PopRandomly(float popSquareMeter)
    {
        var x = UnityEngine.Random.Range(popSquareMeter * -0.5f, popSquareMeter * 0.5f);
        var z = UnityEngine.Random.Range(popSquareMeter * -0.5f, popSquareMeter * 0.5f);
        Instantiate(feed, new Vector3(x, 0.5f, z), Quaternion.identity);
    }
}
