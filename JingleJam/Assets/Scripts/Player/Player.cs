using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public float[] jumpHeights = new float[5];
    float jumpHeight;
    public float[] timeToHighestPoints = new float[5];
    float timeToHighestPoint;
    public float[] moveSpeeds = new float[5];
    float moveSpeed;
    public Sprite[] ChonkTextures = new Sprite[5];
    public float Chonk;
    private Controller2D controller;

    private float jumpVelocity;
    
    private float gravity;
    private Vector3 velocity;

    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Controller2D>();
        GetChonk(0);
    }

    public void GetChonk(float ChonkIncrease)
    {
        Chonk += ChonkIncrease;
        int ChonkLevel = Mathf.FloorToInt(Chonk);
        GetComponentInParent<SpriteRenderer>().sprite = ChonkTextures[ChonkLevel];
        GetComponentInParent<SpriteRenderer>().material.SetTexture("_MainTex", ChonkTextures[ChonkLevel].texture);

        jumpHeight = jumpHeights[ChonkLevel];
        timeToHighestPoint = timeToHighestPoints[ChonkLevel];
        moveSpeed = moveSpeeds[ChonkLevel];

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToHighestPoint, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToHighestPoint;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
