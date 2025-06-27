using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System;
using UnityEngine.InputSystem;

public class GroundTile : MonoBehaviour
{

    private Renderer _renderer;
    private Material _material;
    private Color _originalColor;
    private Cube cube;
    private GameObject[] arrayofcubes;
    public string matchingColor;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer.material;
        _originalColor = _material.GetColor("_BaseColor");
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            cube = other.gameObject.GetComponent<Cube>();
            if (cube.colorName == matchingColor)
            {
                Debug.Log(other.gameObject.CompareTag("Cube"));
                Debug.Log("A collider has made contact with the Collider");
                _material.SetColor("_BaseColor", Color.white);
                UICounterManager.Instance.Increment();
            }
        }
       
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            cube = other.gameObject.GetComponent<Cube>();
            if (cube.colorName == matchingColor)
            {
                Debug.Log("A collider has ceased contact with the Collider");
                _material.SetColor("_BaseColor", _originalColor);
                UICounterManager.Instance.Decrement();  
            }
        }
    }
}
