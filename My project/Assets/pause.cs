using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    private GameObject lion;
    private GameObject CanvasObj;
    private bool Paused = false;
    public GameObject[] backG;
    // Start is called before the first frame update
    void Start()
    {
        lion = GameObject.Find("LionSprite_0");
        CanvasObj = GameObject.Find("CanvasParent");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && Paused == false){
            backG[0].GetComponent<Renderer>().sortingOrder = 10;
            backG[1].GetComponent<Renderer>().sortingOrder = 10;
            backG[2].SetActive(true);

            Paused = true;
            lion.GetComponent<Animator>().enabled = false;
            CanvasObj.SetActive(false);
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown("space") && Paused == true){
            Paused = false;
            backG[0].GetComponent<Renderer>().sortingOrder = -10;
            backG[1].GetComponent<Renderer>().sortingOrder = -10;
            backG[2].SetActive(false);

            lion.GetComponent<Animator>().enabled = true;
            CanvasObj.SetActive(true);
            Time.timeScale = 1;
        }
    }
}
