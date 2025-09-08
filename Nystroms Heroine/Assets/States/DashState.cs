using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class DashState : MonoBehaviour, IHeroineState
{
    private HeroController _heroController;

    public void _Update() 
    {
        Vector3 moveDirection = transform.right * _heroController.direction;
        _heroController.controller.Move(moveDirection * _heroController.dashSpeed * Time.deltaTime);
    }

    public void Handle(HeroController heroController)
    {
        if (!_heroController)
            _heroController = heroController;
        _heroController.canMove = false;
        _heroController.gravityEnabled = false;
        StartCoroutine(Dash());
    }

    IEnumerator Dash()
    {
        
        yield return new WaitForSeconds(0.5f);

        _heroController.Stand();
    }
}
