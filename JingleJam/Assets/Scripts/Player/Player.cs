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
    public Sprite[] ChonkTextures = new Sprite[6];
    public float Chonk;
    private Controller2D controller;

    public bool facingRight = true;

    public Animator animator;

    private float jumpVelocity;
    private float verticalMomentum = 0.0f;
    private float gravity;
    private Vector3 velocity;

    private bool jump = false;
    private bool isJumping = false;

    private bool maxChonk = false;
    private float bounce = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Controller2D>();
        GetChonk(0);
    }

    public void GetChonk(float ChonkIncrease)
    {
        int ChonkLevel = Mathf.FloorToInt(Chonk);
        ChonkLevel = Mathf.Min(ChonkLevel, 4);

        Debug.Log(ChonkLevel);
        gameObject.transform.Find("cat_body").GetComponent<SpriteRenderer>().sprite = ChonkTextures[ChonkLevel];
        // GetComponentInParent<SpriteRenderer>().sprite = ChonkTextures[ChonkLevel];
        gameObject.transform.Find("cat_body").GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", ChonkTextures[ChonkLevel].texture);

        jumpHeight = jumpHeights[ChonkLevel];
        timeToHighestPoint = timeToHighestPoints[ChonkLevel];
        moveSpeed = moveSpeeds[ChonkLevel];

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToHighestPoint, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToHighestPoint;

        Chonk += ChonkIncrease;
        if (Chonk >= 5.0f)
        {
            maxChonk = true;
            gameObject.transform.Find("cat_body").GetComponent<SpriteRenderer>().sprite = ChonkTextures[5];
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            controller.animator.SetBool("Jump", true);
            controller.animator.SetBool("OnGround", false);
        }

        if (isJumping)
        {
            if (controller.collisions.below)
            {
                isJumping = false;
                controller.animator.SetBool("OnGround", true);
            }
        }

        if (controller.collisions.below)
        {
            verticalMomentum = 0.0f;
        }
        else
        {
            verticalMomentum += Time.deltaTime;
        }

        if (!maxChonk)
        {
            if (verticalMomentum > timeToHighestPoint * 2 && Mathf.FloorToInt(Chonk) > 0)
            {
                if (bounce < 0.2f)
                {
                    bounce = 1.0f;
                }
            }
        }
        else
        {
            bounce = 2f;
            if (transform.position.y > 30)
                gravity = 0.0f;
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

        if (input.x < 0 && facingRight) Flip();
        if (input.x > 0 && !facingRight) Flip();


        if (jump && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
            
            
            isJumping = true;
        }

        if (controller.collisions.below)
        {
            if (bounce > 0.1f)
            {
                float bounceLevel = 0.0f;
                switch (Mathf.Min(Mathf.FloorToInt(Chonk), 4))
                {
                    case 2:
                    {
                        bounceLevel = 0.8f;
                        break;
                    }
                    case 3:
                    {
                        bounceLevel = 1.5f;
                        break;
                    }
                    case 4:
                    {
                        bounceLevel = 2.0f;
                        break;
                    }
                    default:
                    {
                        bounceLevel = 0.0f;
                        break;
                    }
                }


                velocity.y = jumpVelocity * bounce * bounceLevel;
                bounce *= 0.5f;
            }
            else
            {
                bounce = 0.0f;
            }
        }


        jump = false;
        controller.animator.SetBool("Jump", false);

        velocity.x = input.x * moveSpeed;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime, Mathf.FloorToInt(Chonk), jumpVelocity * Time.deltaTime);
    }

    void Flip ()
    {
        facingRight = !facingRight;
        var scale = this.gameObject.transform.localScale;
        scale.Set(facingRight ? 1 : -1, 1, 1);
        this.gameObject.transform.localScale = scale;
    }
}
