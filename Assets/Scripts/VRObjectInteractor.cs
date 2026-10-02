using UnityEngine;

public class VRObjectInteractor : MonoBehaviour
{
    [SerializeField] private OVRCameraRig cameraRig;
    [SerializeField] private float rayDistance = 10f;

    private void Update()
    {
        // Use the right controller.
        Transform controller = cameraRig.rightControllerAnchor;

        // Start the ray at the controller.
        Vector3 origin = controller.position;

        // Shoot the ray in the direction the controller is pointing.
        Vector3 direction = controller.forward;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, rayDistance))
        {
            Debug.DrawRay(origin, direction * hit.distance);

            // Press the right controller's trigger.
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                Debug.Log("Interacted with: " + hit.collider.gameObject.name);

                // Example interaction:
                hit.collider.gameObject.GetComponent<VRInteractable>()?.Interact();
            }
        }
    }
}