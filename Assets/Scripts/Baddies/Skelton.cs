using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelton : BasicEnemy
{

    public override void move()
    {

        if (player.transform.position.y > transform.position.y)
            transform.position -= new Vector3(4f, -1f, 0) * Time.deltaTime; 
        else if (player.transform.position.y < transform.position.y)
            transform.position -= new Vector3(4f, 1f, 0) * Time.deltaTime; 


        if (player.transform.position.x > transform.position.x)
        {
            transform.position -= new Vector3(-3f, 0, 0) * Time.deltaTime; ;
        }
    }

}
