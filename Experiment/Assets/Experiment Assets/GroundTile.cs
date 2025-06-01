using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class GroundTile : MonoBehaviour
{

    private Renderer _renderer;
    private Material _material;
    private Color _originalColor;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
        _originalColor = _material.GetColor("_BaseColor");
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("A collider has made contact with the Collider");
       
        _material.SetColor("_BaseColor", Color.yellowNice);
    }

    void OnCollisionExit(Collision other)
    {
        Debug.Log("A collider has ceased contact with the Collider");
        _material.SetColor("_BaseColor", _originalColor);
    }
}
