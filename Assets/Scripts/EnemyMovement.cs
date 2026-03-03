using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 2;
    private bool isChasing = false;
    private Rigidbody2D rb;
    private Transform player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {   
            if (player == null)
            {
                player = collision.transform;
            }
            isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isChasing = false;
            rb.velocity = Vector2.zero;
        }
    }
}
