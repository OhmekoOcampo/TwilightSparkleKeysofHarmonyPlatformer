using UnityEngine;
using System.Collections;

public class TheSmoozeController : MonoBehaviour {


    public Transform LeftStartPatrol;
    public Transform RightStartPatrol;//Points of patrol.

    public float smoozeSpeed;
    private Rigidbody2D smoozeRigidBody;

    public bool smoozeRight;


	// Use this for initialization
	void Start () {
        smoozeRigidBody = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(smoozeRight == true && transform.position.x > RightStartPatrol.position.x)
        {
            smoozeRight = false;
        }
        if(smoozeRight == false && transform.position.x < LeftStartPatrol.position.x)
        {
            smoozeRight = true;
        }

        if(smoozeRight == true)
        {
            smoozeRigidBody.velocity = new Vector3(smoozeSpeed, smoozeRigidBody.velocity.y, 0f);
        }
        else
        {
            smoozeRigidBody.velocity = new Vector3(-smoozeSpeed, smoozeRigidBody.velocity.y, 0f);
        }

	}
}
