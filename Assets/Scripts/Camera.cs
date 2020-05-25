using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public float smoothing = 0.125f;
    void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    void LateUpdate()
    {
        Vector2 direction = player.position - transform.position;
        GetComponent<Rigidbody2D>().position = (Vector2)transform.position + direction * smoothing;
    }
}
