using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float x, y;
    public float Speed, jumpForce, raycastLength;
    bool jumped = false;

    public LayerMask ground;
    int maxCoins, coins = 0;
    Defaults defs;
    Vector3 startPos;
    public GameManager gameManager;
    public AudioSource[] clips;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defs = GetComponent<Defaults>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastLength, ground);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + new Vector3(transform.localScale.x / 2 - 0.01f, 0, 0), Vector2.down, raycastLength, ground);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position - new Vector3(transform.localScale.x / 2 - 0.1f, 0, 0), Vector2.down, raycastLength, ground);
        if((hit.collider != null || hitLeft.collider != null || hitRight.collider != null) && Input.GetKeyDown(KeyCode.Space))
        {
            jumped = true;
            clips[1].Play();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.Pause();
        }
    }

    void FixedUpdate()
    {
        Vector2 move = new Vector2(x, 0) * Speed * Time.deltaTime;
        if(jumped)
        {
            rb.velocity = transform.up * jumpForce;
            jumped = false;
        }
        transform.position = (Vector2)transform.position + move;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Finish_Line")
        {
            WonOrNot();
        }
        else if(collision.gameObject.tag == "spikes")
        {
            lost();
        }
        else if(collision.gameObject.layer == 10)
        {
            rb.velocity += new Vector2(0, jumpForce);
            clips[2].Play();
        }
        else if(collision.gameObject.tag == "LastFinish")
        {
            gameManager.SetScene(0);
        }
    }

    public void PickedUpACoin()
    {
        coins++;
        clips[0].Play();
    }

    public void AmountOfCoins(int amount)
    {
        maxCoins = amount;
    }
    void lost()
    {
        defs.ResetToDefaults();     
        transform.position = startPos;
        coins = 0;
        clips[3].Play();
    }

    void WonOrNot()
    {
        if(maxCoins - coins == 1)
        {
            gameManager.NextScene();
        }
        else
        {
            lost();
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - raycastLength, transform.position.z));
    }
}
