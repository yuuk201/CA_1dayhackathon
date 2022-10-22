using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatebarrel : MonoBehaviour
{
    // Start is called before the first frame update
    private float rotateX=0;//X軸方向の回転角度
    private float rotateY=0;//Y軸方向の回転角度
    private float rotateZ=720;//Z軸方向の回転角度


    // Update is called once per frame
    void Update()
    {
        Transform culTransform=this.transform;
        Vector3 pos =culTransform.position;
        gameObject.transform.Rotate(new Vector3(rotateX,rotateY,rotateZ)*Time.deltaTime);
        pos.z-=0.02f;
        //culTransform.position=pos;
        if(culTransform.position.z<170.334f || culTransform.position.z>182.02f){
            Destroy (this.gameObject);
        }

    }
}
