using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneSequenceManager : MonoBehaviour
{
    public static SceneSequenceManager Instance;

    private List<string> sceneOrder;
    private int currentIndex = 0;

    private void Start()
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
        // erste Szene laden
        SceneSequenceManager.Instance.LoadNextScene();
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
            LogWriter.Instance.WriteToLog("SceneManager: Szenenwechsel - " + nextScene);
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.Log("Alle Szenen wurden gespielt!");
            LogWriter.Instance.WriteToLog("SceneManager: Alle Szenen wurden gespielt");
        }
    }
}
