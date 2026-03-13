using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NPC_Patrol : MonoBehaviour
{
    public Vector2[] patrolPoints;
    public float speed = 2f;
    public float pauseDuration = 1.5f;  // 暂停时长
    
    private bool isPause;
    private Vector2 target;
    private int currentPatrolIndex = 0;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        StartCoroutine(SetPatrolPoint());
    }

    void Update()
    {
        if (isPause)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        Vector2 direction = ((Vector3)target - transform.position).normalized;
        if (direction.x < 0 && transform.localScale.x > 0
            || direction.x > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        rb.velocity = direction * speed;

        if (Vector2.Distance(transform.position, target) < .1f)
        {
            StartCoroutine(SetPatrolPoint());
        }
    }

    IEnumerator SetPatrolPoint()
    {
        isPause = true;
        anim.Play("Idle");
        yield return new WaitForSeconds(pauseDuration);

        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        target = patrolPoints[currentPatrolIndex];
        isPause = false;
        anim.Play("Walk");
    }
}
