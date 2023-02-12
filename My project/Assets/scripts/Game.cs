using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private GameObject Spawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(start());
        Spawn = GameObject.Find("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator start(){
    yield return new WaitUntil(() => Input.GetKeyDown("space"));
    GameObject.Find("Title").SetActive(false);
    GameObject LiveCounter = GameObject.Find("Lives");
    LiveCounter.transform.position = new Vector3(LiveCounter.transform.position.x + 25,LiveCounter.transform.position.y - 75,0);
    Spawn.GetComponent<Spawner>().enabled = true; 
    }
}
