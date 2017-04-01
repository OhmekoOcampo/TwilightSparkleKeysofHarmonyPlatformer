using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour {

    //public string restartLevel;
    public string mainMenu;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

}
