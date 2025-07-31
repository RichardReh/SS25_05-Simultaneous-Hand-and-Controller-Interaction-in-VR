using UnityEngine;

public class PodestButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Etwas berührt den Button: " + other.name + " | Tag: " + other.tag);

            GameObject plane = GameObject.FindGameObjectWithTag("Plane");
            Debug.Log("TRIGGERED KNOPF");
            if (plane != null)
            {
                Debug.Log("PLANE IST NICHT NULL");
                plane.GetComponent<PressurePlateRandomizer>()?.ResetAndRandomize();
                //plane.GetComponent<DeinZweitesScript>()?.ResetAndRandomize();
            }
        
    }
}
