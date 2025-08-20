using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System;
using UnityEngine.InputSystem;

public class GroundTile : MonoBehaviour
{
    private Renderer _renderer;
    private Color _originalColor;

    public string matchingColor;

    private static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");

    // Der aktuell korrekt passende Würfel, der auf dieser Platte liegt (oder null)
    private GameObject _currentMatchingCube = null;

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        CacheMaterial();
    }

    /// Nach Materialwechsel (durch Randomizer) aufrufen:
    public void CacheMaterial()
    {
        var mat = _renderer.material;
        _originalColor = mat.HasProperty(BaseColorId) ? mat.GetColor(BaseColorId) : mat.color;
    }

    /// Platte vollständig zurücksetzen (Kontaktstatus + Farbe)
    public void ResetPlate()
    {
        _currentMatchingCube = null;
        SetTileColor(_originalColor);
    }

    private void SetTileColor(Color c)
    {
        var mat = _renderer.material; // immer das aktuelle Material
        if (mat.HasProperty(BaseColorId)) mat.SetColor(BaseColorId, c);
        else mat.color = c;
    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Cube")) return;

        var cube = other.gameObject.GetComponent<Cube>();
        if (cube == null || cube.colorName != matchingColor) return;

        // Übergang 0 -> 1: nur wenn noch kein passender Würfel auf der Platte liegt
        if (_currentMatchingCube == null)
        {
            _currentMatchingCube = other.gameObject;
            SetTileColor(Color.white);
            UICounterManager.Instance?.Increment();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (!other.gameObject.CompareTag("Cube")) return;

        var cube = other.gameObject.GetComponent<Cube>();
        if (cube == null || cube.colorName != matchingColor) return;

        // Übergang 1 -> 0: nur wenn genau dieser passende Würfel die Platte verlässt
        if (_currentMatchingCube == other.gameObject)
        {
            _currentMatchingCube = null;
            SetTileColor(_originalColor);
            UICounterManager.Instance?.Decrement();
        }
    }
}