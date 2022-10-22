using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoScroll : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vcamera;
    [SerializeField]
    private float scrollSpeed = 0.02f;

    private CinemachineTrackedDolly dolly;

    // Start is called before the first frame update
    void Start()
    {
        dolly = vcamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    // Update is called once per frame
    void Update()
    {
        dolly.m_PathPosition += Time.deltaTime * scrollSpeed;
    }
}
