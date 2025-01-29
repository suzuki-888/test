using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public AudioClip damageSound;  // ダメージ音
    public AudioClip dieSound;     // 死亡音
    private Animator animator;     // アニメーター

    private int HP;                // 現在のHP
    private int maxHP = 3;         // 最大HP
    public GameObject[] hpIcons;   // HPアイコン
    public GameObject gameOverScreen;  // ゲームオーバー画面のUI

    // BGMのオーディオソース（インスペクターで設定可能）
    public AudioSource bgmAudioSource;

    private bool isInvincible;     // 無敵状態かどうか
    private float invincibleTime = 0.7f;  // 無敵時間（秒）

    private PlayerMovement playerMovement;  // プレイヤーの操作を管理するスクリプト

    private bool isGameOver = false;  // ゲームオーバー状態かどうか

    private void Start()
    {
        animator = GetComponent<Animator>();
        HP = maxHP; // 初期HP設定
        UpdateHPUI(); // 初期状態のHPアイコンを更新
        gameOverScreen.SetActive(false); // ゲームオーバー画面を初期状態で非表示
        isInvincible = false; // 初期状態では無敵ではない

        // プレイヤーの操作スクリプトを取得
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ゲームオーバー状態の場合は何も受け付けない
        if (isGameOver) return;

        // 無敵状態の場合はダメージを受けない
        if (isInvincible) return;

        // "GameOver"タグがついたオブジェクトに衝突した場合
        if (collision.gameObject.CompareTag("GameOver"))
        {
            HP = 0; // すぐに死亡処理
            UpdateHPUI();
            HandleDeath();
        }

        // "Trap"タグがついたオブジェクトに衝突した場合
        if (collision.gameObject.CompareTag("Trap"))
        {
            HP -= 1;  // トラップでダメージ
            UpdateHPUI();
            animator.SetTrigger("Damage");

            if (HP > 0)
            {
                AudioSource.PlayClipAtPoint(damageSound, transform.position);
                StartCoroutine(InvincibleCoroutine());  // 無敵状態開始
            }
            else
            {
                HandleDeath();
            }
        }
    }

    // HPアイコンの表示/非表示を管理
    void UpdateHPUI()
    {
        for (int i = 0; i < hpIcons.Length; i++)
        {
            // HPに合わせてアイコンを表示
            hpIcons[i].SetActive(i < HP);
        }
    }

    public void Heal(int amount)
{
    // HPを回復させる
    HP += amount;

    // 最大HPを超えないように制限
    if (HP > maxHP)
    {
        HP = maxHP;
    }

    // HPアイコンを更新
    UpdateHPUI();
}


    // プレイヤーの死亡処理
    void HandleDeath()
    {
        AudioSource.PlayClipAtPoint(dieSound, transform.position);
        Time.timeScale = 0f; // ゲームを停止
        gameOverScreen.SetActive(true); // ゲームオーバー画面を表示

        // プレイヤーの操作を無効化
        if (playerMovement != null)
        {
            playerMovement.enabled = false;  // PlayerMovement を無効にする
        }

        // BGMを停止する
        if (bgmAudioSource != null)
        {
            bgmAudioSource.Stop();  // BGMの再生を停止
        }

        // ゲームオーバー状態にする
        isGameOver = true;

        // 0.5秒後に操作を再開する
        StartCoroutine(WaitAndEnableControls());
    }

    // 操作を0.5秒間無効にする
    private IEnumerator WaitAndEnableControls()
    {
        yield return new WaitForSeconds(1.5f);  // 0.5秒待機
        isGameOver = false; // ゲームオーバー状態を解除
        Time.timeScale = 1f; // ゲームを再開
        // プレイヤーの操作を再有効化
        playerMovement.enabled = true;  // プレイヤー操作を有効にする
    }

    // ゲームをリスタート
    public void Restart()
    {
        Time.timeScale = 1f; // ゲームを再開

        // シーンをリロード
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // 現在のシーンをリロード

        // プレイヤーの操作を再有効化
        playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = true;  // プレイヤー操作を有効にする
        }

        // Rigidbody2Dの設定をリセット
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;  // 速度をリセット
            rb.isKinematic = false;      // 物理演算を再有効化
        }
    }

    // ゲーム終了
    public void QuitGame()
    {
        Application.Quit(); // ゲーム終了
    }

    // 無敵状態を管理するコルーチン
    private IEnumerator InvincibleCoroutine()
    {
        isInvincible = true;  // 無敵状態にする
        yield return new WaitForSeconds(invincibleTime);  // 無敵時間が経過するまで待つ
        isInvincible = false; // 無敵状態解除
    }
}
