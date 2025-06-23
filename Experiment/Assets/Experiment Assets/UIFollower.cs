using UnityEngine;

public class UIFollower : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector3 offset = new Vector3(0, -0.2f, 1.5f);

    void Update()
    {
        if (cameraTransform == null)
            return;

        // Positionieren
        transform.position = cameraTransform.position + cameraTransform.forward * offset.z +
                             cameraTransform.up * offset.y + cameraTransform.right * offset.x;

        // Zur Kamera drehen
        transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
    }
}
