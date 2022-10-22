using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private Vector2 windStart, windEnd;
    private bool isWindMoving = false;
    private Rigidbody rb;
    private int cameraCount = 0;

    [SerializeField]
    private float burstTime = 1.0f;
    private float currentBurstTime = 0.0f;
    private bool isBurst = false;

    public GameObject particle_bubble;//シャボン玉が割れたときに出てくるパーティクル

    [SerializeField]
    private float keepDistance = 13.0f;

    [SerializeField]
    private bool isFollowCamera = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            windStart = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            isWindMoving = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isWindMoving = false;
        }

        if (isFollowCamera)
        {
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1.0f, 0.0f, 1.0f)).normalized;
            var distance = (transform.position - Camera.main.transform.position).magnitude;
            rb.velocity += cameraForward * Time.deltaTime * (keepDistance - distance) / keepDistance;
            print((keepDistance - distance) / keepDistance);
        }

        if (isWindMoving)
        {
            var windPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            var windVec = windPoint - windStart;
            var windVecNor = windVec.normalized;

            Vector3 moveForward = Camera.main.transform.up * windVecNor.y + Camera.main.transform.right * windVecNor.x;
            this.rb.AddForce(moveForward * 2.0f);
        }



        if (cameraCount <= 0)
        {
            currentBurstTime += Time.deltaTime;
        }
        else
        {
            currentBurstTime = 0.0f;
        }

        if (currentBurstTime >= burstTime)
        {
            isBurst = true;
        }

        if (isBurst)
        {
            Burst();
        }

        cameraCount = 0;
    }

    void Burst()
    {
        Instantiate(particle_bubble, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    void OnWillRenderObject()
    {
        if (Camera.current.Equals(Camera.main))
        {
            cameraCount++;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        isBurst = true;
    }
}
