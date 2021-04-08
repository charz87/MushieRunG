using UnityEngine;
using System.Collections;

public class MushieMove : MonoBehaviour {

    public float forwardSpeed = 5;
    public float jumpSpeed = 5;
    private Vector3 movement;
    private float distanceToGround = 0.1f;
    private Rigidbody rb;
    public LayerMask ground;
    private bool jumpInput;
    public float downAccel = 0.75f;
    private Animator anim;
    private float timer = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
	// Update is called once per frame

    void Update()
    {
        GetJumpInput();
        

    }

	void FixedUpdate ()
    {
        print(timer);
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, 5);

        if(timer <= 0)
        {
            anim.SetFloat("Speed", forwardSpeed);
            movement = new Vector3(0, 0, forwardSpeed);
            Jump();



            rb.velocity = transform.TransformDirection(movement);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
        

       
	}

    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround, ground);
    }

    void GetJumpInput()
    {
        jumpInput = Input.GetButtonDown("Fire1");
    }

    void Jump()
    {
        float timeBeforeJump = 1;
        if(jumpInput && Grounded())
        {

            anim.SetTrigger("Jump");
            anim.SetBool("Grounded", false);
            movement.y = jumpSpeed;
           
           

        }else if(!jumpInput && Grounded())
        {
            movement.y = 0;
            anim.SetBool("Grounded", true);
        }
        else
        {
            movement.y -= downAccel;
        }
    }
}
