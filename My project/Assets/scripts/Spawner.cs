using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public const float SPAWN_INTERVAL = 3.0f;
    public int num_of_questions = 5;
    private Vector2 SCREEN_MAX;
    private Vector2 SCREEN_MIN;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            // timer expired, time to spawn if we still have children
            if (transform.childCount >= 1) {
                // unparent from this object
                Transform child_transform = transform.GetChild(Random.Range(0, num_of_questions)); // max is exclusive
                child_transform.parent = null;
                num_of_questions -= 1;
                    
                // get the control script for that child and enabled, which will invoke Start/Update
                child_transform.gameObject.SetActive(true);
            }
    }
}
