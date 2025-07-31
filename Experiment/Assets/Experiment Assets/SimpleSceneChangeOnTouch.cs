using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneChangeOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Etwas berührt den Button: " + other.name + " | Tag: " + other.tag);

        if (other.CompareTag("RightHand") || other.CompareTag("RightController"))
        {
            Debug.Log("RICHTIGER HAND/CONTROLLER → Szene wechseln!");
            SceneSequenceManager.Instance.LoadNextScene();
        }
    }
}
