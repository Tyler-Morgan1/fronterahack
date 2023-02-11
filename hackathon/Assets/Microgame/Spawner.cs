using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float _spawnTimer;
    public const float SPAWN_INTERVAL = 5.0f;
    private Vector2 SCREEN_MAX;
    private Vector2 SCREEN_MIN;

    // Start is called before the first frame update
    void Start()
    {
        // get screen size from camera (convert viewport 0,0 and 1,1 to world)
        SCREEN_MAX = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        SCREEN_MIN = Camera.main.ViewportToWorldPoint(Vector2.zero);

        // start spawn timer and count down
        _spawnTimer = SPAWN_INTERVAL;
    }

    // Update is called once per frame
    void Update()
    {
        // tick the timer down
        _spawnTimer = _spawnTimer - Time.deltaTime;
        if (_spawnTimer <= 0.0f) {
            // timer expired, time to spawn if we still have children
            if (transform.childCount >= 1) {
                // unparent from this object
                Transform child_transform = transform.GetChild(0);
                child_transform.parent = null;

                // set position (wall collision code will handle if it's too close to an edge)
                child_transform.position = (Vector3)new Vector2(
                    Random.Range(SCREEN_MIN.x, SCREEN_MAX.x),
                    Random.Range(SCREEN_MIN.y, SCREEN_MAX.y));
                    
                // get the control script for that child and enabled, which will invoke Start/Update
                GameObject child = child_transform.gameObject;
                Bounce child_script = child.GetComponent<Bounce>();
                child_script.enabled = true;
            }

            // reset timer (could deactivate self if children all gone)
            _spawnTimer = SPAWN_INTERVAL;
        }
    }
}
