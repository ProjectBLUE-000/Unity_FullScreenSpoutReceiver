using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenTexture : MonoBehaviour
{


    [SerializeField] Shader shader;

    private Material material;

    [SerializeField]
    RenderTexture renderTexture = null;

    void Awake()
    {
        if (material == null)
        {
            material = new Material(shader);
        }

    }

    public void SetTexture(RenderTexture renderTexture)
    {
        this.renderTexture = renderTexture;
        
    }


    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (renderTexture)
        {
            material.SetTexture("_ReplaceTex", renderTexture);
            Graphics.Blit(source, destination, material);
        }
    }

}
