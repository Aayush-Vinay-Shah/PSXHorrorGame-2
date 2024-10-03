using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 rot;
    public KeyCode interactKey;
    public bool isOpened;

    Quaternion startRotation;
    public void Start()
    {
        startRotation = transform.rotation;
    }
    
    public void Open()
    {
        if(Input.GetKeyDown(interactKey))
        {
            if(!isOpened)
            {
                Vector3 newRot = rot;
                transform.rotation = Quaternion.Euler(newRot);
                isOpened = true;

            }
            else if(isOpened)
            {
                transform.rotation = startRotation;
                isOpened = false;

            }

        }

    }
    
}
