using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PinGameManager : MonoBehaviour {

    public static int score = 0;
    public Text scoreText;

    public static int goal = 6;

	// Use this for initialization
	void Start () {
        score = goal;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score + "";

        if(score == 0)
        {
            if (goal < 14)
            {
                StartCoroutine(RestartLv());
            }
            else
            {
                print("You Win.");
            }
        }
	}

    IEnumerator RestartLv()
    {
        yield return new WaitForSeconds(1f);
        goal += 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
