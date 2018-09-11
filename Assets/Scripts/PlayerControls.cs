using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
   public Vector3 mousePosition;
    public float speed = 0.1f;
    public float swipeSpeed = 1f;
    public CircleCollider2D colider;


    public Vector3 velocity;
    //acceleration
    public Vector3 acceleration;

    public Vector3 vehiclePosition;

    public Swipe swipeControls;
    public Transform player;
    private Vector3 desiredPosition;

    public float swipeTimer;
   public float swipeRecharge;
    public float rechargeFloat;


    // Use this for initialization
    void Start () {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        swipeTimer = 0;
        swipeRecharge = 0;
    }
	
	// Update is called once per frame
	void Update () {
        swipeRecharge++;
        if (swipeRecharge >= rechargeFloat)
        {
            swipeRecharge = rechargeFloat;
            acceleration = Vector3.zero;
            desiredPosition = Vector3.zero;
            velocity = Vector3.zero;
        }

        swipeTimer--;
        if (swipeTimer <= 0)
        {
            swipeTimer = 0;
        }


        UpdatePosition();
        if (Input.GetMouseButton(0))
        {
           
            //  getMouseLocation();
            swipePosition();
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

        // player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 3f * Time.deltaTime);
    }

    public void getMouseLocation()
    {
       
           mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 desiredPos= mousePosition - vehiclePosition;
            desiredPos.Normalize();
            desiredPos *= speed;

            acceleration += desiredPos;
    }

    public void swipePosition()
    {
       swipeRecharge = 0;
            swipeTimer = 5;
            if (swipeControls.SwipeLeft)
            {
                desiredPosition += Vector3.left;
                Debug.Log("left");
            }

            if (swipeControls.SwipeRight)
            {
                desiredPosition += Vector3.right;
                Debug.Log("right");
            }

            if (swipeControls.SwipeUp)
            {
                desiredPosition += Vector3.up;
                Debug.Log("up");
            }

            if (swipeControls.SwipeDown)
            {
                desiredPosition += Vector3.down;
                Debug.Log("down");
            }
            desiredPosition.Normalize();
            desiredPosition *= swipeSpeed;
            acceleration += desiredPosition;






    }
}
