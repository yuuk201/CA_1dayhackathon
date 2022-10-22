using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBarrel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform culTransform=this.transform;
        if(culTransform.position.z<170.334f){
            Destroy (this.gameObject);
        }
    }
}
