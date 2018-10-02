using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilSlime : BasicEnemy
{

    public override void move()
    {
        if (player.transform.position.y > transform.position.y)
            transform.position -= new Vector3(3f, -3f, 0) * Time.deltaTime;
        else if (player.transform.position.y < transform.position.y)
            transform.position -= new Vector3(3f, 3f, 0) * Time.deltaTime;




    }
}
