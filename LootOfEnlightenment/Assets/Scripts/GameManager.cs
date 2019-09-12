using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemySpawner;
    public float EnemyCooldown;
    private float _eCooldown;
    public GameObject PickUpSpawner;
    public float PickUpCooldown;
    private float _pCooldown;

    private bool _waveOn = true;
    public int WaveLengthInSec = 15;
    public int PauseLengthInSec = 15;

    private int _waveLength;
    private int _pauseLength;

    private float _timeTracker;
    private void Awake()
    {
        _eCooldown = EnemyCooldown;
        _pCooldown = PickUpCooldown;
        _waveLength = WaveLengthInSec;
        _pauseLength = PauseLengthInSec;
    }
    void Update()
    {
        _timeTracker += Time.deltaTime;
        if (_waveOn)
        {
            if (_eCooldown <= _timeTracker)
            {
                EnemySpawner.GetComponent<Spawner>().SpawnEnemy();
                _eCooldown += EnemyCooldown;
            }
            if (_pCooldown <= _timeTracker)
            {
                PickUpSpawner.GetComponent<PickUpSpawner>().SpawnItems();
                _pCooldown += PickUpCooldown;
            }
        }
        else if(_pauseLength <= _timeTracker)
        {
            _waveOn = true;
        }

        if (_waveLength < Time.time)
        {
            _waveOn = false;
            _waveLength += WaveLengthInSec + PauseLengthInSec;
            _pauseLength += (int)Time.time;

            MeleeEnemy[] enemies = FindObjectsOfType<MeleeEnemy>();
            foreach(MeleeEnemy e in enemies)
            {
                Destroy(e.gameObject);
            }
        }
    }
}
