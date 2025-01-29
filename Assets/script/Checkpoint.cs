using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // チェックポイントの位置を保存するための変数
    public Transform checkpointPosition;

    // チェックポイントに触れたときに呼ばれる処理
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // プレイヤーがチェックポイントに触れたときに進行状況を保存
            GameManager.instance.SetCheckpoint(checkpointPosition.position);
        }
    }
}
