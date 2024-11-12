using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    public float upForce;
    bool started;
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                started = true;
                rb.isKinematic = false;
                GameManager.Instance.GameStart();
            }
        }
        else if (started && !gameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        gameOver = true;
        GameManager.Instance.GameOver();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pipe" && !gameOver)
        {
            gameOver = true;
            GameManager.Instance.GameOver();
        }

        if (other.gameObject.tag == "ScoreChecker" && !gameOver)
        {
            ScoreManager.Instance.IncrementScore();
        }
    }
}
