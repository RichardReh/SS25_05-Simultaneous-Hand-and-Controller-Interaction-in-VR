using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VRButton : MonoBehaviour
{

    public void LoadHandControllScene()
    {
        Debug.Log("EXP: loadingHandControllScene");
        // SceneManager.LoadScene();
    }

    public void LoadControllerScene()
    {
        Debug.Log("EXP: loadingHandControllScene");
        SceneManager.LoadScene("Controller", LoadSceneMode.Single);
    }

    public void LoadHybridScene()
    {
        Debug.Log("EXP: loadingHandControllScene");
        // SceneManager.LoadScene();
    }

    public void onPressStartButton()
    {
        Debug.Log("EXP: pressedStartButton");
    }
}
