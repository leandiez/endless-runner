using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class Animar : MonoBehaviour
{
    public Texture2D[] frames;
    public float framesPorSegundo = 10;
    
    void Update()
    {
        float index = Time.time * framesPorSegundo;
        index = index % frames.Length;

        GetComponent.< Renderer > ().material.mainTexture = frames[index];
    }
}
