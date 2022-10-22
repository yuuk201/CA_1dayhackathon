using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private Vector2 windStart, windEnd;
    private bool isWindMoving = false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //var objectPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        //var pointScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectPoint.z);
        //var pointWorld = Camera.main.ScreenToWorldPoint(pointScreen);
        //pointWorld.z = this.transform.position.z;
        //transform.position = pointWorld;
        if (Input.GetMouseButtonDown(0))
        {
            windStart = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            isWindMoving = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isWindMoving = false;
        }
        if (isWindMoving)
        {
            var windPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            var windVec = windPoint - windStart;
            var windVecNor = windVec.normalized;

            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1.0f, 1.0f, 0.0f)).normalized;
            Vector3 moveForward = Camera.main.transform.up * windVecNor.y + Camera.main.transform.right * windVecNor.x;
            rb.velocity = moveForward * 2.0f;


            //this.rb.AddForce(windVecNor * 2.0f);
        }
    }

}
