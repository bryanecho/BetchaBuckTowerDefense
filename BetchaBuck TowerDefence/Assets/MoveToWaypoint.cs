using UnityEngine;
using System.Collections;

public class MoveToWaypoint : MonoBehaviour {
   
    
    public float speed = 0.5f; // lower numbers are faster
    public string waypointName = "Waypoint";
    public int highestWaypoint = 10;

    Transform destination;
    int currentWaypointNumber = 1;
    
    float xDistance = 0.0f;
    int Initial_X_Direction = 1; 
    float xOffset = 0.0f;

    float yDistance = 0.0f;
    float yOffset = 0.0f;
  
    bool reachedDestination = false;

  	// Use this for initialization
	void Start () 
        {
            
            ResetMovementInfo();
       	}
	
	// Update is called once per frame
    void Update()
    {
           
        if (reachedDestination == false)
        {
            //Move this
            this.transform.position = new Vector3(this.transform.position.x + xOffset *Time.deltaTime ,
                                                  this.transform.position.y + yOffset *Time.deltaTime,
                                                  0);
        }

        //to check Is this.x now on other side of waypoint
        xDistance = destination.transform.position.x - this.transform.position.x; 
       
        if ( xDistance*Initial_X_Direction<0) // Collision with Waypoint within 1 unit of "speed"

        {
            //go to next waypoint
            currentWaypointNumber++;

            //this is dead if at last waypoint
            if (currentWaypointNumber>highestWaypoint)
            { 
                reachedDestination = true;
                Destroy(this.gameObject);
            }
            else 
            //move to next waypoint
            { 
                ResetMovementInfo();}
             }
       
    }

   
    void ResetMovementInfo()
    {
        destination = GameObject.Find(waypointName + currentWaypointNumber).transform;
        reachedDestination = false; 
        Initial_X_Direction = 1;

        yDistance = destination.transform.position.y - this.transform.position.y;
        yOffset = yDistance / speed;

        xDistance = destination.transform.position.x - this.transform.position.x;
        xOffset = xDistance / speed;
        if (xDistance < 1)
        { Initial_X_Direction = -1; } // for collision detection with waypoint on 1 axis only
        

    }




}
