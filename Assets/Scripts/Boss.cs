using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public bool bossActive;

    //timers
    public float timeBetweenDrops; //seconds between each spider dropping
    private float dropCount; //count down to the next timeBetweenDrops

    public float waitForPlatforms; //time between left and right platforms appearing.
    private float platformCount;

    //make reference to the boundary points where spiders will be spawning into world
    public Transform leftPoint;
    public Transform rightPoint;
    public Transform dropSpiderSpawnPoint;

    public GameObject dropSpider; //Will hold the everfree spider object, modified for this boss level.
    public GameObject theBoss;

    public bool bossRight; //if boss should be on right it should be true, if not boss is on left it should be false.

    public GameObject rightPlatforms; //Reference to rightPlatform and leftPlatform objects.
    public GameObject leftPlatforms;

    public bool takeDamage;

    public int startingHealth; //boss health
    private int currentHealth;

    public GameObject EndGame; //End the game!

    // Use this for initialization
    void Start () {
        dropCount = timeBetweenDrops;
        platformCount = waitForPlatforms;
        currentHealth = startingHealth;
        theBoss.transform.position = rightPoint.position; //Spawn the boss at the rightPoint object position.
        bossRight = true;
	}
	
	// Update is called once per frame
	void Update () {

        if(bossActive == true)
        {
            theBoss.SetActive(true);
            if(dropCount > 0)
            {
                dropCount = dropCount - Time.deltaTime; //Counts down the dropCount
            } else //if time is less then zero we have to emit a spider
            {
                dropSpiderSpawnPoint.position = new Vector3(Random.Range(leftPoint.position.x, rightPoint.position.x), dropSpiderSpawnPoint.position.y, dropSpiderSpawnPoint.position.z);
                Instantiate(dropSpider, dropSpiderSpawnPoint.position, dropSpiderSpawnPoint.rotation);
                dropCount = timeBetweenDrops;
            }

            if(bossRight == true)
            {
                if(platformCount > 0)
                {
                    platformCount = platformCount - Time.deltaTime; // start counting down for platforms to appear.
                }else
                {
                    rightPlatforms.SetActive(true); //make right platforms appear.
                }
            }else
            {
                if(platformCount > 0)
                {
                    platformCount = platformCount - Time.deltaTime;
                }
                else
                {
                    leftPlatforms.SetActive(true);
                }
            }

            if (takeDamage == true)
            {
                currentHealth = currentHealth - 1;

                if(currentHealth <= 0)
                {
                    EndGame.SetActive(true);
                    gameObject.SetActive(false);
                }

                if (bossRight)
                {
                    theBoss.transform.position = leftPoint.position;
                    theBoss.transform.rotation = leftPoint.rotation;
                }else
                {
                    theBoss.transform.position = rightPoint.position;
                    theBoss.transform.rotation = rightPoint.rotation;
                }

                bossRight = !bossRight;
                rightPlatforms.SetActive(false);
                leftPlatforms.SetActive(false);
                platformCount = waitForPlatforms;

                timeBetweenDrops = timeBetweenDrops / 2f;

                takeDamage = false;
            }
        }
	
	}


    void OnTriggerEnter2D(Collider2D someObject)
    {
        if(someObject.tag == "twily")
        {
            bossActive = true; // Activate boss battle
        }
    }


}
