using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportEX_x: MonoBehaviour
{
    // publicで宣言することでインスペクター内から調整可能に
    public float speed = 1.2f;    // 移動速度
    public float leftLimit = -4.5f; // 左限X座標
    public float rightLimit = 4.5f; // 右限X座標
    private int num = 1;

    // プレイヤーのオブジェクトを設定するための変数
    public Transform player;

    void Update()
    {
        var pos = transform.position;

        // 乗り物の移動
        transform.Translate(new Vector2(num, 0) * Time.deltaTime * speed);

        // プレイヤーも乗り物に合わせて移動
        if (player != null)
        {
            // プレイヤーが乗り物の子オブジェクトとして動く
            player.position = new Vector3(transform.position.x, player.position.y, player.position.z);
        }

        // X座標に基づいて移動方向を変更
        if (pos.x > rightLimit)
        {
            num = -1;  // 右端に達したら左に移動
        }
        else if (pos.x < leftLimit)
        {
            num = 1;   // 左端に達したら右に移動
        }
    }
}
