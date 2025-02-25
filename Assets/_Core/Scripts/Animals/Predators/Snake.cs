using UnityEngine;

public class Snake : Animal
{
    [SerializeField] private float moveSpeed = 2f;

    public override void Move()
    {
        // Двигаем объект в том направлении, куда он смотрит
        rb.linearVelocity = transform.forward * moveSpeed;
        CheckBounds();
    }
}
