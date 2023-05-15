using UnityEngine;

public enum PlayerOrientation
{
    None,
    Idle,
    Up,
    Down,
    Left,
    Right
}

public class CharacterMover
{

    private IMovementInput movementInput;
    private float moveSpeed;

    public CharacterMover(IMovementInput input, float speed)
    {
        movementInput = input;
        moveSpeed = speed;
    }

    public void Move(Rigidbody2D rb, float deltaTime)
    {
        Vector2 input = movementInput.GetInput();
        Vector2 newPosition = rb.position + input * moveSpeed * deltaTime;
        rb.MovePosition(newPosition);
    }
}
