using UnityEngine;
using System.Collections;

public class MoreLives : MonoBehaviour { //This script handles giving the player more lives.

    public int lifePoints;
    private SceneController instanceSM;

	// Use this for initialization
	void Start () {
        instanceSM = FindObjectOfType<SceneController>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D someObject)
    {
        if(someObject.tag == "twily")
        {

            instanceSM.GiveTwiLives(lifePoints);
            gameObject.SetActive(false);
        }

    }
}
