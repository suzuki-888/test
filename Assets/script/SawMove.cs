using UnityEngine;

public class SawMove : MonoBehaviour
{
    [SerializeField] private float _InitialYPosition = 3.0f;  // 初期Y位置
    [SerializeField] private float _UpperLimit = 6.0f;        // 上限Y位置
    [SerializeField] private float _LowerLimit = 0.0f;        // 下限Y位置
    [SerializeField] private float MoveSpeed = 3.0f;          // 移動速度

    private int directionY = 1;  // Y軸の移動方向

    void Start()
    {
        // 初期位置を設定
        transform.position = new Vector3(transform.position.x, _InitialYPosition, transform.position.z);
    }

    void FixedUpdate()
    {
        // Y軸の移動範囲制御
        if (transform.position.y >= _UpperLimit)  // 上限に達したら
            directionY = -1;  // 下に移動
        if (transform.position.y <= _LowerLimit)  // 下限に達したら
            directionY = 1;   // 上に移動

        // Y軸の移動
        transform.position = new Vector3(transform.position.x, transform.position.y + MoveSpeed * Time.fixedDeltaTime * directionY, transform.position.z);
    }
}
