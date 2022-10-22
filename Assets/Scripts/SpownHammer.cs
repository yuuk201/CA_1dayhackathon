using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownHammer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HammerPrefab;
    public Transform rangeA;
    public Transform rangeB;

    // Update is called once per frame
    private float time=0.0f;

    void Update()
    {
        time=time+Time.deltaTime;
        if(time > 1.0f){
            float y = Random.Range(rangeA.position.y, rangeB.position.y);//rangeAからrangeBのy軸座標の間にハンマーをスポーン

            Instantiate(HammerPrefab,new Vector3(-5.0f,y,137.0f),Quaternion.identity);
            time=0.0f;
        }
        
    }
}
