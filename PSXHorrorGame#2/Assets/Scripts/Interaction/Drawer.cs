using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public bool open;
    public Animator anim;
    public void Update()
    {
        anim.SetBool("Open", open);

    }
    public void Open()
    {
        open = !open;

    }
}
