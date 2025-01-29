using UnityEngine;
using UnityEngine.SceneManagement;  // SceneManagementをインポート

public class SceneLoader : MonoBehaviour
{
    // 次のシーンに移行するメソッド
    public void LoadNextScene()
    {
        // 現在のシーンのインデックスを取得
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // 次のシーンに移行（インデックス+1）
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // シーンがロードされた後にタイムスケールを1に設定
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // タイムスケールを1に設定（通常の速度）
        Time.timeScale = 1f;

        // シーンの物理演算やキャラクターの動作が正しく初期化されているか確認
        InitializePlayerMovement();
    }

    // キャラクターの移動を初期化
    private void InitializePlayerMovement()
    {
        // キャラクターのRigidbodyが存在する場合、初期化処理を行います
        Rigidbody rb = FindObjectOfType<Rigidbody>();
        if (rb != null)
        {
            // Rigidbodyが正しく初期化されていれば、シーン遷移後に物理演算が正常に動作するように確認
            rb.velocity = Vector3.zero;  // 前回の速度をリセット
        }

        // 他のキャラクター関連の初期化処理をここに追加することもできます
    }

    // このメソッドを実行するために、シーンが読み込まれた後にイベントを登録する
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // イベント登録を解除する
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Updateメソッドでスペースキーが押されたかを検出してシーンを移行
    void Update()
    {
        // スペースキーが押された場合
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 次のシーンを読み込む
            LoadNextScene();
        }
    }
}
