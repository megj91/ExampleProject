using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    private CharacterMover characterMover;
    private IMovementInput playerInput;


    private void Start()
    {
        playerInput = new PlayerInput();
        characterMover = new CharacterMover(playerInput, moveSpeed);
    }

    private void FixedUpdate()
    {
        characterMover.Move(rb, Time.fixedDeltaTime);
    }

    private void Update()
    {
        if(GetComponent<PlayerAnimationsHandler>())
        {
            GetComponent<PlayerAnimationsHandler>().ChangeAnimationStatus(playerInput.GetOrientation());
        }
    }

}
