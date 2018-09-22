using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManger : MonoBehaviour {

    // Use this for initialization

    public static  EnemyManger instance;

    public GameObject Hat;
    public GameObject wallPrefab1;
    public GameObject wallPrefab2;
    public GameObject wallPrefab3;

    //baddies
    public GameObject Slime;
    public GameObject Skelton;
    public GameObject Masked;

    float Timer = 0;
    float TimerMax = 0;

   public int hats = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Warning multiple mangers found");
            return;
        }
        instance = this;
    }

    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Timer += 1 * Time.deltaTime;

        if (Timer >= TimerMax)
            generateNext();
    }

    public void spawn(GameObject obj, bool ghost)
    {
       Timer = 0;
        TimerMax = Random.Range(30, 100) * Time.deltaTime;
        float yPos = Random.Range(-4.35f, 4.25f);  
        obj.transform.position = new Vector3(11.64f, yPos, 0);
        if (ghost)
            obj.transform.position = new Vector3(-9.80f, yPos, 0);
        Instantiate(obj);
       
    }

    public void generateNext()
    {
        int genNext = 0;

        switch (hats)
        {
            case 0:
            case 1:
                genNext = Random.Range(0, 5);
                break;
            case 2:
            case 3:
            case 4:
                genNext = Random.Range(0, 6);
                break;
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                genNext = Random.Range(0, 8);
                break;
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
                genNext = Random.Range(0, 10);
                break;
            case 16:
            case 17:
            case 18:
            case 19:
                genNext = Random.Range(0, 14);
                break;
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
                genNext = Random.Range(0, 24);
                break;
            case 25:
            case 26:
            case 27:
            case 28:
            case 29:
                genNext = Random.Range(0, 28);
                break;
            default:
                genNext = Random.Range(0, 28);
                break;
        }




        switch (genNext)
        {
            case 1:
            case 14:
            case 15:
            default:
                spawn(Hat,false);
                break;
            case 2:
            case 3:
            case 11:
            case 12:
            case 24:
            case 25:
                spawn(wallPrefab1, false);
                break;         
            case 4:
            case 5:
            case 13:
            case 26:
            case 27:
                spawn(wallPrefab2, false);
                break;
            case 6:
            case 19:
            case 20:
                spawn(wallPrefab3, false);
                break;
            case 7:
            case 8:
            case 17:
            case 18:
                spawn(Slime, false);
                break;
            case 9:
            case 10:
            case 16:
                spawn(Skelton, false);
                break;
            case 21:
            case 22:
                spawn(Masked, false);
                break;
           
               
        }

    }
}
