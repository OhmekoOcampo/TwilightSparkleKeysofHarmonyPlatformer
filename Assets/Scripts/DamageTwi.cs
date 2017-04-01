using UnityEngine;
using System.Collections;

public class DamageTwi : MonoBehaviour {

    private SceneController instanceSM;

    public int damageToGive;


	// Use this for initialization
	void Start () {
        instanceSM = FindObjectOfType<SceneController>(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D someObject)
    {
        if (someObject.tag == "twily")
        {
            //instanceSM.Respawn();
            instanceSM.HurtPlayer(damageToGive);
        }
    }
}
