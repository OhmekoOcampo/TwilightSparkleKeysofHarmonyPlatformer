using UnityEngine;
using System.Collections;

public class TwilyControl : MonoBehaviour {

    //Jumping Variables
    public bool touchGround; //variable to check if we are on ground or not
    public float twiJumpStrength;
    public Transform isGroundThere;
    public float isGroundThereRadius;
    public LayerMask isThisGround; //so twi will know if she is touching enemy.

    public bool canTwiMove;

    //Physics Variables
    public float twiSpeed; //Controls Twilight's Speed in either left or right movement
    public Rigidbody2D twiRigidBody; //Variable to hold a RigidBody 2D object.

    //Animator variables
    private Animator twilyAnime;

    //Sound Variables
    public AudioSource JumpSound;
    public AudioSource DamageSound;

    //Respawn Variables
    public Vector3 ponyRespawn;

   //RespawnWaitAMinute reference
    public SceneController instanceSM;

    //HoofStomp Box
    public GameObject HoofStomp;

    //Touching an Enemy Effect
    public float enemyHitback;
    public float enemyHitbackDistance;
    private float enemyHitbackCounter;
    public float invincibilityTime;
    private float invincibilityCounter;

    

	// Use this for initialization
	void Start () { //Will happen during the start, start of any particular scene.
        twiRigidBody = GetComponent<Rigidbody2D>(); //obtain the rigidbody component that this script is attached to.
        twilyAnime = GetComponent<Animator>();

        ponyRespawn = transform.position; //At the start you should respawn to the part where you first came into the world.
        instanceSM = FindObjectOfType<SceneController>();

        canTwiMove = true; //twi can move. 
	}


    // Update is called once per frame
    void Update()
    { //Happens every frame of the game. 

        touchGround = Physics2D.OverlapCircle(isGroundThere.position, isGroundThereRadius, isThisGround); //Walking

        if (enemyHitbackCounter <= 0 && canTwiMove == true)
        {
            if (Input.GetAxisRaw("Horizontal") > 0f) //GetAxisRaw is better for 2D since you can have quicker response.
            {//Twily face to the right when moving to right.
                twiRigidBody.velocity = new Vector3(twiSpeed, twiRigidBody.velocity.y, 0f); //move twily to the right
                transform.localScale = new Vector3(0.61f, 0.64f, 0.64f); //flips the player to the right
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {//Twily face to the left when moving to left.
                twiRigidBody.velocity = new Vector3(-twiSpeed, twiRigidBody.velocity.y, 0f); //move twily to the left
                transform.localScale = new Vector3(-0.61f, 0.64f, 0.64f); //flips the player to the left.
            }
            else
            {
                twiRigidBody.velocity = new Vector3(0f, twiRigidBody.velocity.y, 0f); //twily is standing still
            }

            if (Input.GetButtonDown("Jump") && touchGround == true) //makes sure we just jump once.
            {//GetButtonDown as soon as you press the down button then the player jumps.

                twiRigidBody.velocity = new Vector3(twiRigidBody.velocity.x, twiJumpStrength, 0f);
                JumpSound.Play(); //play sound if you jump.
            }
            
        }

          if(enemyHitbackCounter > 0)
           {
            enemyHitbackCounter = enemyHitbackCounter - Time.deltaTime;
            twiRigidBody.velocity = new Vector3(-enemyHitback, enemyHitback, 0f);
           }

          if(invincibilityCounter <= 0)
        {
            instanceSM.invincible = false;
        }

            twilyAnime.SetFloat("TrotSpeed", Mathf.Abs(twiRigidBody.velocity.x)); //Just checking the magnitude of the speed for Animator Transition purposes.
            twilyAnime.SetBool("IsThereGround", touchGround);

            if (twiRigidBody.velocity.y < 0) //makes sure hoofstomp box that kills enemies isn't always active.
            {
                HoofStomp.SetActive(true);
            }
            else
            {
                HoofStomp.SetActive(false);
            }

        //}
    }

    void OnTriggerEnter2D(Collider2D someObject)
    {
        if (someObject.tag == "RespawnArea")
        {

            instanceSM.Respawn(); //RespawnWaitAMinute must be attached to an object. Got errors if not attached...

        }

        if (someObject.tag == "FlagCheckPoint")
        {
            ponyRespawn = someObject.transform.position;
        }
    }
        void OnCollisionEnter2D(Collision2D someObject){

            if(someObject.gameObject.tag == "MovingStructure")
            {
                transform.parent = someObject.transform;
            }
        }


        void OnCollisionExit2D(Collision2D someObject) { //undo the parent relationship between player and "Moving Platform" 
            if (someObject.gameObject.tag == "MovingStructure")
            {
                transform.parent = null;
            }
        }


    public void EnemyHitBack()
    {
        enemyHitbackCounter = enemyHitbackDistance;
        invincibilityCounter = invincibilityTime;
        instanceSM.invincible = true;
    }
   

    


}
