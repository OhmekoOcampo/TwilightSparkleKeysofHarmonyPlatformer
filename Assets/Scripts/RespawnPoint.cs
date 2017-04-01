using UnityEngine;
using System.Collections;

public class RespawnPoint : MonoBehaviour {


    //Change Flag Variables
    public Sprite flagActivated; //put sprite here that signifies checkpoint activated.
    public Sprite flagDeactivated; //put sprite here that signifies checkpoint unactivated.

    private SpriteRenderer checkPointSprite; //SpriteRenderer component of the flag sprite.

    //See if a Checkpoint has been activated
    public bool respawnPointActive;



	// Use this for initialization
	void Start () {
        checkPointSprite = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D Twily)
    {
        if(Twily.tag == "twily")
        {
            checkPointSprite.sprite = flagActivated;
            respawnPointActive = true;
        }

    }
}
