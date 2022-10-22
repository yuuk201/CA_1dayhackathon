using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Bubble player;

    [SerializeField]
    private ScoreManager scoreManager;

    [SerializeField]
    private GameObject gameoverUI;

    private bool isGameOver = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        } else if (player.IsGoal()) {
            SceneManager.LoadScene("ending");
        } else {
            if (!player.gameObject.activeSelf)
            {
                isGameOver = true;
                gameoverUI.SetActive(true);
                scoreManager.StopUpdate();
            }


        }
    }
}
