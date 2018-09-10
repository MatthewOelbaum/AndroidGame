using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
   public Vector3 mousePosition;
    public float speed = 0.1f;
    

    public Vector3 velocity;
    //acceleration
    public Vector3 acceleration;

    public Vector3 vehiclePosition;

    // Use this for initialization
    void Start () {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            UpdatePosition();
            getMouseLocation();
        }
    }
    void UpdatePosition()
    {
        // Grab the transform's position so the character
        //   is updated every frame

        vehiclePosition = transform.position;

        // Add accel to velocity
        velocity += acceleration;

        velocity = Vector3.ClampMagnitude(velocity, speed);

        // Add velocity to position
        vehiclePosition += velocity;

        // Start "fresh" with accel
        acceleration = Vector3.zero;

        vehiclePosition.z = 0;
        // Set the transform
        transform.position = vehiclePosition;


    }

    public void getMouseLocation()
    {
       
           mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 desiredPos= mousePosition - vehiclePosition;
            desiredPos.Normalize();
            desiredPos *= speed;

            acceleration += desiredPos;
    }
}
