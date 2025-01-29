using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public PlatformEffector2D platformEffector;  // PlatformEffector2Dの参照
    private float defaultSurfaceArc = 180f;      // 通常のすり抜け範囲（下からだけ通り抜け）

    void Start()
    {
        if (platformEffector == null)
        {
            platformEffector = GetComponent<PlatformEffector2D>();
        }

        // 初期設定として、下からのみすり抜け可能に設定
        platformEffector.surfaceArc = defaultSurfaceArc;
    }

    void Update()
    {
        // 下キーを押した場合、上からも通り抜けられるようにする
        if (Input.GetKey(KeyCode.DownArrow))
        {
            platformEffector.surfaceArc = 360f;  // 上からも通り抜け可能に設定
        }
        else
        {
            platformEffector.surfaceArc = defaultSurfaceArc;  // 通常の下からだけ通り抜け設定
        }
    }
}
