using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jump;
    public float speed;
    private float move;
    public Rigidbody2D rb;

    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (move *speed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && !isGrounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter()
    {
        isGrounded = false;
    }
    private void OnCollisionExit()
    {
        isGrounded = true;
    }
}
