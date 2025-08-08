using System.Numerics;
using UnityEngine;

public class PodestButton : MonoBehaviour
{

    public Material InteractionMaterial;
    public GameObject InteractionGO;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Etwas berührt den Button: " + other.name + " | Tag: " + other.tag);

        GameObject plane = GameObject.FindGameObjectWithTag("Plane");
        Debug.Log("TRIGGERED KNOPF");
        if (plane != null)
        {
            Debug.Log("PLANE IST NICHT NULL");
            plane.GetComponent<PressurePlateRandomizer>()?.ResetAndRandomize();
            plane.GetComponent<PressurePlateColorRandomizer>()?.RandomizeAll();
            UICounterManager.Instance.Reset();

            // change material and give it a clicked position: 
            InteractionGO.GetComponent<MeshRenderer>().material = InteractionMaterial;
            UnityEngine.Vector3 pos = InteractionGO.transform.position;
            pos.y = 0.07f;
            InteractionGO.transform.position = pos; 
            
            LogWriter.Instance.WriteToLog("PodestButton: Startbutton wurde gedruckt");
        }

    }
}
