using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {

   public GameObject player;
   public SpriteRenderer render;
    // Update is called once per frame
    private void Start()
    {
        render = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update () {
        layer();
        player = GameObject.FindGameObjectWithTag("Player");
        if (PlayerControls.instance.alive)
            move();
        dead();
	}

    public virtual void move()
    {
        transform.position -= new Vector3(3f, 0, 0) * Time.deltaTime;
    }
    public virtual void dead()
    {
        if (transform.position.x <= -9.10f)
            Destroy(gameObject);
    }

    public virtual void layer()
    {
        render.sortingOrder = -1 * (int)transform.position.y;
    }
}
