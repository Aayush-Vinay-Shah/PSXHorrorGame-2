using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectionObject : MonoBehaviour
{
    public string name;
    public UnityEvent specialEvent;
    public UnityEvent afterEvent;
    public float afterTime;

    bool isDone;

    public void DoEvent()
    {
        specialEvent.Invoke();
        isDone = true;

    }

    public void Update()
    {
        if(isDone)
        {
            afterEvent.Invoke();

        }

    }

    public void Destroy()
    {
        Destroy(gameObject, afterTime);

    }
    
}
