using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class Waypoint : MonoBehaviour {

    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 2f;

    int waypointIndex = 0;

	void Start() {
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	void Update() {
        Move();
	}

    void Move()
    {
        if(waypointIndex <= waypoints.Length - 1){
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }

    }
}
