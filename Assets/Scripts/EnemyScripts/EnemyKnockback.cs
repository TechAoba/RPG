using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyMovement = GetComponent<EnemyMovement>();
    }
    public void Knockback(Transform forceTransform, float knockbackForce, float knockbackTime, float stunTime)
    {
        // 创建计时协程
        enemyMovement.ChangeState(EnemyState.Knockback);
        StartCoroutine(StunTimer(knockbackTime, stunTime));

        Vector2 direction = (transform.position - forceTransform.position).normalized;
        rb.velocity = direction * knockbackForce;
    }

    IEnumerator StunTimer(float knockbackTime, float stunTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        enemyMovement.ChangeState(EnemyState.Idle);
    }
}
