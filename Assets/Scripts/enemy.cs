using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed;
    public LayerMask ground, spikes;
    bool moveOrNot = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if(moveOrNot)
        {
            transform.position = (Vector2)transform.position + new Vector2(Speed, 0);
            CheckOn(ground);
            CheckOn(spikes);
            moveOrNot = false;
        }
    }

    void CheckOn(LayerMask layer)
    {
        if(Physics2D.Raycast(transform.position, Vector2.left, 1f, layer).collider != null ||  Physics2D.Raycast(transform.position, Vector2.right, 1f, layer).collider != null  )
        {
            Speed = -Speed;
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "MainCamera")
        {
            moveOrNot = true;
        }
    }
}
