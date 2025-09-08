using UnityEngine;

public class JumpState : MonoBehaviour, IHeroineState
{
    private HeroController _heroController;

    public void _Update()
    {
        if (_heroController.controller.isGrounded)
            _heroController.Stand();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _heroController.DoubleJump();
        }

        if (_heroController.velocity.y <= 0)
        {
            if (Input.GetKeyDown(KeyCode.S))
                _heroController.Dive();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _heroController.Dash();
        }
    }

    public void Handle(HeroController heroController)
    {
        if (!_heroController)
            _heroController = heroController;
        _heroController.velocity.y = Mathf.Sqrt(_heroController.jumpHeight * -2f * _heroController.gravity);
        _heroController.moveSpeed = _heroController.walkSpeed;
        _heroController.canMove = true;
        _heroController.gravityEnabled = true;
    }
}
