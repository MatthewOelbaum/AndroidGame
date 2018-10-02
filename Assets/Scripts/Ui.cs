using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour {

    public bool alive;
    public Object scene;
    GameObject[] UiStuff;
    public Text hCount;
    public GameObject light;
    // Use this for initialization
    void Start () {
        UiStuff = GameObject.FindGameObjectsWithTag("Ui");
        light = GameObject.FindGameObjectWithTag("Light");
    }
	
	// Update is called once per frame
	void Update () {
        alive = PlayerControls.instance.alive;

        hCount.text = EnemyManger.instance.hats + "x";

        if (alive)
        {
            foreach(GameObject ele in UiStuff)
            {
                if(ele.activeSelf)
                ele.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject ele in UiStuff)
            {
                if (!ele.activeSelf)
                    ele.SetActive(true);
            }
            if(light.activeSelf)
            light.SetActive(false);
        }
	}

    public void newScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void menuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
