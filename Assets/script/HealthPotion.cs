using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int healAmount = 1;  // 回復量
    public AudioClip pickupSound;  // 回復アイテム取得音

    private void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーがアイテムに触れたかどうかを確認
        if (other.CompareTag("Player"))
        {
            // プレイヤーのHPスクリプトを取得して回復処理を呼び出す
            PlayerHP playerHP = other.GetComponent<PlayerHP>();
            if (playerHP != null)
            {
                playerHP.Heal(healAmount);  // HPを回復
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);  // アイテム取得音を再生
                Destroy(gameObject);  // アイテムを削除
            }
        }
    }
}
