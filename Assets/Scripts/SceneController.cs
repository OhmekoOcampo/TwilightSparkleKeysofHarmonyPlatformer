using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    public Text AppleCountText; //Make reference to Apple Count Text on UI screen
    public Image heartcontainer1;
    public Image heartcontainer2;
    public Image heartcontainer3; //Make reference to Heart Images on UI screen

    public Sprite twiheartfull;
    public Sprite twihearthalf;
    public Sprite twiheartempty; //Make reference to Heart Sprite Images

    public int maxTwiHealth;
    public int healthTwiCount; //Numerical representation of health.

    //Sound Stuff
    public AudioSource AppleBite;

    //Lives Variables
    public int twiCurrentLives;
    public int twiBeginLives;
    public Text lifeTextBox;

    //Respawn Variables
    public float waitToRespawn;
    public TwilyControl twily_control;
    public GameObject TwiDeathParticles; //You have to reference the particle system prefab.
    private bool twiRespawning;

    //Apple Collectible
    public int appleCount;

    //Bonus Life from Collecting Apples:
    private int lifeFromApples;

    //Respawn Array
    public ResetGameStuff[] gameObjectsDefaultPos;


    //For Invincibility when player is hitback by an enemy, kinda like Mario.
    public bool invincible;

    //End Game if Out of Lives
    public GameObject gameOverScreen;
    public AudioSource SceneMusic;
    public AudioSource DefeatedMusic;
    public AudioSource EndOfLevelMusic;

    // Use this for initialization
    void Start()
    {
        twily_control = FindObjectOfType<TwilyControl>(); //Find an object with the currently active scene that has a "TwilyControl" script attached to it.
        AppleCountText.text = "Apples Harvested: " + appleCount;

        //Health System
        healthTwiCount = maxTwiHealth; //Twi's health should be set to max at beginning of game. 


        //Respawn Array
        gameObjectsDefaultPos = FindObjectsOfType<ResetGameStuff>();

        //Lives System
        twiCurrentLives = twiBeginLives;
        lifeTextBox.text = "Twi's Lives x " + twiCurrentLives;
    }


    // Update is called once per frame
    void Update()
    {
        if (healthTwiCount <= 0 && twiRespawning == false)
        {
            Respawn();
            twiRespawning = true;
        }
        if (lifeFromApples >= 100)
        {
            twiCurrentLives = twiCurrentLives + 1;
            lifeTextBox.text = "Twi's Lives x " + twiCurrentLives;
            lifeFromApples = lifeFromApples - 100;
        }
    }

    public void Respawn()
    {

        twiCurrentLives = twiCurrentLives - 1;

        lifeTextBox.text = "Twi's Lives x" + twiCurrentLives;
        if (twiCurrentLives > 0)
        {
            StartCoroutine("WaitToRespawnCo");
        }
        else
        {
            twily_control.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            SceneMusic.Stop();
            DefeatedMusic.Play(); //Play GameOver Music.
        }
    }

    public IEnumerator WaitToRespawnCo() //Coroutine for adding pauses in Unity, needs WaitForSeconds function to work.
    {

        twily_control.gameObject.SetActive(false); //Instead of just the script TwilyControl using .gameObject references the whole object.

        Instantiate(TwiDeathParticles, twily_control.transform.position, twily_control.transform.rotation); //Create the particle system for Twi dying.

        yield return new WaitForSeconds(waitToRespawn); //Wait a little bit before respawing to either a checkpoint or beginning of level.

        healthTwiCount = maxTwiHealth;
        twiRespawning = false; //Makes sure we don't go into a loop of respawning.
        UpdateHeartUI();
        appleCount = 0;
        AppleCountText.text = "Apples Harvested: " + appleCount; //Reset Apples
        lifeFromApples = 0; //Reset Secret Apple Life
        twily_control.transform.position = twily_control.ponyRespawn;
        twily_control.gameObject.SetActive(true);

        for (int i = 0; i < gameObjectsDefaultPos.Length; i++)
        {
            gameObjectsDefaultPos[i].ResetTheObjectsAfterDeath();
            gameObjectsDefaultPos[i].gameObject.SetActive(true);
        }

    }

    public void AddApples(int applesToHarvest)
    {
        appleCount = appleCount + applesToHarvest; //Add apples to collection
        lifeFromApples = lifeFromApples + applesToHarvest;


        AppleCountText.text = "Apples Harvested: " + appleCount; //Keep track of Apple Collectibles
        AppleBite.Play();

    }

    public void HurtPlayer(int damagedealt)
    {

        if (invincible == false)
        {
            healthTwiCount = healthTwiCount - damagedealt;
            UpdateHeartUI();
            twily_control.EnemyHitBack();
            twily_control.DamageSound.Play();
        }

    }

    public void MoarHeartsTwi(int heartsCollected)
    {
        healthTwiCount = healthTwiCount + heartsCollected; //Add more health to Twi.
        if (healthTwiCount > maxTwiHealth)
        {
            healthTwiCount = maxTwiHealth;
        }
        UpdateHeartUI();
    }

    public void GiveTwiLives(int lifePoints)
    {
        twiCurrentLives = twiCurrentLives + lifePoints;
        lifeTextBox.text = "Twi's Lives x " + twiCurrentLives;
    }

    public void UpdateHeartUI() //Handles Heart UI Update
    {

        if (healthTwiCount == 6)
        {
            heartcontainer1.sprite = twiheartfull;
            heartcontainer2.sprite = twiheartfull;
            heartcontainer3.sprite = twiheartfull;
        }

        if (healthTwiCount == 5)
        {
            heartcontainer1.sprite = twiheartfull;
            heartcontainer2.sprite = twiheartfull;
            heartcontainer3.sprite = twihearthalf;
        }
        if (healthTwiCount == 4)
        {
            heartcontainer1.sprite = twiheartfull;
            heartcontainer2.sprite = twiheartfull;
            heartcontainer3.sprite = twiheartempty;
        }
        if (healthTwiCount == 3)
        {
            heartcontainer1.sprite = twiheartfull;
            heartcontainer2.sprite = twihearthalf;
            heartcontainer3.sprite = twiheartempty;
        }

        if (healthTwiCount == 2)
        {
            heartcontainer1.sprite = twiheartfull;
            heartcontainer2.sprite = twiheartempty;
            heartcontainer3.sprite = twiheartempty;
        }
        if (healthTwiCount == 1)
        {
            heartcontainer1.sprite = twihearthalf;
            heartcontainer2.sprite = twiheartempty;
            heartcontainer3.sprite = twiheartempty;
        }
        if (healthTwiCount == 0)
        {
            heartcontainer1.sprite = twiheartempty;
            heartcontainer2.sprite = twiheartempty;
            heartcontainer3.sprite = twiheartempty;
        }
        if (healthTwiCount < 0)
        {
            heartcontainer1.sprite = twiheartempty;
            heartcontainer2.sprite = twiheartempty;
            heartcontainer3.sprite = twiheartempty;
        }

    }

}
