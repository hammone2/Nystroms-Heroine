using UnityEngine;

public class StandState : MonoBehaviour, IHeroineState
{
    private HeroController _heroController;

    public void _Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_heroController.controller.isGrounded)
                _heroController.Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _heroController.Sprint();
        }

        if (Input.GetKey(KeyCode.S))
        {
            _heroController.Duck();
        }

        if (_heroController.controller.isGrounded == false)
        {
            if (_heroController.velocity.y <= 0)
            {
                if (Input.GetKeyDown(KeyCode.S))
                    _heroController.Dive();
            }
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
        _heroController.canMove = true;
        _heroController.moveSpeed = _heroController.walkSpeed;
        _heroController.gravityEnabled = true;
    }
}
