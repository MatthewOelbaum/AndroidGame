using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : BasicEnemy
{
    public GameObject goop;
    float timer = 0;
    float timerMax = 0;
    float goopTime = 0;
    int direction = 1;
    Vector3 postionChange = Vector3.zero;

    public override void move()
    {
        goopTime += 1 * Time.deltaTime;
        timer += 1 * Time.deltaTime;
        transform.position -= postionChange;
        if (timer >= timerMax)
            changeDirections();

        if (goopTime >= 80 * Time.deltaTime)
            makeGoop();
    }
    public void changeDirections()
    {
        timer = 0;
        timerMax = Random.Range(20, 40) * Time.deltaTime;
        direction = Random.Range(1, 5);

        switch (direction)
        {
            case 1:
                postionChange = new Vector3(2f, -1f, 0) * Time.deltaTime;
                break;
            case 2:
                postionChange = new Vector3(2f, 1f, 0) * Time.deltaTime;
                break;           
            default:
                if (player.transform.position.y > transform.position.y)
                    postionChange = new Vector3(3f, -1f, 0) * Time.deltaTime;
                else if (player.transform.position.y < transform.position.y)
                    postionChange = new Vector3(3f, 1f, 0) * Time.deltaTime; ;
                break;
          
        }

    }

    public void makeGoop()
    {
        goopTime = 0;
        goop.transform.position = transform.position;
        Instantiate(goop);
    }
}
