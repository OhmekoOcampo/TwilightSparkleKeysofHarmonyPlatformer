using UnityEngine;
using System.Collections;

public class MoreHealth : MonoBehaviour {

    public int healthCollected;

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
            instanceSM.MoarHeartsTwi(healthCollected);
            gameObject.SetActive(false);
        }
    }

}
