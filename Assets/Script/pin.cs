using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pin : MonoBehaviour {

    Rigidbody2D rg;
    public float speed = 20f;
    bool isPined = false;
    bool isGameOver = false;

    spin sp;

	// Use this for initialization
	void Start () {
        rg = GetComponent<Rigidbody2D>();
        sp = GameObject.FindGameObjectWithTag("spin").GetComponent<spin>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!isPined)
        {
            rg.MovePosition(rg.position + Vector2.up * speed * Time.deltaTime);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "spin")
        {
            isPined = true;
            this.transform.SetParent(collision.gameObject.transform);
            if (!isGameOver)
            {
                PinGameManager.score -= 1;
            }
        }

        if(collision.gameObject.tag == "pin")
        {
            Camera.main.backgroundColor = Color.red;
            StartCoroutine(RestartLv());
            sp.speed = 50f;
            isGameOver = true;
        }
    }

    IEnumerator RestartLv()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
