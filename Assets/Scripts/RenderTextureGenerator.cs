using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resolution
{
    public int width;
    public int height;

    public Resolution(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
}

public class RenderTextureGenerator
{

    public Resolution defaultResolution = new Resolution(1920, 1080);

    private RenderTexture renderTexture;
    public RenderTexture RenderTexture {
        get {
            if(renderTexture == null)
                Generate(defaultResolution);
            return renderTexture;
        }
    }

    public RenderTexture Generate(Resolution resolution)
    {
        Release();

        RenderTexture tex = new RenderTexture(resolution.width, resolution.height, 24, RenderTextureFormat.ARGB32);
        tex.name = "Auto Created RenderTexture";

        renderTexture = tex;

        return tex;
    }

    public void Release()
    {
        if (renderTexture)
        {
            renderTexture.Release();
        }
    }

}
