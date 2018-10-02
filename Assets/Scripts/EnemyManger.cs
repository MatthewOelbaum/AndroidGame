using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManger : MonoBehaviour {

    // Use this for initialization

    public static  EnemyManger instance;

    public GameObject Hat;
    public GameObject wallPrefab1;
    public GameObject wallPrefab2;

    //baddies
    public GameObject Slime;
    public GameObject Skelton;
    public GameObject Masked;
    public GameObject Fire;
    public GameObject EvilSlime;


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

        if (Timer >= TimerMax && PlayerControls.instance.alive)
            generateNext();


   
    }

    public void spawn(GameObject obj, bool ghost)
    {
       Timer = 0;
        TimerMax = Random.Range(30, 100) * Time.deltaTime;
        float yPos = Random.Range(-4.35f, 2.05f);  
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
            case 30:
            case 31:
            case 32:
            case 33:
            case 34:
            case 35:
            case 36:
            case 37:
                genNext = Random.Range(0, 35);
                break;
            case 38:
            case 39:
            case 40:
            case 41:
            case 42:
                genNext = Random.Range(0, 41);
                break;
            case 44:
            case 45:
            case 46:
            case 47:
            case 48:
                genNext = Random.Range(0, 51);
                break;
            case 49:
            case 50:
            case 51:
            case 52:
            case 53:
                genNext = Random.Range(0, 60);
                break;
            case 54:
            case 55:
            case 56:
            case 57:
            case 58:
                genNext = Random.Range(0, 70);
                break;
            case 59:
            case 60:
            case 61:
            case 62:
            case 63:
                genNext = Random.Range(0, 81);
                break;
            default:
                genNext = Random.Range(0, 81);
                break;
        }




        switch (genNext)
        {
            case 1:
            case 14:
            case 15:
            case 40:
            case 41:
            case 47:
            case 48:
            case 59:
            case 60:
            case 61:
            case 62:
            case 63:
            default:
                spawn(Hat,false);
                break;
            case 2:
            case 3:
            case 11:
            case 12:
            case 24:
            case 16:
            case 33:
            case 34:
            case 37:
            case 64:
            case 65:
            case 66:
                spawn(wallPrefab1, false);
                break;         
            case 4:
            case 5:
            case 13:
            case 26:
            case 27:
            case 6:
            case 19:
            case 20:
            case 38:
            case 49:
            case 50:
            case 57:
            case 58:
                spawn(wallPrefab2, false);
                break;             
            case 7:
            case 8:
            case 17:
            case 18:
            case 32:
            case 39:
            case 67:
            case 68:
            case 69:
            case 70:
                spawn(Slime, false);
                break;
            case 9:
            case 10:
            case 25:
            case 43:
            case 44:
            case 45:
            case 46:
                spawn(Skelton, false);
                break;
            case 21:
            case 22:
            case 35:
            case 36:
            case 74:
            case 75:
            case 76:
            case 77:
                spawn(Masked, false);          
                break;
            case 28:
            case 29:
            case 30:
            case 31:
            case 56:
            case 78:
            case 79:
            case 80:
                spawn(Fire, true);
                break;
            case 51:
            case 52:
            case 53:
            case 54:
            case 55:
            case 71:
            case 72:
            case 73:
                spawn(EvilSlime, false);
                break;

        }

    }
}
