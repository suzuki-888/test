using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    // シングルトンパターンを使用して、どこからでもアクセスできるようにする
    public static CheckpointManager Instance;

    // プレイヤーが最後に触れたチェックポイントの位置
    private Vector3 lastCheckpointPosition;

    private void Awake()
    {
        // インスタンスを保持する
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // 最初のチェックポイントの位置を記録
        lastCheckpointPosition = transform.position; // デフォルトは初期位置
    }

    // チェックポイントの位置を設定
    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpointPosition = checkpointPosition;
    }

    // 最後に設定されたチェックポイント位置を取得
    public Vector3 GetLastCheckpoint()
    {
        return lastCheckpointPosition;
    }
}
