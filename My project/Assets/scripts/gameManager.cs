using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    private bool stillGoing = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(gameRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator gameRoutine(){
    yield return new WaitUntil(() => (Input.GetKeyDown("space")));
    GameObject.Find("Title").gameObject.SetActive(false);
    GameObject.Find("Spawner").gameObject.SetActive(true);
    }
}
