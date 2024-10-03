using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f;
    public Camera playerCamera; // Assign the camera to cast the ray from

    private Vector3 rayOrigin;
    private Vector3 rayDirection;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastInteraction();
        }
    }

    void RaycastInteraction()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        rayOrigin = ray.origin;
        rayDirection = ray.direction;
        RaycastHit hit;

        // Check if the raycast hits something within the interaction distance
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // Try to get the InteractableObject component on the hit object
            InteractableObjeect interactable = hit.collider.GetComponent<InteractableObjeect>();

            if (interactable != null)
            {
                GetComponent<Hands>().CheckInventory(interactable);
                Debug.Log(interactable.name);
                Destroy(interactable.gameObject);
                return;
            }

            Drawer drawer = hit.collider.GetComponent<Drawer>();

            if (drawer != null)
            {
                drawer.Open();
                return;
            }

            Door door = hit.collider.GetComponent<Door>();
            if(door != null)
            {
                door.Open();
                return;

            }
        }
    }
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.green;
        Gizmos.DrawRay(rayOrigin, rayDirection * interactionDistance);

    }
}
