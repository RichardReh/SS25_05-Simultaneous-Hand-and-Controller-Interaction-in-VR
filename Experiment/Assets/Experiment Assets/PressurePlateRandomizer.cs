using System;
using Unity.Android.Gradle;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class ColorMapping
{
    public string colorString;
    public Material colorMaterial;
}

public class PressurePlateRandomizer : MonoBehaviour
{

    public Material[] materials;
    private Renderer _renderer;
    private Material _material;
    private GameObject[] arrayofcubes;
    private ColorMapping[] colors;


    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
        arrayofcubes = GameObject.FindGameObjectsWithTag("Cube");

        string[] colorStrings = { "Yellow", "Violet", "Teal", "Red", "Pink", "Orange", "Green", "Blue", "Black" };


        //Farbenreferenzen in Map speichern:
        colors = new ColorMapping[materials.Length];
        for (int i = 0; i < materials.Length; i++)
        {
            colors[i] = new ColorMapping();
            colors[i].colorMaterial = materials[i];
            colors[i].colorString = colorStrings[i];
        }

        //Verteilung von zufälligen Farben an die Würfel:
        int[] randomizedArray = Enumerable.Range(0, 9).ToArray();

        // Fisher-Yates-Shuffle
        for (int i = 0; i < randomizedArray.Length; i++)
        {
            int rndIndex = UnityEngine.Random.Range(i, randomizedArray.Length);

            // Tauschen
            int temp = randomizedArray[i];
            randomizedArray[i] = randomizedArray[rndIndex];
            randomizedArray[rndIndex] = temp;
        }

        int cubeCount = arrayofcubes.Length;
        for (int i = 0; i <= cubeCount-1; i++)
        {
            Cube cube = arrayofcubes[i].GetComponent<Cube>();
            cube.colorName = colors[randomizedArray[i]].colorString;

            Renderer renderer = cube.GetComponent<Renderer>();
            renderer.material = colors[randomizedArray[i]].colorMaterial;
        }

        //Zum Randomisieren der Positionen

        GameObject plane = GameObject.Find("Plane");
        Bounds bounds = plane.GetComponent<Renderer>().bounds;

        float minX = bounds.min.x;
        float maxX = bounds.max.x-0.5f;
        float minZ = bounds.min.z;
        float maxZ = bounds.max.z-0.5f;

        List<Vector3> spawnPositions = new List<Vector3>();
        float ySpawn = 0.5f;
        int cubesNeeded = arrayofcubes.Length;
        int tries = 0;

        while (spawnPositions.Count < cubesNeeded && tries < 1000)
        {
            tries++;

            float randX = UnityEngine.Random.Range(minX, maxX);
            float randZ = UnityEngine.Random.Range(minZ, maxZ);
            Vector3 pos = new Vector3(randX, ySpawn, randZ);

            // Abstand zum Zentrum prüfen
            if (Vector3.Distance(pos, bounds.center) > bounds.size.x / 4f)
            {
                spawnPositions.Add(pos);
            }
        }

        for (int i = 0; i < cubesNeeded; i++)
        {
            arrayofcubes[i].transform.position = spawnPositions[i];
        }

    }
}
