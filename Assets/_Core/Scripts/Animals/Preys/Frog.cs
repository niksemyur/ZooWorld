using UnityEngine;

public class Frog : Animal
{
    [SerializeField] private float jumpForceUp = 3f;  
    [SerializeField] private float jumpForceForward = 3f;  
    [SerializeField] private float jumpInterval = 1f; 

    private float timeSinceLastJump = 0f;  // Time elapsed since the last jump

    public override void Move()
    {
        timeSinceLastJump += Time.deltaTime;

        if (timeSinceLastJump >= jumpInterval)
        {
            CheckBounds();
            Jump();
            timeSinceLastJump = 0f; // Reset the timer after the jump
        }
    }

    private void Jump()
    {    
        rb.AddForce(transform.up * jumpForceUp, ForceMode.Impulse);
        rb.AddForce(transform.forward * jumpForceForward, ForceMode.Impulse);
        animator.Play("Jump");
    }
}
