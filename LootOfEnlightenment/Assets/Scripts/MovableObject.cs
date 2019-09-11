using UnityEngine;

public class MovableObject : MonoBehaviour
{
    protected virtual void Move(Vector3 direction, float speed)
    {
        transform.position += direction.normalized * speed;
    }
}
