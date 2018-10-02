using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime :BasicEnemy {

    public override void move()
    {
        if (player.transform.position.y > transform.position.y)
            transform.position -= new Vector3(3f, -1f, 0) * Time.deltaTime;
        else if (player.transform.position.y < transform.position.y)
            transform.position -= new Vector3(3f, 1f, 0) * Time.deltaTime;




    }
 }
