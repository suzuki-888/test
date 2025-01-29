// PlayerController.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Camera mainCamera;
    private float screenLeft, screenRight, screenTop, screenBottom;
    private float stageBottom;

    public GameObject gameOverScreen;
    public AudioClip dieSound;
    public AudioSource bgmAudioSource;

    public Vector3 cameraInitialPosition = new Vector3(0, 0, -10);
    public float cameraMinX = -5f, cameraMaxX = 5f;
    public float cameraMinY = -5f, cameraMaxY = 5f;

    private bool hasPlayedDieSound = false;
    private Rigidbody2D rb;  // Rigidbody2Dコンポーネント
    private PlayerHP playerHP;  // PlayerHPコンポーネントを取得

    private void Start()
    {
        mainCamera = Camera.main;

        // 初期カメラ位置の設定
        mainCamera.transform.position = cameraInitialPosition;

        screenLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        screenRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        screenTop = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        screenBottom = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        stageBottom = screenBottom - 2.0f;

        gameOverScreen.SetActive(false);

        rb = GetComponent<Rigidbody2D>();  // Rigidbody2Dコンポーネントの取得
        playerHP = GetComponent<PlayerHP>(); // PlayerHPコンポーネントの取得

    }

    void Update()
    {
        // プレイヤーがステージ下に落ちた場合
        if (transform.position.y < stageBottom)
        {
            GameOver();
        }

        RestrictCameraMovement();
    }

    void RestrictCameraMovement()
    {
        Vector3 newCameraPos = mainCamera.transform.position;

        // カメラのX座標を制限
        newCameraPos.x = Mathf.Clamp(transform.position.x, cameraMinX, cameraMaxX);

        // カメラのY座標を制限
        newCameraPos.y = Mathf.Clamp(transform.position.y, cameraMinY, cameraMaxY);

        newCameraPos.z = mainCamera.transform.position.z;

        mainCamera.transform.position = newCameraPos;
    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);

        if (!hasPlayedDieSound)
        {
            AudioSource.PlayClipAtPoint(dieSound, transform.position);
            hasPlayedDieSound = true;
        }

        Time.timeScale = 0f;

        if (bgmAudioSource != null)
        {
            bgmAudioSource.Stop();
        }
    }

    // チェックポイント通過時にその位置を保存
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            GameManager.instance.SetCheckpoint(transform.position);  // チェックポイントの位置を保存
            Debug.Log("チェックポイント通過: " + transform.position);
        }
    }

    // ゲームをリスタート
    public void Restart()
    {
        Time.timeScale = 1f; // ゲームを再開

        // シーンをリロード
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // 現在のシーンをリロード

        // プレイヤーの操作を再有効化
        rb.velocity = Vector2.zero;  // 速度をリセット

        // Rigidbody2Dの物理演算を有効にする
        rb.isKinematic = false;  // 物理演算を再有効化

        // プレイヤーの移動を再有効化（PlayerControllerはシーンがリロードされることで再起動される）
        playerHP = GetComponent<PlayerHP>(); // PlayerHPを再取得
        playerHP.Restart();  // PlayerHPのリスタート処理を呼び出す
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
