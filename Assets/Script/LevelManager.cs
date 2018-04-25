using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Text levelText;

    public static int level = 1;

    PinGameManager PGM;

    // Use this for initialization
    void Start () {

        PGM = GameObject.FindGameObjectWithTag("PinGameManager").GetComponent<PinGameManager>();

    }
	
	// Update is called once per frame
	void Update () {

        levelText.text = level + "";

        if (PinGameManager.score == 0)
        {
            StartCoroutine(RestartLv());
        }

    }

    IEnumerator RestartLv()
    {
        yield return new WaitForSeconds(1f);
        level += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
