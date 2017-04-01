using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditScene : MonoBehaviour {

    public string backToMainMenu;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void toMainMenu()
    {
        SceneManager.LoadScene(backToMainMenu); 
    }
}
