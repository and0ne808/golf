using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public float speed;
    public float jumpPower;
    public float maxJumpAngle; //The maximum acceptable angle to jump off of: 1.0 = zero degrees (flat), 0.3 is about 60 degrees (steep).
    public float DIFactor; // Mid-Air Directional Influence Denominator. Recommended: 2 or 3.
    public float friction;
    public bool canJump;

    private Rigidbody rb;
    private Vector3 jumpForce;
    //private bool canJump;
    private Vector3 contactNormal;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpForce = new Vector3(0.0f, jumpPower, 0.0f);
    }

	void FixedUpdate () 
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        /*
        if (Input.GetButtonDown("Jump") && canJump)
        {

            canJump = false;
            rb.AddForce(jumpForce);
            
        }
          */
        
        if(canJump)
        {
        rb.AddForce(movement * speed);
        }
        else
        {
            rb.AddForce(movement * speed / DIFactor); //Mid-Air Directional Infulenece 
        }

        //calculate friction
        Debug.Log(rb.velocity);
        if (canJump)
        {
            //calculate x friction
            if (rb.velocity.x > friction)
            {  
                rb.velocity = new Vector3((rb.velocity.x - friction), rb.velocity.y, rb.velocity.z);
            }
            else if (rb.velocity.x < -friction)
            {
                rb.velocity = new Vector3((rb.velocity.x + friction), rb.velocity.y, rb.velocity.z);
            }
            else
            {
                rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            }

            //calculate z friction
            if (rb.velocity.z > friction)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, (rb.velocity.z - friction));
            }
            else if (rb.velocity.z < -friction)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, (rb.velocity.z + friction));
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            }
        }

	}

    void Update()
    {
        if (Input.GetButtonDown("Jump") && canJump)
        {

            canJump = false;
            rb.AddForce(jumpForce);

        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        //Debug.Log("OnCollisionEnter activated");
        contactNormal = collisionInfo.contacts[0].normal;
        //Debug.Log(contactNormal);

        if (contactNormal.y > maxJumpAngle)
        {
            canJump = true;
            jumpForce = contactNormal * jumpPower;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

}
