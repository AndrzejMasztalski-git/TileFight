using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveHorizontal, moveVertical;
    [SerializeField] private float moveSpeed = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;
        moveVertical = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(moveHorizontal, moveVertical); //OPTIONAL rb.MovePosition();

        Vector2 direction = new Vector2(moveHorizontal, moveVertical);
        FindObjectOfType<PlayerAnimation>().SetDirection(direction);
    }
}
