using UnityEngine;
using UnityEngine.UI;

public class AudioPanelController : MonoBehaviour
{
    public Slider musicSlider, SFXSlider;

    private ServiceLocator _serviceLocator => ServiceLocator.Instance;

    public void ToggleMusic() => _serviceLocator.GetService<AudioManager>().ToggleMusic();

    public void ToggleSFX() => _serviceLocator.GetService<AudioManager>().ToggleSFX();

    public void MusicVolume() => _serviceLocator.GetService<AudioManager>().MusicVolume(musicSlider.value);

    public void SFXVolume() => _serviceLocator.GetService<AudioManager>().SFXVolume(SFXSlider.value);
}