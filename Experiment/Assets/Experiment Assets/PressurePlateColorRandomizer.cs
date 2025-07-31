using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class PressurePlateColorMapping
{
    public string colorString;
    public Material colorMaterial;
}

public class PressurePlateColorRandomizer : MonoBehaviour 
{
    public Material[] materials;

    private PressurePlateColorMapping[] colors;

    void Start()
    {
        InitializeColorMappings();
        RandomizeAll();
    }

    private void InitializeColorMappings()
    {
        string[] colorStrings = { "Yellow", "Violet", "Teal", "Red", "Pink", "Orange", "Green", "Blue", "Black" };

        // Farbenreferenzen vorbereiten
        colors = new PressurePlateColorMapping[materials.Length];
        for (int i = 0; i < materials.Length; i++)
        {
            colors[i] = new PressurePlateColorMapping();
            colors[i].colorMaterial = materials[i];
            colors[i].colorString = colorStrings[i];
        }
    }
    
    public void RandomizeAll(){
        
    // Druckplatten finden
        GameObject[] arrayOfPlates = GameObject.FindGameObjectsWithTag("PressurePlate");

        // Zufallsreihenfolge
        int[] randomizedArray = Enumerable.Range(0, 9).ToArray();
        for (int i = 0; i < randomizedArray.Length; i++)
        {
            int rndIndex = UnityEngine.Random.Range(i, randomizedArray.Length);
            int temp = randomizedArray[i];
            randomizedArray[i] = randomizedArray[rndIndex];
            randomizedArray[rndIndex] = temp;
        }

        // Farben auf die Druckplatten verteilen
        for (int i = 0; i < arrayOfPlates.Length; i++)
        {
            // Matching Color setzen
            GroundTile plateScript = arrayOfPlates[i].GetComponent<GroundTile>();
            plateScript.matchingColor = colors[randomizedArray[i]].colorString;

            // Renderer-Material setzen
            Renderer renderer = arrayOfPlates[i].GetComponent<Renderer>();
            renderer.material = colors[randomizedArray[i]].colorMaterial;
        }
    }
}
