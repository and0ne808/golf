using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public float speed;
    public float jumpPower;
    public float maxJumpAngle; //The maximum acceptable angle to jump off of: 1.0 = zero degrees (flat), 0.3 is about 60 degrees (steep).
    public float DIFactor; // Mid-Air Directional Influence Denominator. Recommended: 2 or 3.
    public float frictionThreshold;
    public bool canJump;
    public float fallThreshold;
    public float groundDrag;
    public float movementDrag;

    private Rigidbody rb;
    private Vector3 jumpForce;
    //private bool canJump;
    private Vector3 contactNormal;
    private Vector3 movement;
    private float initial_x;
    private float initial_y;
    private float initial_z;

    private Vector3 frictionForce;

    public AudioSource jumpSound;
    public AudioSource dieSound;
    public AudioSource pickUp;
    public static AudioSource pickupBlueberry;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpForce = new Vector3(0.0f, jumpPower, 0.0f);
        //get initial transform
        initial_x = this.transform.position.x;
        initial_y = this.transform.position.y;
        initial_z = this.transform.position.z;
        //audio = GetComponent<AudioSource>();
        pickupBlueberry = pickUp;
    }

	void FixedUpdate () 
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        while(Mathf.Abs(moveHorizontal) + Mathf.Abs(moveVertical) > 1.1) //normalize at or below 1
        {
            moveHorizontal = moveHorizontal * 0.95f;
            moveVertical = moveVertical * 0.95f;
        }

        //Debug.Log(moveHorizontal + " " + moveVertical + "TOTAL " + (Mathf.Abs(moveHorizontal) + Mathf.Abs(moveVertical)));
        movement = new Vector3(Mathf.Sin(moveHorizontal*Mathf.PI/2), 0.0f, Mathf.Sin(moveVertical*Mathf.PI/2));

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
        Debug.Log(movement.magnitude);
        if (canJump && movement.magnitude < frictionThreshold)
        {
            rb.drag = groundDrag; // let go of controller
        }
        else if (canJump && movement.magnitude > frictionThreshold && movement.magnitude < 1 - frictionThreshold)
        {
            rb.drag = groundDrag - groundDrag * movement.magnitude; // move with controller
        }
        else if (canJump && movement.magnitude > 1 - frictionThreshold)
        {
            rb.drag = movementDrag;
        }


        else
        {
            rb.drag = 0; // no drag in air
        }

        if(rb.velocity.magnitude < frictionThreshold)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
            /*
            frictionForce = movement;
            frictionForce.Normalize();
            frictionForce = frictionForce * friction;
            Debug.Log(frictionForce.magnitude + " " + rb.velocity.magnitude);
            if(rb.velocity.magnitude > friction)
            {
                

                rb.velocity = new Vector3(rb.velocity.x - frictionForce.x, rb.velocity.y - frictionForce.y, rb.velocity.z - frictionForce.z);
            }
            else
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }
             * */
            /*
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
             */
        //}

        //RESET IF YOU FALL OFF MAP
        if (this.transform.position.y < fallThreshold)
        {
            dieSound.Play();
            rb.velocity = Vector3.zero;
            this.transform.position = new Vector3(initial_x, initial_y, initial_z);
            rb.Sleep();
            
        }

	}

    void Update()
    {
        if (Input.GetButtonDown("Jump") && canJump)
        {

            canJump = false;
            rb.AddForce(jumpForce);
            jumpSound.Play();

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
