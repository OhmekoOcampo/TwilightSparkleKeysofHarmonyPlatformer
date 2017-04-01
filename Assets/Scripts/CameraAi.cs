using UnityEngine;
using System.Collections;

public class CameraAi : MonoBehaviour {

    //This script is so that the Twily appears to be looking at either the right or left direction.

    //Twi look ahead. 
    public GameObject lookAtTwi; //Twily character object will be attached to this script
    public float twiVision; //Gives the appearance that Twily is looking ahead, add to the players look field
    private Vector3 twiPosition; //Current position of the Twily.

    //Making the twiVision a bit smoother.
    public float smoothing; //Look at Lerp function in Unity, took the function definition example

    //Animating the Level Exit
    public bool followTwi; //Camera will follow Twi

    // Use this for initialization
    void Start()
    {
        followTwi = true; //Camera will follow Player at start.
    }

    // Update is called once per frame
    void Update()
    {

       if (followTwi)
        {

            twiPosition = new Vector3(lookAtTwi.transform.position.x, transform.position.y, transform.position.z); //center of where the target is.
                                                                                                                   //Only way we can check to see if player face right or left is based on the scale of the player.

            if (lookAtTwi.transform.localScale.x > 0f)
            {
                twiPosition = new Vector3(twiPosition.x + twiVision, twiPosition.y, twiPosition.z);
            }
            else
            {
                twiPosition = new Vector3(twiPosition.x - twiVision, twiPosition.y, twiPosition.z);
            }
            transform.position = Vector3.Lerp(transform.position, twiPosition, smoothing * Time.deltaTime); //Time.deltaTime could be used for smoothing, how fast it take from one frame of animation to another. 
        }
    }

}
