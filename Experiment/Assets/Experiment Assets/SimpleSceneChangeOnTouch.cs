using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneChangeOnTouch : MonoBehaviour
{
    private bool hasBeenPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenPressed) return;

        hasBeenPressed = true;
        Debug.Log("Szene wechseln durch Button!");

        SceneSequenceManager.Instance.LoadNextScene();
    }

    private void OnEnable()
    {
        hasBeenPressed = false; // Rücksetzen nach Szenenwechsel
    }
}
