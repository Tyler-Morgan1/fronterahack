using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
        public Rigidbody2D ridge;
        private Vector2 position;
        private float speed = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position.x = Input.GetAxisRaw("Horizontal");

        
    }

    void FixedUpdate(){
                ridge.MovePosition(ridge.position + position * speed * Time.fixedDeltaTime);

    }
}
