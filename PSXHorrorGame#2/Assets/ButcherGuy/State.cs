using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public StateManager sm;
    public abstract void RunCurrentStateStart();
    public abstract State RunCurrentState();
}
