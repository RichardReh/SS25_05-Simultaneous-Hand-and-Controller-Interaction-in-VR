using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneSequenceManager : MonoBehaviour
{
    public static SceneSequenceManager Instance;

    private List<string> sceneOrder;
    private int currentIndex = 0;

    private void Awake()
    {
        // Singleton behalten, wenn Szene gewechselt wird
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CreateRandomOrder();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CreateRandomOrder()
    {
        sceneOrder = new List<string> { "Hybrid", "Controller"};

        // Fisher-Yates Shuffle
        for (int i = 0; i < sceneOrder.Count; i++)
        {
            int rnd = Random.Range(i, sceneOrder.Count);
            string temp = sceneOrder[i];
            sceneOrder[i] = sceneOrder[rnd];
            sceneOrder[rnd] = temp;
        }
    }

    public void LoadNextScene()
    {
        if (currentIndex < sceneOrder.Count)
        {
            string nextScene = sceneOrder[currentIndex];
            currentIndex++;
            Debug.Log("WECHSLE SZENE !!!");
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.Log("Alle Szenen wurden gespielt!");
        }
    }
}
