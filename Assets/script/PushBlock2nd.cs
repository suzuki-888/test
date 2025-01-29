using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock2nd : MonoBehaviour
{
     private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // ブロックを空中に浮かせる（ポイント）
        rb2d.bodyType = RigidbodyType2D.Kinematic;

        // 角度を固定する
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", 0.1f);
        }
    }

    void Fall()
    {
        // 重力が働き出す。
        rb2d.bodyType = RigidbodyType2D.Dynamic;
    }
}