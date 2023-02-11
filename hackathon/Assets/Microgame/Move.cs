using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float SPEED = 10.0f;
    public float BOOST = 2.0f;
    private Vector2 SCREEN_MAX;
    private Vector2 SCREEN_MIN;
    private Vector2 SELF_EXTENTS;
    private Vector2 _velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        // get screen size from camera (convert viewport 0,0 and 1,1 to world)
        SCREEN_MAX = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        SCREEN_MIN = Camera.main.ViewportToWorldPoint(Vector2.zero);

        // get self size from the sprite
        // bounds.extents is the half width/height of the sprite in world units
        SELF_EXTENTS = (Vector3)transform.GetComponent<SpriteRenderer>().sprite.bounds.extents;
    }

    // Update is called once per frame
    void Update()
    {
        // convert user input into a movement direction (could use Unity axis for this)
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.D)) dir += Vector2.right;
        if (Input.GetKey(KeyCode.A)) dir += Vector2.left;
        if (Input.GetKey(KeyCode.W)) dir += Vector2.up;
        if (Input.GetKey(KeyCode.S)) dir += Vector2.down;

        SPEED = 10.0f;
        // add speed when spacebar is pressed
        if (Input.GetKey(KeyCode.Space)) {
            SPEED = SPEED * 3.5f;
        }

        // set velocity based on movement direction
        _velocity = dir.normalized * SPEED;


        // integrate velocity to update position
        transform.position = transform.position + (Vector3)(_velocity * Time.deltaTime);

        // detect wall collisions and respond
        if (transform.position.x + SELF_EXTENTS.x > SCREEN_MAX.x) {
            transform.position = (Vector3)new Vector2(SCREEN_MAX.x - SELF_EXTENTS.x, transform.position.y);
        }
        else if (transform.position.x - SELF_EXTENTS.x < SCREEN_MIN.x) {
            transform.position = (Vector3)new Vector2(SCREEN_MIN.x + SELF_EXTENTS.x, transform.position.y);
        }
        if (transform.position.y + SELF_EXTENTS.y > SCREEN_MAX.y) {
            transform.position = (Vector3)new Vector2(transform.position.x, SCREEN_MAX.y - SELF_EXTENTS.y);
        }
        else if (transform.position.y - SELF_EXTENTS.y < SCREEN_MIN.y) {
            transform.position = (Vector3)new Vector2(transform.position.x, SCREEN_MIN.y + SELF_EXTENTS.y);
        }

        // detect game ending collisions
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            float r = enemy.GetComponent<Bounce>().GetRadius();
            float min_dist = r + SELF_EXTENTS.x;
            
            Vector2 diff = transform.position - enemy.transform.position;
            float dist = diff.magnitude;

            if (dist < min_dist) {
                // quit either from the editor or from a built application
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif
            }

        }

        // detect lurker contact
        GameObject[] enemiesLurkers = GameObject.FindGameObjectsWithTag("EnemyLurk");
        foreach (GameObject enemyLurk in enemiesLurkers) {
            float r = enemyLurk.GetComponent<LurkerMove>().GetRadius();
            // make radius of lurker a little smaller
            r *= 0.8f;
            float min_dist = r + SELF_EXTENTS.x;
            
            Vector2 diff = transform.position - enemyLurk.transform.position;
            float dist = diff.magnitude;

            if (dist < min_dist) {
                // quit either from the editor or from a built application
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif
            }
        }

    }
}
