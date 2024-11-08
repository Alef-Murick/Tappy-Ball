using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float ySpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MovePipe();
        InvokeRepeating("SwitchY", 0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SwitchY()
    {
        ySpeed = -ySpeed;
        rb.velocity = new Vector2(-speed, ySpeed);
    }
    private void MovePipe()
    {
        rb.velocity = new Vector2(-speed, ySpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PipeRemover")
        {
            Destroy(gameObject);
        }
    }
}
