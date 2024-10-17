using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class VolumeView : IInitializable
{
    public event Action OnMuteButtonClicked;
    public event Action<float> OnVolumeChange;

    private Button _muteButton;
    private Slider _volumeSlider;

    private Sprite _enableImage;
    private Sprite _disableImage;

    public VolumeView(Button muteButton, Slider volumeSlider, Sprite enableImage, Sprite disableImage)
    {
        _muteButton = muteButton;
        _volumeSlider = volumeSlider;

        _enableImage = enableImage;
        _disableImage = disableImage;
    }

    public void Initialize()
    {
        _volumeSlider.minValue = VolumeModel.VOLUME_SLIDER_MIN_VALUE;

        _muteButton.onClick.AddListener(() => OnMuteButtonClicked?.Invoke());
        _volumeSlider.onValueChanged.AddListener((vol) => OnVolumeChange?.Invoke(vol));
    }

    public void SetMuteImage(bool isMute)
    {
        _muteButton.image.sprite = isMute ? _disableImage : _enableImage;
    }
    
    public void SetSliderValue(float value)
    {
        _volumeSlider.value = value;
    }
}
