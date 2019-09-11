using UnityEngine;

public class Player : MovableObject
{
    public float MovementSpeed = 0.1f;

    void Update()
    {
        if (Input.anyKey)
        {
            Move(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), MovementSpeed);
        }
    }
}
