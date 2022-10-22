using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text text;

    public static int score;

    private float incrimentScoreTimer = 0.0f;
    private float incrimentScoreTime = 0.1f;
    private int incrimentScoreValue = 1;
    private bool isStop = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
     
        if (!isStop)
        {
            incrimentScoreTimer += Time.deltaTime;
            if (incrimentScoreTimer >= incrimentScoreTime)
            {
                incrimentScoreTimer -= incrimentScoreTime;
                score += incrimentScoreValue;
            }
        }
    }

    void UpdateText()
    {
        text.text = score.ToString();
    }

    public void StopUpdate()
    {
        isStop = true;
    }
}
