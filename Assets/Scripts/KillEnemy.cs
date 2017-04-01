using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {

    private Rigidbody2D hoofRigidbody;

    public float hoofStompReaction; //aesthetic reason, player bounces a little when stomping on enemy

    public GameObject TwiDeathParticles;

	// Use this for initialization
	void Start () {

        hoofRigidbody = transform.parent.GetComponent<Rigidbody2D>(); //access players rigid

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D someObject)
    {
        if(someObject.tag == "Enemy")
        {
            someObject.gameObject.SetActive(false);
            Instantiate(TwiDeathParticles, someObject.transform.position, someObject.transform.rotation);
            hoofRigidbody.velocity = new Vector3(hoofRigidbody.velocity.x, hoofStompReaction, 0f);
        }

        if(someObject.tag == "Boss")
        {
            hoofRigidbody.velocity = new Vector3(hoofRigidbody.velocity.x, hoofStompReaction, 0f);
            someObject.transform.parent.GetComponent<Boss>().takeDamage = true;
        }

    }

    
}
