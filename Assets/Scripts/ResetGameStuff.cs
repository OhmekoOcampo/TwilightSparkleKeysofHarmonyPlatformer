using UnityEngine;
using System.Collections;


public class ResetGameStuff : MonoBehaviour {

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;
    private Vector3 defaultLocalScale;

    private Rigidbody2D someRigidBody;

	// Use this for initialization
	void Start () {

        defaultPosition = transform.position;
        defaultRotation = transform.rotation;
        defaultLocalScale = transform.localScale;

        if(GetComponent<Rigidbody2D>() != null)
        {
            someRigidBody = GetComponent<Rigidbody2D>();
        }
        

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ResetTheObjectsAfterDeath()
    {
        transform.position = defaultPosition;
        transform.rotation = defaultRotation;
        transform.localScale = defaultLocalScale;

        if(someRigidBody != null) //
        {
            someRigidBody.velocity = new Vector3(0f, 0f, 0f);
        }

    }
}
