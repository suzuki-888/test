using UnityEngine;
public class AutoMove1 : MonoBehaviour
{
    [SerializeField] private Transform _LeftEdge;
    [SerializeField] private Transform _RightEdge;
    private float MoveSpeed = 3.0f;
    private int direction = 1;
    void FixedUpdate()
    {
        if (transform.position.x >= _RightEdge.position.x)
            direction = -1;
        if (transform.position.x <= _LeftEdge.position.x)
            direction = 1;
        transform.position = new Vector3(transform.position.x + MoveSpeed * Time.fixedDeltaTime * direction, 19, 0);
    }
}