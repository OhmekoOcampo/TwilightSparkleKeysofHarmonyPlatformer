using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

    private SceneController instanceCM;

	// Use this for initialization
	void Start () {
        instanceCM = FindObjectOfType<SceneController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D someObject)
    {
        if(someObject.tag == "twily")
        {
            instanceCM.AddApples(3);
            gameObject.SetActive(false); //so object can be brought back for reset.
        }
    }
}
