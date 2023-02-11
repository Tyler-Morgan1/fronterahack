using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D ridge;
        private Vector2 position;
        private float speed = 1.0f;
        
        public bool correct = false;
    void Start()
    {
        ridge = gameObject.GetComponent<Rigidbody2D>();
        position = new Vector2(0,-1);
    }

    // Update is called once per frame
    void FixedUpdate(){

    ridge.MovePosition(ridge.position + position * speed * Time.fixedDeltaTime);

    }
     void OnTriggerEnter2D(Collider2D collision){
        Debug.Log(correct);
     }
}
