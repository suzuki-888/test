using UnityEngine;
using UnityEngine.SceneManagement;  // シーンの管理用

public class PlayerGoal : MonoBehaviour
{
    public GameObject goal;  // ゴールオブジェクト
    public GameObject clearScreen;  // クリア画面UI（インスペクターで設定）
    public AudioClip clearSound;  // クリア時の効果音（インスペクターで設定）
    // BGMのオーディオソース（インスペクターで設定可能）
    public AudioSource bgmAudioSource;

    private PlayerMovement playerMovement;  // プレイヤーの操作を管理するスクリプト

    private void Start()
    {
        // ゲームクリア画面を非表示に設定
        clearScreen.SetActive(false);

        // プレイヤーの操作スクリプトを取得
        playerMovement = GetComponent<PlayerMovement>();
    }

    // ゴールに触れたときの処理
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ゴールと接触した場合
        if (other.CompareTag("Goal"))
        {
            GameClear();
        }
    }

    // ゲームクリア処理
    private void GameClear()
    {
        // クリア画面を表示
        clearScreen.SetActive(true);

        // クリア時の効果音を再生
        if (clearSound != null && bgmAudioSource != null)
        {
            bgmAudioSource.PlayOneShot(clearSound);  // 効果音を一度だけ再生
        }

        // ゲームを停止（オプション）
        Time.timeScale = 0f;  // ゲームを停止する（タイムスケールを0にする）

        // プレイヤーの操作を無効化
        if (playerMovement != null)
        {
            playerMovement.enabled = false;  // PlayerMovement を無効にする
        }

        
    }
}
