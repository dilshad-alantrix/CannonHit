using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    [SerializeField] private Toggle muteToggle;

    void OnEnable()
    {
        muteToggle.onValueChanged.AddListener(delegate { OnMuteToggleChanged(); });
    }
    void OnDisable()
    {
        muteToggle.onValueChanged.RemoveListener(delegate { OnMuteToggleChanged(); });
    }
    void Start()
    {
       
        muteToggle.isOn = PlayerPrefs.GetInt("Mute") == 1 ? true : false;
    }

    public void OnMuteToggleChanged()
    {
        if (muteToggle.isOn)
        {
            AudioListener.volume = 1f;
            PlayerPrefs.SetInt("Mute", 1);
        }
        else
        {
            AudioListener.volume = 0f;
            PlayerPrefs.SetInt("Mute", 0);
        }
    }
}
