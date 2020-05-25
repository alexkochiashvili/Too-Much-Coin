using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Player player;
    float y = 0;
    public float Speed, Contrast = 1f;
    public GameObject particles;
    bool moveOrNot;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        y = Random.Range(0, 179);
    }

    void FixedUpdate()
    {
        if(moveOrNot)
        {
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + new Vector2(0, Mathf.Sin(y) * Contrast));
            y += Speed;
            if(y == 180)
            {
                y = 0;
            }
            moveOrNot = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
        {
            player.PickedUpACoin();
            gameObject.SetActive(false);
            Instantiate(particles, transform.position, transform.rotation);
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Main Camera")
        {
            moveOrNot = true;
        }
    }
}
