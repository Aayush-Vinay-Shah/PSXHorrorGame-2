using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State
{

    public override void RunCurrentStateStart()
    {

    }

    public override State RunCurrentState()
    {
        return this; 

    }
}
