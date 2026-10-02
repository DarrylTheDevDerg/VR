using UnityEngine;

public class VRObjectInteractor : MonoBehaviour
{
    [SerializeField] private OVRHand hand;
    [SerializeField] private float rayDistance = 10f;

    private void Update()
    {
        // Use the right controller.
        Transform pointer = hand.PointerPose;

        // Start the ray at the controller.
        Vector3 origin = pointer.position;

        // Shoot the ray in the direction the controller is pointing.
        Vector3 direction = pointer.forward;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, rayDistance))
        {
            Debug.DrawRay(origin, direction * hit.distance);

            // Press the right controller's trigger.
            if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
            {
                Debug.Log("Interacted with: " + hit.collider.gameObject.name);

                // Example interaction:
                hit.collider.gameObject.GetComponent<VRInteractable>()?.Interact();
            }
        }
    }
}