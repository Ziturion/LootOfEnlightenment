using UnityEngine;

public class MovableObject : MonoBehaviour
{
    protected virtual void Move(Vector3 direction, float speed)
    {
        Debug.Log(direction);
        transform.position += direction.normalized * speed;
    }
}
