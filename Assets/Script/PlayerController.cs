using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public float doubleJumpSpeed;
    public float flashDistance;
    public Joystick joystick;

    private Rigidbody2D myRigidbody;
    private Transform myTransform;
    private Animator myAnim;
    private BoxCollider2D myFeet;
    public bool isGround;
    private bool canDoubleJump;
    private PlayerHealth playerHealth;
    private TouchJumpKey touchJump;
    private TouchLeftSkillKey touchLeftSkillKey;
    private TouchRightSkillKey touchRightSkillKey;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
        myAnim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        touchJump = GameObject.FindGameObjectWithTag("JumpKey").GetComponent<TouchJumpKey>();
        touchLeftSkillKey = GameObject.FindGameObjectWithTag("LeftSkillKey").GetComponent<TouchLeftSkillKey>();
        touchRightSkillKey = GameObject.FindGameObjectWithTag("RightSkillKey").GetComponent<TouchRightSkillKey>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        Flip();
        if(playerHealth.health > 0)
        {
            Run();
            Jump();
            //if (timer > 2)
            //{
            //    Flash();
            //}
        }

        CheckGround();
        SwitchAnimation();
        Debug.Log(isGround);
    }

    void CheckGround()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) ||
                   myFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform")) ||
                   myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
;    }

    void Flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            if(myRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (myRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    void Run()
    {
        //float moveDir = Input.GetAxis("Horizontal");
        float moveDir = joystick.Horizontal;
        Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVel;
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("Run", playerHasXAxisSpeed);
    }

    public void Jump()
    {
        //if (Input.GetButtonDown("Jump"))
        //if(joystick.Vertical >= 0.9)
        if(touchJump.isJump == true && touchJump.ableJump == true)
        {
            if (isGround)
            {
                myAnim.SetBool("Jump", true);
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRigidbody.velocity = Vector2.up * jumpVel;
                canDoubleJump = false; //Ä¬ÈÏ½ûÓÃ¶þ¶ÎÌø
                touchJump.ableJump = false;
            }
            else
            {
                if (canDoubleJump)
                {
                    myAnim.SetBool("DoubleJump", true);
                    Vector2 doubleJumoVel = new Vector2(0.0f, doubleJumpSpeed);
                    myRigidbody.velocity = Vector2.up * doubleJumoVel;
                    canDoubleJump = false;
                }
            }
            
        }
    }

    public void Flash()
    {
        float moveDir = joystick.Horizontal;
        if (touchLeftSkillKey.isLeftSkill == true)
        {
            myTransform.position = new Vector2(transform.position.x + moveDir * flashDistance, transform.position.y);
            touchLeftSkillKey.isLeftSkill = false;
            timer = 0;
        }
        //if (touchRightSkillKey.isRightSkill == true)
        //{
        //    myTransform.position = new Vector2(transform.position.x + flashDistance, transform.position.y);
        //    timer = 0;
        //}
    }

    void SwitchAnimation()
    {
        myAnim.SetBool("Idle", false);
        if (myAnim.GetBool("Jump"))
        {
            if(myRigidbody.velocity.y < 0.1f)
            {
                myAnim.SetBool("Jump", false);
                myAnim.SetBool("Fall", true);
            }
        }
        else if (isGround)
        {
            myAnim.SetBool("Fall", false);
            myAnim.SetBool("Idle", true);
        }

        if (myAnim.GetBool("DoubleJump"))
        {
            if (myRigidbody.velocity.y < 0.1f)
            {
                myAnim.SetBool("DoubleJump", false);
                myAnim.SetBool("DoubleFall", true);
            }
        }
        else if (isGround)
        {
            myAnim.SetBool("DoubleFall", false);
            myAnim.SetBool("Idle", true);
        }
    }
}
