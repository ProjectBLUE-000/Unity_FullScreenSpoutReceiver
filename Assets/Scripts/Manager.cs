using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public static Manager Instance { get { if (_i == null) _i = FindObjectOfType<Manager>(); return _i; } }
    static Manager _i;


    [SerializeField]
    bool debugMenuEnabled = true;

    [SerializeField]
    Canvas debugMenuCanvas;

    Settings settings = new Settings();
    public Settings Settings => settings;


    RenderTextureGenerator renderTextureGenerator;
    public RenderTextureGenerator RenderTextureGenerator => renderTextureGenerator;


    private void Awake()
    {

        settings = new Settings();
        settings.Load();

        renderTextureGenerator = new RenderTextureGenerator();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            debugMenuEnabled = !debugMenuEnabled;
        }

        debugMenuCanvas.gameObject.SetActive(debugMenuEnabled);
    }

    private void OnDestroy()
    {
        settings.Save();

        renderTextureGenerator.Release();
    }
}
