using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // 再スタートボタンの処理
    public void RestartGame()
    {
        // シーンを再ロード（再スタート）
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // 現在のシーンを再読み込み
        Time.timeScale = 1f; // ゲームを再開
    }

    void Update()
    {
        // スペースキーが押されたときにリスタート処理を実行
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }
}
