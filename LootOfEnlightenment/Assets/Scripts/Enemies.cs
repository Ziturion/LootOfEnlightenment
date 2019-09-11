using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MovableObject
{
    private GameObject _playerCharacter;
    public float DetectionRange;
    public float Speed;
    private void Start()
    {
        _playerCharacter = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        Vector3 playerInDirection = _playerCharacter.transform.position - transform.position;
        if(playerInDirection.magnitude < DetectionRange)
        {
            Move(playerInDirection.normalized, Speed);
        }
        Debug.Log((_playerCharacter.transform.position - transform.position).magnitude);
    }
}
