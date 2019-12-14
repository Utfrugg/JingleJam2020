using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChonkMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower = 10f;
    public Animator animator;

    private Rigidbody2D rigidbody;
    private float animSpeed;
    private bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        float hor = Input.GetAxis("Horizontal");
        animator.SetFloat("animSpeed", Mathf.Abs(hor));

        Jump();
        if (grounded)
        {
            if (Input.GetAxis("Jump") > 0.1f)
            {
                rigidbody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
                grounded = false;
            }
        }
    }
    void Jump() 
    {
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 0f), ForceMode2D.Impulse);
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
