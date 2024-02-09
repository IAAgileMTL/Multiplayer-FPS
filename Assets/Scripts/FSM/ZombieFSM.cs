using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ZombieFSM : AbstractFSM<ZombieState>
{
    public Rigidbody RB { get; set; }
    public bool m_isPreyInSight = false;
    public Vector3 m_preyPosition = Vector3.zero;

    protected override void Start()
    {
        RB = GetComponent<Rigidbody>();
        foreach (ZombieState state in m_possibleStates)
        {
            state.OnStart(this);
        }
 
        base.Start();
        m_currentState = m_possibleStates[0];
        m_currentState.OnEnter();
    }

    private void OnTriggerStay(Collider other)
    {
        FirstPersonController go = other.GetComponentInParent<FirstPersonController>();
        if (go == null) return;

        //Debug.Log("OnTriggerEnter: " + go.name);
        m_isPreyInSight = true;
        m_preyPosition = go.transform.position;
    }

    protected override void CreatePossibleStates()
    {
        m_possibleStates = new List<ZombieState>();
        m_possibleStates.Add(new RoamingState());
        m_possibleStates.Add(new ChasingState());
    }
}
