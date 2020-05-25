using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    public GameObject enemy;
    public Transform body;
    public float distance;
    public GameObject particles;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Instantiate(particles, body.position, body.rotation);
            enemy.SetActive(false);
        }
    }
    public void Update()
    {
        transform.position = new Vector2(body.position.x, body.position.y + distance);
    }

}
