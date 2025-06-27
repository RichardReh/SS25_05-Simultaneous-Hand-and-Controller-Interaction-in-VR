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

    private void UpdateText()
    {
        counterText.text = currentCount + " / " + totalCount;
        Debug.Log("EXP: Count" + counterText.text);
    }

}
