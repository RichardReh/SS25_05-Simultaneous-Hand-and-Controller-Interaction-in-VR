using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class ColorMapping
{
    public string colorString;
    public Material colorMaterial;
}

public class PressurePlateRandomizer : MonoBehaviour
{
    public Material[] materials;
    private ColorMapping[] colors;
    private GameObject[] arrayOfCubes;

    void Start()
    {
        InitializeColorMappings();
        RandomizeAll();
    }

    public void ResetAndRandomize()
    {
        Debug.Log("PressurePlateRandomizer → Reset wird durchgeführt.");
        RandomizeAll();
    }

    private void InitializeColorMappings()
    {
        string[] colorStrings = { "Yellow", "Violet", "Teal", "Red", "Pink", "Orange", "Green", "Blue", "Black" };

        colors = new ColorMapping[materials.Length];
        for (int i = 0; i < materials.Length; i++)
        {
            colors[i] = new ColorMapping
            {
                colorMaterial = materials[i],
                colorString = colorStrings[i]
            };
        }
    }

    private void RandomizeAll()
    {
        arrayOfCubes = GameObject.FindGameObjectsWithTag("Cube");

        // Farben zufällig zuweisen
        int[] randomizedArray = Enumerable.Range(0, materials.Length).ToArray();
        for (int i = 0; i < randomizedArray.Length; i++)
        {
            int rndIndex = UnityEngine.Random.Range(i, randomizedArray.Length);
            (randomizedArray[i], randomizedArray[rndIndex]) = (randomizedArray[rndIndex], randomizedArray[i]);
        }

        for (int i = 0; i < arrayOfCubes.Length; i++)
        {
            Cube cube = arrayOfCubes[i].GetComponent<Cube>();
            cube.colorName = colors[randomizedArray[i]].colorString;

            Renderer renderer = arrayOfCubes[i].GetComponent<Renderer>();
            renderer.material = colors[randomizedArray[i]].colorMaterial;
        }

        // Positionen zufällig zuweisen
        GameObject plane = GameObject.Find("Plane");
        Bounds bounds = plane.GetComponent<Renderer>().bounds;

        float margin = 2f; // Abstand vom Rand
        float minX = bounds.min.x + margin;
        float maxX = bounds.max.x - margin;
        float minZ = bounds.min.z + margin;
        float maxZ = bounds.max.z - margin;
        float ySpawn = 0.5f;

        List<Vector3> spawnPositions = new List<Vector3>();
        int cubesNeeded = arrayOfCubes.Length;
        int tries = 0;

        while (spawnPositions.Count < cubesNeeded && tries < 1000)
        {
            tries++;
            float randX = UnityEngine.Random.Range(minX, maxX);
            float randZ = UnityEngine.Random.Range(minZ, maxZ);
            Vector3 pos = new Vector3(randX, ySpawn, randZ);

            if (Vector3.Distance(pos, bounds.center) > bounds.size.x / 4f)
            {
                spawnPositions.Add(pos);
            }
        }

        for (int i = 0; i < cubesNeeded; i++)
        {
            arrayOfCubes[i].transform.position = spawnPositions[i];
        }
    }
}
