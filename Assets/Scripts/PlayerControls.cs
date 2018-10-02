using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public static PlayerControls instance;
   public Vector3 mousePosition;
   float speed = 4.3f;
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 vehiclePosition;
    public Transform player;
 SpriteRenderer rend;
    Animator animator;

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



        rend.sortingOrder = -1*(int)transform.position.y;
        if (alive)
        {
         
            if (Input.GetMouseButton(0))
            {
                getMouseLocation();
                animator.SetBool("IsMoving", true);
                transform.position -= new Vector3(2f * Time.deltaTime, 0, 0);

            }
            else
            {
                animator.SetBool("IsMoving", false);
                transform.position -= new Vector3(3f * Time.deltaTime, 0, 0);

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
   

    public void getMouseLocation()
    {
        if (alive)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 desiredPos = mousePosition - transform.position;
            desiredPos.z = 0;
            desiredPos.Normalize();
            desiredPos *= speed;
            transform.position += desiredPos * Time.deltaTime;
            desiredPos = Vector3.zero;
        }
          
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            alive = false;
        }
        if (collision.tag == "Hat")
        {
            EnemyManger.instance.hats += 1;
            Destroy(collision.gameObject);
        }        

       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            alive = false;
        }

     
    }

    private void OnMouseOver()
    {

    }

    private void OnMouseExit()
    {
     //   move = true;
    }

}


