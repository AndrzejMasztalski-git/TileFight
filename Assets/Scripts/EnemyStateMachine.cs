using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Move,
        Run,
        Attack,
    }

    public EnemyState currentState;
    public float moveSpeed = 2.0f;
    public float runSpeed = 5.0f;
    public float attackRange = 2.0f;
    public float detectionRange = 10.0f;
    public float playerProximityDistance = 2.0f; // Minimalna odleg³oœæ od gracza, aby rozpocz¹æ ruch
    public Rigidbody2D rb;
    private Vector3 targetPosition;
    private Transform player;

    void Start()
    {
        currentState = EnemyState.Idle;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                if (ShouldStartMoving())
                {
                    ChangeState(EnemyState.Move);
                }
                break;

            case EnemyState.Move:
                if (PlayerInRange())
                {
                   
                        MoveTowardsPlayer();
                   
                }
                else
                {
                    MoveTowardsRandomTarget();
                }
                break;

            case EnemyState.Run:
                // Analogicznie do poprzedniej wersji kodu
                break;

            case EnemyState.Attack:
                // Analogicznie do poprzedniej wersji kodu
                break;
        }
    }

    bool ShouldStartMoving()
    {
        return Random.Range(0, 100) < 5;
    }

    void MoveTowardsRandomTarget()
    {
        Vector2 randomTarget = GetRandomTarget();
        Vector2 direction = (randomTarget - (Vector2)transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    Vector2 GetRandomTarget()
    {
        float randomX = Random.Range(-10f, 10f);
        float randomY = Random.Range(-10f, 10f);
        return new Vector2(randomX, randomY);
    }

    bool ReachedTarget()
    {
        float distance = Vector3.Distance(transform.position, targetPosition);
        return distance < 0.1f;
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * runSpeed * Time.deltaTime;
    }

    bool PlayerInRange()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        return distance < detectionRange;
    }

    bool PlayerInProximity()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        return distance <= playerProximityDistance;
    }

    void ChangeState(EnemyState newState)
    {
        currentState = newState;
        if (newState == EnemyState.Move)
        {
            SetNewRandomTarget();
        }
    }

    void SetNewRandomTarget()
    {
        float randomX = Random.Range(-10f, 10f);
        float randomY = Random.Range(-10f, 10f);
        targetPosition = new Vector3(randomX, randomY, 0);
    }
}