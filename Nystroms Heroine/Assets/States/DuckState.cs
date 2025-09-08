using UnityEngine;

public class DuckState : MonoBehaviour, IHeroineState
{
    private HeroController _heroController;

    public void _Update() 
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            _heroController.Stand();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _heroController.Sprint();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_heroController.controller.isGrounded)
                _heroController.Jump();
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
        _heroController.moveSpeed = _heroController.duckSpeed;
        _heroController.canMove = true;
        _heroController.gravityEnabled = true;
    }
}
