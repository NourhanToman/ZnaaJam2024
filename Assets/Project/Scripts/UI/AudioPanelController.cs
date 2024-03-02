using UnityEngine;
using UnityEngine.UI;

public class AudioPanelController : MonoBehaviour
{
    public Slider musicSlider, SFXSlider;

    private ServiceLocator ServiceLocator => ServiceLocator.Instance;

    public void ToggleMusic() => ServiceLocator.GetService<AudioManager>().ToggleMusic();

    public void ToggleSFX() => ServiceLocator.GetService<AudioManager>().ToggleSFX();

    public void MusicVolume() => ServiceLocator.GetService<AudioManager>().MusicVolume(musicSlider.value);

    public void SFXVolume() => ServiceLocator.GetService<AudioManager>().SFXVolume(SFXSlider.value);
}