using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

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
    public AudioClip bubbledestroy;//シャボン玉破裂音
    AudioSource audioSource;//シャボン玉破裂音
    private float time;//色変わる時間


    [SerializeField]
    private float keepDistance = 13.0f;

    [SerializeField]
    private bool isFollowCamera = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();//破裂音

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
        ColorDest();
    }

    void Burst()
    {
        Instantiate(particle_bubble, this.transform.position, Quaternion.identity);
        audioSource.PlayOneShot(bubbledestroy);
        Destroy(this.gameObject);
        
    }

    void OnWillRenderObject()
    {
        if (Camera.current.Equals(Camera.main))
        {
            cameraCount++;
        }
    }


    void OnTriggerEnter(Collider collider){
        if(collider.tag=="goal"){
            SceneManager.LoadScene("ending");
        }else{
            isBurst = true;
        }
    }
    void ColorDest(){
        time+=Time.deltaTime;
        if(time>5.0f){
            float z = Random.Range(0,9);
            if(z%2==0){
                GetComponent<Renderer>().material.SetFloat("_ThinfilmMax", 0.0f);
            }else{
                GetComponent<Renderer>().material.SetFloat("_ThinfilmMax", 6.8f);
            }
            time=0.0f;
        }
    }
}
