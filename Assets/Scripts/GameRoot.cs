using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private ObstacleSpawner _obstacleSpawner;
    private static float s_obstacleSpeed;
    private static float s_obstacleRateSpawn;

    private static PlayerState _playerState = new Alive();

    private Coroutine _spawnCoroutine;

    public static float ObstacleRateSpawn
    {
        get
        {
            return s_obstacleRateSpawn;
        }
        set
        {
            s_obstacleRateSpawn = Mathf.Clamp(value, 0.5f, 1.5f);
        }
    }

    public static float ObstacleSpeed
    {
        get
        {
            return s_obstacleSpeed;
        }
        set
        {
            if (PlayerState is not Dead)
            {
                s_obstacleSpeed = Mathf.Clamp(value, 0.0f, 100.0f);
                Debug.Log($"Changed to: {s_obstacleSpeed}");
            }
            else
            {
                s_obstacleRateSpawn = 0.0f;
            }
        }
    }

    public static PlayerState PlayerState
    {
        get 
        { 
            return _playerState; 
        }
        set 
        {
            _playerState = value;
            _playerState.OnStateChange();
        }
    }

    private void Awake()
    {
        ObstacleSpeed = 1.0f;
        ObstacleRateSpawn = 1.5f;
        _obstacleSpawner = new ObstacleSpawner();

        _spawnCoroutine ??= StartCoroutine(Spawn());
    }

    private void Start()
    {
        PlayerState = new Alive();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.0f); // Give the player a pause for looking

        while (true) // Replace to GameRoot.State == State.Alive
        {
            _obstacleSpawner.Spawn();


            yield return new WaitForSeconds(ObstacleRateSpawn);
        }
    }

    public static void ReCalculateParameters()
    {
        ObstacleSpeed = Scoring.Score / 100.0f;
        ObstacleRateSpawn = 1.5f - (1.0f * (Scoring.Score / 500.0f));
    }

    public void StopEnvironment()
    {
        if (PlayerState is not Dead) return;
        Debug.Log("StopEnv");
        ObstacleSpeed = 0.0f;

        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
    }
}
