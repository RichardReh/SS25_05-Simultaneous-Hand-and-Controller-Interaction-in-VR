using System.Numerics;
using UnityEngine;

public class PodestButton : MonoBehaviour
{

    public Material InteractionMaterial;
    public GameObject InteractionGO;
    private bool pressedFlag;
    private void Start()
    {
        pressedFlag = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (pressedFlag)
        {

            pressedFlag = false;

            Debug.Log("Etwas berührt den Button: " + other.name + " | Tag: " + other.tag);

            GameObject plane = GameObject.FindGameObjectWithTag("Plane");
            Debug.Log("TRIGGERED KNOPF");
            if (plane != null)
            {
                Debug.Log("PLANE IST NICHT NULL");
                plane.GetComponent<PressurePlateRandomizer>()?.ResetAndRandomize();
                plane.GetComponent<PressurePlateColorRandomizer>()?.RandomizeAll();
                UICounterManager.Instance.Reset();

                try
                {
                    // change material and give it a clicked position: 
                    InteractionGO.GetComponent<MeshRenderer>().material = InteractionMaterial;
                    UnityEngine.Vector3 pos = InteractionGO.transform.localPosition;
                    pos.z = 0.04f;
                    InteractionGO.transform.localPosition = pos;

                    LogWriter.Instance.WriteToLog("PodestButton: Startbutton wurde gedruckt");
                } catch {
                    Debug.Log("Nichts passiert, FEHLER");
                }
            }
        }
    }
}
