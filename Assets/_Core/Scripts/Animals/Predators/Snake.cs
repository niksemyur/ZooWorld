using UnityEngine;

public class Snake : Animal
{
    [SerializeField] private float moveSpeed = 2f;

    public override void Move()
    {
        rb.linearVelocity = transform.forward * moveSpeed;
        CheckBounds();
    }
}
