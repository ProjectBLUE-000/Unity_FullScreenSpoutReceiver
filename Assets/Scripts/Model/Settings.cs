using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[System.Serializable]
public class Settings
{

    public IntReactiveProperty ResolutionX = new IntReactiveProperty();

    public IntReactiveProperty ResolutionY = new IntReactiveProperty();

    public StringReactiveProperty SpoutSourceName = new StringReactiveProperty();


    public void Load()
    {

        ResolutionX.Value = PlayerPrefs.GetInt("ResolutionX", 1920);
        ResolutionY.Value = PlayerPrefs.GetInt("ResolutionY", 1080);
        SpoutSourceName.Value = PlayerPrefs.GetString("SpoutSourceName", "");

    }


    public void Save()
    {
        PlayerPrefs.SetInt("ResolutionX", ResolutionX.Value);
        PlayerPrefs.SetInt("ResolutionY", ResolutionY.Value);
        PlayerPrefs.SetString("SpoutSourceName", SpoutSourceName.Value);

        PlayerPrefs.Save();
    }
}
