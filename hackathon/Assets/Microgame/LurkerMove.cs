using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LurkerMove : MonoBehaviour
{
    public float SPEED = 5.0f;
    private Vector2 SCREEN_MAX;
    private Vector2 SCREEN_MIN;
    public Vector2 SELF_EXTENTS;
    private Vector2 _velocity = Vector2.zero;
    [SerializeField] private GameObject circle2;

    // Start is called before the first frame update
    void Start()
    {
        // get screen size from camera (convert viewport 0,0 and 1,1 to world)
        SCREEN_MAX = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        SCREEN_MIN = Camera.main.ViewportToWorldPoint(Vector2.zero);

        // get self size from the sprite
        // bounds.extents is the half width/height of the sprite in world units
        SELF_EXTENTS = transform.GetComponent<SpriteRenderer>().sprite.bounds.extents;


    }

    // public access to radius for collisions
    public float GetRadius() { return SELF_EXTENTS.x; }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, circle2.transform.position, SPEED * Time.deltaTime);

        // detect wall collisions and respond
        if (transform.position.x + SELF_EXTENTS.x > SCREEN_MAX.x) {
            transform.position = (Vector3)new Vector2(SCREEN_MAX.x - SELF_EXTENTS.x, transform.position.y);
            _velocity = (Vector3)new Vector2(-_velocity.x, _velocity.y);
        }
        else if (transform.position.x - SELF_EXTENTS.x < SCREEN_MIN.x) {
            transform.position = (Vector3)new Vector2(SCREEN_MIN.x + SELF_EXTENTS.x, transform.position.y);
            _velocity = (Vector3)new Vector2(-_velocity.x, _velocity.y);
        }
        if (transform.position.y + SELF_EXTENTS.y > SCREEN_MAX.y) {
            transform.position = (Vector3)new Vector2(transform.position.x, SCREEN_MAX.y - SELF_EXTENTS.y);
            _velocity = (Vector3)new Vector2(_velocity.x, -_velocity.y);
        }
        else if (transform.position.y - SELF_EXTENTS.y < SCREEN_MIN.y) {
            transform.position = (Vector3)new Vector2(transform.position.x, SCREEN_MIN.y + SELF_EXTENTS.y);
            _velocity = (Vector3)new Vector2(_velocity.x, -_velocity.y);
        }

    }
}