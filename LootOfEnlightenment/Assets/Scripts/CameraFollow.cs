using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject _player;
    // Start is called before the first frame update
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = _player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);
    }
}
