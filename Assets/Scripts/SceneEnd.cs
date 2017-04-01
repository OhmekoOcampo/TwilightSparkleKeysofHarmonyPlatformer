using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; //To mess with changing levels.

public class SceneEnd : MonoBehaviour {

    public string nextLevel;

    private TwilyControl instanceTwi;
    private CameraAi instanceCamera;
    private SceneController instanceCM;

    public float twiGettingReady; //Twi getting ready for next level.
    public float nextLevelLoadTime;

    private bool moveTwiNextLevel;
	// Use this for initialization
	void Start () {

        instanceTwi = FindObjectOfType<TwilyControl>();
        instanceCamera = FindObjectOfType<CameraAi>();
        instanceCM = FindObjectOfType<SceneController>(); 
        
	}
	
	// Update is called once per frame
	void Update () {

        if(moveTwiNextLevel == true)
        {
            instanceTwi.twiRigidBody.velocity = new Vector3(instanceTwi.twiSpeed, instanceTwi.twiRigidBody.velocity.y, 0f);
        }
	
	}

    void OnTriggerEnter2D(Collider2D someObject)
    {
        if(someObject.tag == "twily")
        {

            //SceneManager.LoadScene(nextLevel);
            StartCoroutine("EndingTheLevelCo");
        }
    }

    public IEnumerator EndingTheLevelCo()
    {

        instanceTwi.canTwiMove = false;
        instanceCamera.followTwi = false;
        instanceCM.invincible = true;

        instanceCM.SceneMusic.Stop();
        instanceCM.EndOfLevelMusic.Play();

        instanceTwi.twiRigidBody.velocity = new Vector3(0f, 0f, 0f);
        yield return new WaitForSeconds(twiGettingReady);
        moveTwiNextLevel = true;
        yield return new WaitForSeconds(nextLevelLoadTime);
        SceneManager.LoadScene(nextLevel);
    }
}
