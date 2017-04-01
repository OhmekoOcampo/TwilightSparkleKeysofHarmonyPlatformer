using UnityEngine;
using System.Collections;

public class EverfreeSpiderController : MonoBehaviour
{

    public float spiderSpeed;
    private bool spiderCanMove;

    private Rigidbody2D spiderRidgidBody;

    // Use this for initialization
    void Start()
    {

        spiderRidgidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (spiderCanMove == true)
        {
            spiderRidgidBody.velocity = new Vector3(-spiderSpeed, spiderRidgidBody.velocity.y, 0f);
        }

    }
    void OnBecameVisible() //When player is seen by player EverfreeSpider will move.
    {
        spiderCanMove = true;
    }
    void OnEnable() //Spider first time 
    {
        spiderCanMove = false;
    }

    void OnTriggerEnter2D(Collider2D someObject)
    {
        if (someObject.tag == "RespawnArea")
        {
            gameObject.SetActive(false);
        }
    }

} 
