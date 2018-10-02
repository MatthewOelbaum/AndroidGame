using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMonster : BasicEnemy
{

    public override void move()
    {

        transform.position -= new Vector3(-4f, 0, 0) * Time.deltaTime; ;
    }

    public override void dead()
    {
        if (transform.position.x >= 11f)
            Destroy(gameObject);
    }
}
