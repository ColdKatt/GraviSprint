using UnityEngine;
using Zenject;

public class SoundInvoker : MonoBehaviour
{
    private SoundManager _soundManager;

    [SerializeField] private SoundType _soundType;
    [SerializeField] private bool _loopSound;

    [Inject]
    private void Construct(SoundManager soundManager)
    {
        _soundManager = soundManager;
    }

    private void Awake()
    {
        var soundHandler = _soundManager.CreateSound(_soundType);

        if (soundHandler != null)
        {
            soundHandler.AudioSource.loop = _loopSound;
        }

        Destroy(gameObject);
    }
}
