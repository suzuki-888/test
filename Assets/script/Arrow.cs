using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float lifetime = 5f;  // 矢の寿命（秒）

    private void Start()
    {
        // 矢が一定時間後に消える
        Destroy(gameObject, lifetime);

        // 矢同士の衝突を無視する
        Arrow[] arrows = FindObjectsOfType<Arrow>(); // シーン内のすべての矢を取得
        foreach (var arrow in arrows)
        {
            if (arrow != this)  // 自分自身の矢には適用しない
            {
                // 他の矢との衝突を無視
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), arrow.GetComponent<Collider2D>());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // プレイヤーや障害物に衝突した場合
        // 衝突したオブジェクトがPlayerや障害物の場合に矢を消す
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Block"))
        {
            // 衝突したら矢を消す
            Destroy(gameObject);
        }
    }
}
