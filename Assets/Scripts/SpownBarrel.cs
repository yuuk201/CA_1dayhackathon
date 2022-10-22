using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownBarrel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BarrelPrefab;
    public Transform rangeA;
    public Transform rangeB;
    Quaternion barr_direction=Quaternion.Euler(0.0f,86.03f,-180f);

    // Update is called once per frame
    private float time=0.0f;

    void Update()
    {
        time=time+Time.deltaTime;
        if(time > 1.0f){
            float z = Random.Range(rangeA.position.z, rangeB.position.z);//rangeAからrangeBのy軸座標の間にハンマーをスポーン
            
            Instantiate(BarrelPrefab,new Vector3(3.034f,9.31f,z),barr_direction);
            time=0.0f;
        }
        
    }
}
