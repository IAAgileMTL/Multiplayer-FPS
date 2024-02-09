using UnityEngine;

public class ChasingState : ZombieState
{
    public override bool CanEnter(IState currentState)
    {
        return m_stateMachine.m_isPreyInSight;
    }

    public override bool CanExit()
    {
        return !m_stateMachine.m_isPreyInSight;
    }

    public override void OnEnter()
    {
        Debug.Log("Entering Chasing State");
    }

    public override void OnExit()
    {
        Debug.Log("Exiting Chasing State");
    }

    public override void OnFixedUpdate()
    {
        Debug.Log("Chasing State OnFixedUpdate");
        if (m_stateMachine.RB == null) Debug.Log("RB is null");
        if (m_stateMachine.m_preyPosition == null) Debug.Log("Prey position is null");

        var direction = m_stateMachine.m_preyPosition - m_stateMachine.RB.transform.position;
        // Rotate horizontally towards the prey
        var rotation = Quaternion.LookRotation(direction);
        Quaternion horizintalRotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
        m_stateMachine.RB.transform.rotation = Quaternion.Slerp(m_stateMachine.RB.transform.rotation, horizintalRotation, Time.deltaTime * 2.0f);

        // Advance towards the prey
        var vectorOnFloor = new Vector3(direction.x, 0, direction.z);
        m_stateMachine.RB.AddForce(vectorOnFloor * 100f, ForceMode.Acceleration);
    }

    public override void OnStart()
    {
        Debug.Log("Chasing State OnStart");
    }

    public override void OnUpdate()
    {
        Debug.Log("Chasing State OnUpdate");
    }
}
