using UnityEngine;
using TMPro;

public class UICounterManager : MonoBehaviour
{
    public static UICounterManager Instance;

    public TMP_Text counterText; // UI-Text im Inspector zuweisen
    private int currentCount = 0;
    private int totalCount = 9;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Increment()
    {
        currentCount++;
        UpdateText();
    }

    public void Decrement()
    {
        currentCount--;
        UpdateText();
    }

    public void Reset()
    {
        currentCount = 0;
    }

    private void UpdateText()
    {
        counterText.text = currentCount + " / " + totalCount;
        Debug.Log("EXP: Count" + counterText.text);
        LogWriter.Instance.WriteToLog("UICounterManager: Punktestand - " + counterText.text);
    }

}
