using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    [Header("CamShake")]
    public Camera playerCamera;
    public float duration;
    public float magnitude;
    public float interactionDistance;

    [Header("Weapon")]
    Animator anim;
    public KeyCode weaponKey;
    public bool isHoldingWeapon;
    public bool isAttacking;

    public Interactable[] interactables;
    Interactable current;

    public void Start()
    {
        anim = GetComponent<Animator>();

    }

    public void Update()
    {
        if(Input.GetKeyDown(weaponKey) && !isAttacking && isHoldingWeapon && current.isWeapon)
        {
            isAttacking = true;

        }

        if(Input.GetKeyDown(KeyCode.Q) && isHoldingWeapon)
        {
            anim.Play("Throw", 2, 0);

        }
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("isHoldingWeapon", isHoldingWeapon);

    }

    public void CamShakeTriggerEvent()
    {
        StartCoroutine(GameObject.FindObjectOfType<CameraShake>().Shake(duration, magnitude));

    }

    public void TurnOffAttack()
    {
        isAttacking = false;
    }

    public void CheckInventory(InteractableObjeect interactable)
    {
        if(isHoldingWeapon)
            return;

        foreach(Interactable i in interactables)
        {
            if(i.name == interactable.name)
            {
                i.gameObject.SetActive(true);
                current = i;
                isHoldingWeapon = true;

            }

        }

    }

    public void Throw()
    {
        GameObject thrownObject = Instantiate(current.weaponPrefab, current.transform.position, current.transform.rotation);
        Vector3 throwDirection = transform.forward * current.force;
        thrownObject.GetComponent<Rigidbody>().AddForce(transform.forward * current.force, ForceMode.Impulse);
        if(current.isSpin)
        {
            Vector3 localSpinAxis = current.spinDir; // Spin around the ball's up axis (Y-axis).
            float spinForce = current.spinForce; // Adjust this value to control the spin force.

            // Convert localSpinAxis to world space and apply torque.
            Vector3 worldSpinAxis = transform.TransformDirection(localSpinAxis);
            Vector3 spinAxis = Vector3.Cross(throwDirection.normalized, Vector3.up);
            thrownObject.GetComponent<Rigidbody>().AddTorque(-current.transform.up * spinForce,ForceMode.Force);

        }
        isAttacking = false;
        isHoldingWeapon = false;
        current.gameObject.SetActive(false);
        current = null;

    }

    public void RaycastInteractionForDetection()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the raycast hits something within the interaction distance
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            DetectionObject detectedObject = hit.collider.GetComponent<DetectionObject>();
            if(detectedObject == null)
                return;

            if(current.name == detectedObject.name)
            {
                detectedObject.DoEvent();

            }

            
        }
    }
}
