using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportEX_y: MonoBehaviour
{
    // publicで宣言することでインスペクター内から調整可能に
    public float speed = 1.2f;    // 移動速度
    public float topLimit = -0.5f; // 上限Y座標
    public float bottomLimit = -4.5f; // 下限Y座標
    private int num = 1;

    void Update()
    {
        var pos = transform.position;

        // インスペクターで設定したspeedを使用して移動
        transform.Translate(new Vector2(0, num) * Time.deltaTime * speed);

        // Y座標に基づいてnumの値を変更
        if (pos.y > topLimit)
        {
            num = -1;
        }
        else if (pos.y < bottomLimit)
        {
            num = 1;
        }
    }
}
