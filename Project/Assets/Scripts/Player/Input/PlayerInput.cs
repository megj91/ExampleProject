using UnityEngine;

public class PlayerInput : IMovementInput
{
    public Vector2 GetInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        return new Vector2(horizontal, vertical).normalized;
    }

    public PlayerOrientation GetOrientation()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == 0 && vertical == 0)
        {
            return PlayerOrientation.Idle;
        }
        else if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
        {
            return horizontal > 0 ? PlayerOrientation.Right : PlayerOrientation.Left;
        }
        else
        {
            return vertical > 0 ? PlayerOrientation.Up : PlayerOrientation.Down;
        }
    }

}
