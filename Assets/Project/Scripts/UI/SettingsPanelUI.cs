using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanelUI : MonoBehaviour
{
    [SerializeField] private RectTransform SettingsPanel;
    [SerializeField] private RectTransform ControlsPanel;
    [SerializeField] private RectTransform AudioPanel;

    public void AudioBttn()
    {
        AudioPanel.gameObject.SetActive(true);
        SettingsPanel.gameObject.SetActive(false);
    }

    public void ControlBttn()
    {
        ControlsPanel.gameObject.SetActive(true);
        SettingsPanel.gameObject.SetActive(false);
    }

    public void ReturnToMainBttn()
    {
        //AudioManager.instance.PlaySFX("ButtonClick");
        SettingsPanel.gameObject.SetActive(true);
        AudioPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(false);
    }
}
