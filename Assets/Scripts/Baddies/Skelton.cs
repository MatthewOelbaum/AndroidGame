using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelton : BasicEnemy
{

    public override void move()
    {

        if (player.transform.position.y > transform.position.y)
            transform.position -= new Vector3(0.06f, -0.03f, 0);
        else if (player.transform.position.y < transform.position.y)
            transform.position -= new Vector3(0.06f, 0.03f, 0);


        if (player.transform.position.x > transform.position.x)
        {
            transform.position -= new Vector3(-0.04f, 0, 0);
        }
    }

}
