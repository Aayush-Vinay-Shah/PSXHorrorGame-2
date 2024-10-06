using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currentState;
    public Animator anim;
    public UnityEngine.AI.NavMeshAgent agent;
    public State[] states;

    void Start()
    {
        currentState.RunCurrentStateStart();

    }

    // Update is called once per frame
    void Update()
    {
        RunStateMachine();
        
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();
        if(nextState != null)
        {
            SwitchToNextState(nextState);


        }

    }

    private void SwitchToNextState(State nextState)
    {
        currentState = nextState;
        currentState.RunCurrentStateStart();

    }


}
