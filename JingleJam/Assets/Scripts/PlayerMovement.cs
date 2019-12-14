using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpPower = 10;
    public Animator animator;

    private bool grounded = true;
    private Rigidbody2D rigidbody;

    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(hor));

        Vector2 movement = new Vector2(hor, ver);

        rigidbody.AddForce(new Vector2(movement.x * speed, 0), ForceMode2D.Impulse);

        if (grounded)
        {
            if (Input.GetAxis("Jump") > 0.1f)
            {
                rigidbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
                grounded = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (collision.GetContact(0).normal.y > 0.9f)
            {
                grounded = true;
            }
        }
    }
}
