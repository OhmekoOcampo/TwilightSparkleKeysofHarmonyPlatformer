using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string beginningLevel;
    public string creditScene;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NewGame()
    {
        SceneManager.LoadScene(beginningLevel);
    }

    public void CreditScene()
    {
        SceneManager.LoadScene(creditScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
