using UnityEngine;

public class DiveState : MonoBehaviour, IHeroineState
{
    private HeroController _heroController;

    public void _Update() 
    {
        _heroController.velocity.y = -20f;
        _heroController.controller.Move(_heroController.velocity * Time.deltaTime);

        if (_heroController.controller.isGrounded)
            _heroController.Stand();
    }

    public void Handle(HeroController heroController)
    {
        if (!_heroController)
            _heroController = heroController;
        _heroController.canMove = false;
        _heroController.gravityEnabled = false;
    }
}
