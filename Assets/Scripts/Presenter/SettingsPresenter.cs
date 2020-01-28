using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using System;
using Klak.Spout;

public class SettingsPresenter : MonoBehaviour
{


    [SerializeField]
    Button resolutionSetButton;

    [SerializeField]
    InputField resolutionWidthField;

    [SerializeField]
    InputField resolutionHeightField;

    [SerializeField]
    InputField spoutSourceField;


    [Space(10)]
    [SerializeField]
    SpoutReceiver spoutReceiver;

    [SerializeField]
    FullscreenTexture fullscreenTextureImageEffect;


    Settings settings;


    void Start()
    {

        settings = Manager.Instance.Settings;

        CreateAndSetRenderTexture();



        SetupModelToView();
        InitializeView();


        SetupViewToModel();

    }

    private void InitializeView()
    {
        resolutionWidthField.text = settings.ResolutionX.Value.ToString();
        resolutionHeightField.text = settings.ResolutionY.Value.ToString();
        spoutSourceField.text = settings.SpoutSourceName.Value;
    }

    void SetupModelToView()
    {
        settings.ResolutionX.Subscribe(value => { resolutionWidthField.text = value.ToString(); });
        settings.ResolutionY.Subscribe(value => { resolutionHeightField.text = value.ToString(); });

        settings.SpoutSourceName.Subscribe(value => { spoutSourceField.text = value; });
    }

    void SetupViewToModel()
    {
        resolutionWidthField
            .OnEndEditAsObservable()
            .Subscribe(value =>
            {
                try
                {

                    int parsed = int.Parse(value);

                    settings.ResolutionX.Value = parsed;

                }
                catch (Exception e)
                {
                    Debug.LogError("Invalid resolution value");
                }

            });


        resolutionHeightField
            .OnEndEditAsObservable()
            .Subscribe(value =>
            {
                try
                {

                    int parsed = int.Parse(value);

                    settings.ResolutionY.Value = parsed;

                }
                catch (Exception e)
                {
                    Debug.LogError("Invalid resolution value");
                }

            });


        resolutionSetButton
            .OnClickAsObservable()
            .Subscribe(value =>
            {
                CreateAndSetRenderTexture();
            });


        spoutSourceField
            .OnValueChangedAsObservable()
            .Subscribe(value =>
            {

                settings.SpoutSourceName.Value = value;
                spoutReceiver.sourceName = value;

            });
    }

    void CreateAndSetRenderTexture()
    {
        var tex = Manager.Instance.RenderTextureGenerator.Generate(new Resolution(settings.ResolutionX.Value, settings.ResolutionY.Value));

        fullscreenTextureImageEffect.SetTexture(tex);
        spoutReceiver.targetTexture = tex;
    }

    

}
