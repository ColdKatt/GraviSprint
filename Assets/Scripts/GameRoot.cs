using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private ObstacleSpawner _obstacleSpawner;
    private static float s_environmentSpeed;
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
            s_obstacleRateSpawn = Mathf.Clamp(value, 0.5f, 4.0f);
        }
    }

    public static float EnvironmentSpeed
    {
        get
        {
            return s_environmentSpeed;
        }
        set
        {
            s_environmentSpeed = Mathf.Clamp(value, 0.0f, 100.0f);
            Debug.Log($"Changed to: {s_environmentSpeed}");
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
        EnvironmentSpeed = 3.0f;
        ObstacleRateSpawn = 3.0f;
        _obstacleSpawner = new ObstacleSpawner();

        SaveData.Load();

        _spawnCoroutine ??= StartCoroutine(Spawn());
    }

    private void Start()
    {
        PlayerState = new Alive();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.0f); // Give the player a pause for looking

        while (PlayerState is Alive) // Replace to GameRoot.State == State.Alive
        {
            _obstacleSpawner.Spawn();
            Debug.Log(ObstacleRateSpawn);
            yield return new WaitForSeconds(ObstacleRateSpawn);
        }
        StopEnvironment();
    }

    public static void ReCalculateParameters()
    {
        EnvironmentSpeed = PlayerState is Alive ? Scoring.Score / 50.0f : 0.0f;

        ObstacleRateSpawn = Scoring.Score > 100 ? 3.0f - (2.65f * (Scoring.Score / 650.0f)) : 4.0f;
    }

    public void StopEnvironment()
    {
        if (PlayerState is not Dead) return;
        Debug.Log("StopEnv");

        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
    }
}
