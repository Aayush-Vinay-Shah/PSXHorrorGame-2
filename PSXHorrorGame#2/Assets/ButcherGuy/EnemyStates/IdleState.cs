using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public WanderState wanderState;
    public float waitSeconds;
    public float time;
    bool isChange;

    public override void RunCurrentStateStart()
    {
        waitSeconds += Time.time;
        time = waitSeconds;
        return;

    }

    public override State RunCurrentState()
    {
        if(Time.time > time)
        {
            return wanderState;
        }
        else
        {
            return this;

        }
        
    }
    


}
