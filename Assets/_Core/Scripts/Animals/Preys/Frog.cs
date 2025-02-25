using UnityEngine;

public class Frog : Animal
{
    [SerializeField] private float jumpForceUp = 3f;  // Сила прыжка
    [SerializeField] private float jumpForceForward = 3f;  // Сила прыжка
    [SerializeField] private float jumpInterval = 1f;  // Интервал между прыжками (в секундах)

    private float timeSinceLastJump = 0f;  // Время, прошедшее с последнего прыжка

    public override void Move()
    {
        timeSinceLastJump += Time.deltaTime;

        if (timeSinceLastJump >= jumpInterval)
        {
            CheckBounds();
            Jump();
            timeSinceLastJump = 0f;  // Сбрасываем таймер после прыжка
        }
    }

    private void Jump()
    {
        // Лягушка прыгает в том направлении, куда она смотрит
        rb.AddForce(transform.up * jumpForceUp, ForceMode.Impulse);
        rb.AddForce(transform.forward * jumpForceForward, ForceMode.Impulse);
        animator.Play("Jump");
    }
}
