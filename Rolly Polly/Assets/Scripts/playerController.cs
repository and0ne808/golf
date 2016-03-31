using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

    public float speed;
    private float normalSpeed;
    private float superSpeed;

    public float jumpPower;
    private float superJumpPower;
    private float normalJumpPower;

    public float maxJumpAngle; //The maximum acceptable angle to jump off of: 1.0 = zero degrees (flat), 0.3 is about 60 degrees (steep).
    public float DIFactor; // Mid-Air Directional Influence Denominator. Recommended: 2 or 3.
    public float frictionThreshold;
    public bool canJump;
    public float fallThreshold;
    public float groundDrag;
    public float movementDrag;

    private Rigidbody rb;
    private Vector3 jumpForce;
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

    public static bool megaJump;
    public static bool megaStrength;
    public static bool megaSpeed;
    public static bool wallJump;

    public static float megaSpeedTimer;
    public static float megaJumpTimer;
    public static float megaStrengthTimer;

    private float redValue;
    private float greenValue;
    private float blueValue;

    private MeshRenderer meshRend;

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
        megaJump = false;
        megaStrength = false;
        megaSpeed = false;
        wallJump = false;
        normalSpeed = speed;
        superSpeed = speed + speed;

        normalJumpPower = jumpPower;
        superJumpPower = jumpPower + jumpPower;

        meshRend = GetComponent<MeshRenderer>();
        redValue = 1f;
        greenValue = 1f;
        blueValue = 1f;

        megaStrengthTimer = 0;
        megaJumpTimer = 0;
        megaSpeedTimer = 0;
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
        //Debug.Log(movement.magnitude);
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
            megaSpeedTimer = 0;
            megaJumpTimer = 0;
            megaStrengthTimer = 0;
            redValue = 1f;
            greenValue = 1f;
            blueValue = 1f;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        // MEGA SPEED Timer Logic----------------------------------------
        if (megaSpeedTimer > 0)
        {
            redValue = 1f;
            greenValue = 1f;
            blueValue = (10 - megaSpeedTimer) / 10;
            megaSpeed = true;
            speed = superSpeed;
            megaSpeedTimer -= Time.deltaTime;
        }
        else
        {
            megaSpeedTimer = 0;
            speed = normalSpeed;
            megaSpeed = false;

        }

        // MEGA JUMP Timer Logic-------------------------------------------
        if (megaJumpTimer > 0)
        {
            redValue = (10 - megaJumpTimer) / 10;
            greenValue = (10 - megaJumpTimer) / 10;
            blueValue = 1f;
            megaJump = true;
            jumpForce = new Vector3(0.0f, superJumpPower, 0.0f);
            megaJumpTimer -= Time.deltaTime;
        }
        else
        {
            megaJumpTimer = 0;
            jumpForce = new Vector3(0.0f, normalJumpPower, 0.0f);
            megaJump = false;
        }

        // MEGA STRENGTH Timer Logic-------------------------------------------
        if (megaStrengthTimer > 0)
        {
            redValue = (10 - megaStrengthTimer) / 10;
            blueValue = (10 - megaStrengthTimer) / 10;
            greenValue = 1f;
            megaStrength = true;
            megaStrengthTimer -= Time.deltaTime;
        }
        else
        {
            megaStrengthTimer = 0;
            megaStrength = false;
        }

        // WALL JUMP LOGIC
        if(wallJump)
        {
            maxJumpAngle = -0.2f;
        }

        meshRend.material.color = new Color(redValue, greenValue, blueValue);
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        //Debug.Log("OnCollisionEnter activated");
        contactNormal = collisionInfo.contacts[0].normal;
        //Debug.Log(contactNormal);

        if (contactNormal.y > maxJumpAngle)
        {
            canJump = true;
            if (megaJump)
            {
                jumpForce = contactNormal * superJumpPower;
            }
            else
            {
                jumpForce = contactNormal * normalJumpPower;
            }
        }


    }



    void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }



}
