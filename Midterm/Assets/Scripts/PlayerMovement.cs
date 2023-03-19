using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 2;

    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb2D.AddForce(Vector2.up * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb2D.AddForce(Vector2.down * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb2D.AddForce(Vector2.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2D.AddForce(Vector2.right * speed);
        }
    }
}
