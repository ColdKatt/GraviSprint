using UnityEngine;
using Zenject;

public class VolumePresenter : IInitializable
{
    private readonly VolumeView _volumeView;
    private readonly VolumeModel _volumeModel;

    public VolumePresenter(VolumeView volumeView, VolumeModel volumeModel)
    {
        _volumeView = volumeView;
        _volumeModel = volumeModel;
    }

    public void Initialize()
    {
        _volumeView.SetMuteImage(_volumeModel.IsMute.Value);
        _volumeView.SetSliderValue(_volumeModel.Volume);

        _volumeView.OnMuteButtonClicked += () => _volumeModel.MuteVolume();
        _volumeModel.OnVolumeMuted += (isMute) => _volumeView.SetMuteImage(isMute);

        _volumeView.OnVolumeChange += (vol) => _volumeModel.ChangeVolume(vol);
    }
}
