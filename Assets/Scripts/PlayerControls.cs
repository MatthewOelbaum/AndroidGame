using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public static PlayerControls instance;
   public Vector3 mousePosition;
   float speed = 0.11f;
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 vehiclePosition;
    public Transform player;
 SpriteRenderer rend;
    Animator animator;

    public float goopTime = 10;
   public  bool alive;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Warning multiple controlers found");
            return;
        }
        instance = this;
    }

    // Use this for initialization
    void Start () {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rend = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        alive = true;
   
    }
	
	// Update is called once per frame
	void Update () {
        if(goopTime < 4 * Time.deltaTime)
            speed = 0.04f;

        goopTime += Time.deltaTime;

        rend.sortingOrder = -1*(int)transform.position.y;
        if (alive)
        {
            UpdatePosition();
            if (Input.GetMouseButton(0))
            {
                getMouseLocation();
                animator.SetBool("IsMoving", true);
                transform.position -= new Vector3(0.01f, 0, 0);

            }
            else
            {
                animator.SetBool("IsMoving", false);
                transform.position -= new Vector3(0.03f, 0, 0);

            }
         

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x < transform.position.x)
            {
                rend.flipX = true;
            }
            if (mousePos.x > transform.position.x)
            {
                rend.flipX = false;
            }
        }
        else
        {
            animator.SetBool("IsDead", true);
        }
     
    }
    void UpdatePosition()
    {
        // Grab the transform's position so the character
        //   is updated every frame

        vehiclePosition = transform.position;

        // Add accel to velocity
        velocity += acceleration;


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
        if (alive)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 desiredPos = mousePosition - vehiclePosition;
            desiredPos.Normalize();
            desiredPos *= speed;

            transform.position += desiredPos;
        }
          
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        speed = 0.11f;
        if (collision.tag == "Enemy")
        {
            alive = false;
        }
        if (collision.tag == "Hat")
        {
            EnemyManger.instance.hats += 1;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Goop")
        {
            goopTime = 0;
            speed = 0.05f;
        }


       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            alive = false;
        }

     
    }


}


