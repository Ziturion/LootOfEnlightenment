using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemySpawner;
    public float EnemyCooldown = .7f;
    private float _eCooldown;
    public GameObject PickUpSpawner;
    public float PickUpCooldown = 5f;
    private float _pCooldown;

    public Player[] Characters;

    private bool _waveOn = true;
    public int WaveLengthInSec = 45;
    public int PauseLengthInSec = 15;
    public int WaveNumber{get; private set;}

    private int _waveLength;
    private float _pauseLength;

    private float _timeTracker;

    public Player ActivePlayer;

    public static GameManager Instance
    {
        get
        {
            if (_instance != null)
                return _instance;
            _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }

    private static GameManager _instance;

    private void Awake()
    {
        _eCooldown = EnemyCooldown;
        _pCooldown = PickUpCooldown;
        _waveLength = WaveLengthInSec;
        _pauseLength = PauseLengthInSec;
        int characterSelected = PlayerPrefs.GetInt("Character", 0);
        Debug.Log(characterSelected);
        ActivePlayer = Instantiate(Characters[characterSelected]);
    }
    void Update()
    {
        _timeTracker += Time.deltaTime;
        _pauseLength -= Time.deltaTime;
        if (_waveOn)
        {
            if (_eCooldown <= _timeTracker)
            {
                EnemySpawner.GetComponent<Spawner>().SpawnEnemy(WaveNumber);
                _eCooldown += EnemyCooldown;
            }
            if (_pCooldown <= _timeTracker)
            {
                PickUpSpawner.GetComponent<PickUpSpawner>().SpawnItems();
                _pCooldown += PickUpCooldown;
            }
        }
        else if(_pauseLength <= 0)
        {
            _waveOn = true;
            _eCooldown = Time.time;
            _pCooldown = Time.time;
            EnemyCooldown *= .95f;

            WaveNumber++;
            ChangeCooldowns();
        }

        if (_waveLength < Time.time)
        {
            _waveOn = false;
            _waveLength += WaveLengthInSec + PauseLengthInSec;
            _pauseLength = PauseLengthInSec;

            //MeleeEnemy[] enemies = FindObjectsOfType<MeleeEnemy>();
            //foreach(MeleeEnemy e in enemies)
            //{
            //    Destroy(e.gameObject);
            //}
        }
    }

    public void ChangeCooldowns()
    {
        EnemyCooldown *= Random.Range(.9f, .95f);
    }
}
