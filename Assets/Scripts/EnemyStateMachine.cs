using System.Collections;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float chaseSpeed = 3f;
    public float chaseDistance = 2f;
    public float attackDistance = 1f;
    private Vector2 randomDirection;
    private float directionChangeInterval = 5f;
    private Transform playerTransform;
    private Rigidbody2D rb;
    private float timer;
    public Player player;
    private enum State { Wandering, Chasing, Attacking }
    private State state;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeDirection());
        state = State.Wandering;
    }

    void Update()
    {
        switch (state)
        {
            case State.Wandering:
                Wander();
                CheckForChase();
                break;
            case State.Chasing:
                Chase();
                CheckForAttack();
                break;
            case State.Attacking:
                Attack();
                break;
        }
    }

    void Wander()
    {
        rb.velocity = randomDirection * moveSpeed;
        timer += Time.deltaTime;
        if (timer >= directionChangeInterval)
        {
            timer = 0f;
            ChangeDirectionNow();
        }
    }

    void Chase()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        rb.velocity = direction * chaseSpeed;
    }

    void Attack()
    {
        
    }

    void CheckForChase()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
        {
            state = State.Chasing;
        }
    }

    void CheckForAttack()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) < attackDistance)
        {
            state = State.Attacking;
        }
        else if (Vector2.Distance(transform.position, playerTransform.position) > chaseDistance)
        {
            state = State.Wandering;
        }
    }

    IEnumerator ChangeDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(directionChangeInterval);
            ChangeDirectionNow();
        }
    }

    void ChangeDirectionNow()
    {
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (state == State.Wandering || state == State.Chasing)
        {
            ChangeDirectionNow();
        }
    }
}