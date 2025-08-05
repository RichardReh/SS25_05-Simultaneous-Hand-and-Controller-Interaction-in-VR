using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneChangeOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Etwas berührt den Button: " + other.name + " | Tag: " + other.tag);

        
        
            Debug.Log("RICHTIGER HAND/CONTROLLER → Szene wechseln!");
            SceneSequenceManager.Instance.LoadNextScene();
        
    }
}
