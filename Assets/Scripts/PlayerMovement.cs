using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2.5f;
    public float runSpeed = 5f;
    public float timeToRun = 1f;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private float moveHoldTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir != Vector2.zero)
        {
            moveHoldTime += Time.deltaTime;
        }
        else
        {
            moveHoldTime = 0f;
        }
    }

    void FixedUpdate()
    {
        float currentSpeed = moveHoldTime >= timeToRun ? runSpeed : walkSpeed;
        rb.linearVelocity = moveDir * currentSpeed;
    }
}