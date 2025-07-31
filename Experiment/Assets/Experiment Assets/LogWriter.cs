using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogWriter : MonoBehaviour
{
    public static LogWriter Instance { get; private set; }
    private string logFilePath;

    void Awake()
    {
        // verhindert das dieses Objekt mehrfach existiert
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        // stellt sicher, dass diese Objekt in jeder Szene ist
        DontDestroyOnLoad(this.gameObject);

        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        logFilePath = Path.Combine(Application.persistentDataPath, timestamp + "_log.txt");
        Debug.Log("Speicherpfad für Logs: " + Application.persistentDataPath);

        WriteToLog("Anwendung hat gestartet");
    }

    public void WriteToLog(string message)
    {
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string logEntry = $"{timestamp} - {message}";

        try
        {
            File.AppendAllText(logFilePath, logEntry + "\n");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Fehler beim Schreiben der Logdatei: " + ex.Message);
        }
    }
}