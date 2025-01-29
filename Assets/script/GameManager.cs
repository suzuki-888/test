// GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  // ゲームマネージャのインスタンス
    private Vector2 checkpointPosition;  // チェックポイントの位置

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // シーン切り替え時に消えないようにする
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // チェックポイント位置を保存するメソッド
    public void SetCheckpoint(Vector2 position)
    {
        checkpointPosition = position;
    }

    // チェックポイント位置を取得するプロパティ
    public Vector2 CheckpointPosition
    {
        get { return checkpointPosition; }
    }
}
