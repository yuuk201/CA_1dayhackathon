using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveboat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform culTransform=this.transform;
        Vector3 pos =culTransform.position;
        pos.z+=0.01f;
        culTransform.position=pos;
    }
}
