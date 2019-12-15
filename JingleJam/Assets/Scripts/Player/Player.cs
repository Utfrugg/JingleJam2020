using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public float jumpHeight = 4;
    public float timeToHighestPoint = .4f;
    public float moveSpeed = 6;

    private Controller2D controller;

    private float jumpVelocity;
    
    private float gravity;
    private Vector3 velocity;

    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Controller2D>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToHighestPoint, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToHighestPoint;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            jump = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (jump && controller.collisions.below)
        {

            Debug.Log("Joink");
            velocity.y = jumpVelocity;
        }
        jump = false;
        velocity.x = input.x * moveSpeed;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
