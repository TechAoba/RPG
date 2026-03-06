using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int facingDirection = 1;
    public Rigidbody2D rb;
    public Animator anim;
    public PlayerCombat playerCombat;

    private bool isKnockBack = false;

    private void Update()
    {
        if (Input.GetButtonDown("Slash") && playerCombat.enabled == true)
        {
            playerCombat.Attack();
        }
    }

    // FixedUpdate is called 50x frame
    void FixedUpdate()
    {
        if (isKnockBack == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal > 0 &&transform.localScale.x < 0 || 
                horizontal < 0 &&transform.localScale.x > 0)
            {
                Flip();
            }

            anim.SetFloat("horizontal", Mathf.Abs(horizontal));
            anim.SetFloat("vertical", Mathf.Abs(vertical));

            rb.velocity = new Vector2(horizontal, vertical) * StatsManager.Instance.speed;
        }
        
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Knockback(Transform enemy, float force, float stunTime)
    {
        isKnockBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.velocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.velocity = Vector2.zero;
        isKnockBack = false;
    }
}
