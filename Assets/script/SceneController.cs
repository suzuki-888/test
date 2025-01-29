// SceneController.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Update()
    {
        // スペースキーが押されたかをチェック
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ゲーム画面のシーンに切り替え
            SceneManager.LoadScene("GameScene");

            // チェックポイントが設定されている場合、その位置から再スタート
            Vector2 checkpointPosition = GameManager.instance.CheckpointPosition;

            // チェックポイント位置が設定されていれば、プレイヤーをその位置に移動させる
            if (checkpointPosition != Vector2.zero)
            {
                PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
                if (playerMovement != null)
                {
                    playerMovement.transform.position = checkpointPosition;
                }
            }
        }
    }
}
