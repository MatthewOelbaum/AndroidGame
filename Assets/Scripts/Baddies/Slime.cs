using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime :BasicEnemy {

    public override void move()
    {
        if (player.transform.position.y > transform.position.y)
            transform.position -= new Vector3(0.03f, -0.02f, 0);
        else if (player.transform.position.y < transform.position.y)
            transform.position -= new Vector3(0.03f, 0.02f, 0);




    }
 }
