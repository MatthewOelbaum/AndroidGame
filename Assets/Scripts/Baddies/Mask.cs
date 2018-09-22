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

        if (goopTime >= 50 * Time.deltaTime)
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
                postionChange = new Vector3(0.01f, -0.02f, 0);
                break;
            case 2:
                postionChange = new Vector3(0.01f, 0.02f, 0);
                break;           
            default:
                if (player.transform.position.y > transform.position.y)
                    postionChange = new Vector3(0, -0.03f, 0);
                else if (player.transform.position.y < transform.position.y)
                    postionChange = new Vector3(0, 0.03f, 0);
                if (player.transform.position.x > transform.position.x)
                    postionChange = new Vector3(-0.02f, 0, 0);
                else if (player.transform.position.y < transform.position.x)
                    postionChange = new Vector3(0.01f, 0, 0);
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
