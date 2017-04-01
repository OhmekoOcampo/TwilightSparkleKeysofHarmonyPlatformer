using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour
{

    public GameObject objectToMove; //make a reference to object to be moved.

    public Transform startPoint; //We just need to know the position of the object. 
    public Transform endPoint;

    public float moveSpeed; //Speed of object. 

    private Vector3 currentTarget;

    // Use this for initialization
    void Start()
    {

        currentTarget = endPoint.position;


    }

    // Update is called once per frame
    void Update()
    {

        //We always want to be moving to our currentTarget.
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);

        if (objectToMove.transform.position == endPoint.position)
        {
            currentTarget = startPoint.position;
        }

        if (objectToMove.transform.position == startPoint.position)
        {
            currentTarget = endPoint.position;
        }

    }
}
