using UnityEngine;
using Cinemachine;

public class CameraBounds : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Cinemachine Virtual Camera
    public float minX, maxX, minY, maxY;           // 移動範囲を設定

    void Update()
    {
        // カメラの位置を取得
        Vector3 cameraPosition = virtualCamera.transform.position;

        // X座標の制限
        cameraPosition.x = Mathf.Clamp(cameraPosition.x, minX, maxX);

        // Y座標の制限
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, minY, maxY);

        // Z座標は変更しない
        cameraPosition.z = virtualCamera.transform.position.z;

        // 新しい位置をカメラに適用
        virtualCamera.transform.position = cameraPosition;
    }
}
