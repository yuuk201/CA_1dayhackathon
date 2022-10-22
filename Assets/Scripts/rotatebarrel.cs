using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatebarrel : MonoBehaviour
{
    // Start is called before the first frame update
    private float rotateX=0;//X軸方向の回転角度
    private float rotateY=0;//Y軸方向の回転角度
    private float rotateZ=-720;//Z軸方向の回転角度


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(rotateX,rotateY,rotateZ)*Time.deltaTime);
    }
}
