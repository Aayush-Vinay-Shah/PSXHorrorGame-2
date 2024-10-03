using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour
{
    [Header("Basics")]
    public string name;
    public bool isWeapon;
    public bool isSpin;
    public Vector3 spinDir;
    public float spinForce;
    public float force;
    public GameObject weaponPrefab;

    [Header("SpecialInteraction")]
    public bool isEvent;
    public UnityEvent specialEvent;

    public void DoEvent()
    {
        specialEvent.Invoke();

    }
}