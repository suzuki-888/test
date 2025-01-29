using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoint : MonoBehaviour
{
    public float jumpForce = 13f; // ジャンプ力をインスペクターから設定できるようにする
    public Vector2 jumpDirection = Vector2.up; // ジャンプ方向をインスペクターから設定できるようにする

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // プレイヤーが衝突した場合にジャンプさせる
        if (collision.gameObject.CompareTag("Player")) // プレイヤーのみを対象にする
        {
            // Rigidbody2Dコンポーネントを取得
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // ジャンプ力と方向を加える
                rb.velocity = new Vector2(rb.velocity.x, jumpDirection.y * jumpForce);
            }
        }
    }
}
