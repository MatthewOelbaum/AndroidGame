using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goop : BasicEnemy
{
    float time = 0;
    public override void move()
    {
        time += 1 * Time.deltaTime;
        if (time > 4.5)
            Destroy(gameObject);
        base.move();
    }

}
