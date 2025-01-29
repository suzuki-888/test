using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Cinemachine Virtual Cameraの参照
    public Vector3 initialCameraPosition = new Vector3(0, 5, -10); // 初期位置の設定

    void Start()
    {
        // カメラの初期位置を設定
        virtualCamera.transform.position = initialCameraPosition;
    }
}
