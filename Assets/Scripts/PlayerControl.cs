using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    public float forwardSpeed;
    private Vector3 velocityVector;
    private Animator anim;
    private float timer = 1;

    bool isOnGround;
    public Transform groundCheck;
    public LayerMask whatIsTheGround;
    float groundSphere = 0.3f;

    public float jumpForce;
    public float jumpForceHold;
    public float maxJumpTime;
    float MaxJumpTimeInternal;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        print(GetComponent<Rigidbody>().velocity);

        //Move Routine
        if (timer <= 0)
        {
            if (isOnGround)
            {
                anim.SetFloat("Speed", forwardSpeed);
                anim.SetBool("Grounded", true);
                GetComponent<Rigidbody>().AddForce(new Vector3(forwardSpeed, 0, 0), ForceMode.VelocityChange);
                if (GetComponent<Rigidbody>().velocity.x > 2f)
                {
                    velocityVector = GetComponent<Rigidbody>().velocity;
                    velocityVector.x = 2f;
                    GetComponent<Rigidbody>().velocity = velocityVector;
                }       
            }
            else
            {
                anim.SetFloat("Speed", 0);
            }
            //Jump Routine
            if (isOnGround && Input.GetButtonDown("Fire1"))
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
                MaxJumpTimeInternal = maxJumpTime;
                anim.SetTrigger("Jump");
                
            }

            if (Input.GetButton("Fire1") && GetComponent<Rigidbody>().velocity.y > 1 && MaxJumpTimeInternal > 0)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForceHold, 0));
                MaxJumpTimeInternal = MaxJumpTimeInternal - 1;
                anim.SetBool("Grounded", false);
            }



        }


    }

    void FixedUpdate()
    {
        isOnGround = Physics.OverlapSphere(groundCheck.position, groundSphere, whatIsTheGround).Length > 0;

        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, 5);


    }

}
