using UnityEngine;

public class PhysicsDebugger : MonoBehaviour
{
    void Update()
    {
        Debug.Log($"Gravity: {Physics.gravity}, AutoSimulation: {Physics.autoSimulation}, SimulationMode: {Physics.simulationMode}, TimeScale: {Time.timeScale}");
    }
}