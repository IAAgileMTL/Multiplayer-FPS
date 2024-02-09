using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamingState : ZombieState
{
    public override bool CanEnter(IState currentState)
    {
        return true;
    }

    public override bool CanExit()
    {
        return true;
    }

    public override void OnEnter()
    {
        Debug.Log("Entering Roaming State");
    }

    public override void OnExit()
    {
        Debug.Log("Exiting Roaming State");
    }

    public override void OnFixedUpdate()
    {
        //Debug.Log("Roaming State OnFixedUpdate");
    }

    public override void OnStart()
    {
        Debug.Log("Roaming State OnStart");
    }

    public override void OnUpdate()
    {
        //Debug.Log("Roaming State OnUpdate");
    }
}
