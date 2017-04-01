using UnityEngine;
using System.Collections;

public class DestroyObjectsAuto : MonoBehaviour {

    public float lifeSpanOfObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lifeSpanOfObject = lifeSpanOfObject - Time.deltaTime;

        if(lifeSpanOfObject <= 0f)
        {
            Destroy(gameObject);
        }
	}
}
