using UnityEngine;

public class HeroController : MonoBehaviour
{
    public bool canMove;
    public bool gravityEnabled = true;
    public float moveSpeed = 0f;
    public float walkSpeed = 5f;
    public float duckSpeed = 3f;
    public float sprintSpeed = 8f;
    public float dashSpeed = 14f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    public int direction = 1;
    private int curDirection = 1;

    public CharacterController controller;
    public Vector3 velocity;

    private IHeroineState _standState, _jumpState, _duckState, _diveState, _doubleJumpState, _sprintState, _dashState;
    private HeroStateContext _heroStateContext;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        _heroStateContext = new HeroStateContext(this);

        _standState = gameObject.AddComponent<StandState>();
        _jumpState = gameObject.AddComponent<JumpState>();
        _duckState = gameObject.AddComponent<DuckState>();
        _diveState = gameObject.AddComponent<DiveState>();
        _doubleJumpState = gameObject.AddComponent<DoubleJumpState>();
        _sprintState = gameObject.AddComponent<SprintState>();
        _dashState = gameObject.AddComponent<DashState>();

        Stand();
    }

    private void Update()
    {
        if (canMove)
        {
            if (curDirection != 0)
                direction = curDirection;

            curDirection = 0;
            if (Input.GetKey(KeyCode.A))
                curDirection = -1;
            else if (Input.GetKey(KeyCode.D))
                curDirection = 1;

            

            Vector3 moveDirection = transform.right * curDirection;
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small downward force to keep grounded
        }

        if (gravityEnabled)
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        _heroStateContext.CurrentState._Update();
    }

    public void Stand()
    {
        _heroStateContext.Transition(_standState);
    }

    public void Jump()
    {
        _heroStateContext.Transition(_jumpState);
    }

    public void Duck()
    {
        _heroStateContext.Transition(_duckState);
    }

    public void DoubleJump() 
    {
        _heroStateContext.Transition(_doubleJumpState);
    }

    public void Dive()
    {
        _heroStateContext.Transition(_diveState);
    }

    public void Sprint()
    {
        _heroStateContext.Transition(_sprintState);
    }

    public void Dash()
    {
        _heroStateContext.Transition(_dashState);
    }
}
