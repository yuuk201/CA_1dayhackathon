using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoHide : MonoBehaviour
{
    [SerializeField]
    private float displayTime = 5.0f;

    [SerializeField]
    private float fadeTime = 1.0f;

    private float timer = 0.0f;
    private Text text;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > displayTime)
        {
            var t = timer - displayTime;
            text.color = new Color(1, 1, 1, (fadeTime - t) / fadeTime);
        }

        if (timer > displayTime + fadeTime)
        {
            this.gameObject.SetActive(false);
        }
    }
}
