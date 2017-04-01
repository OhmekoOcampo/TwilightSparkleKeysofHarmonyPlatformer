using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour {

    public float transitionTime;

    public Image transitionScreen;

	// Use this for initialization
	void Start () {
        transitionScreen = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        transitionScreen.CrossFadeAlpha(0f, transitionTime, false);

        if(transitionScreen.color.a == 0) {

            gameObject.SetActive(false);

        }
	}
}
