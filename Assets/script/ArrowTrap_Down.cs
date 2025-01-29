using System.Collections;
using UnityEngine;

public class ArrowTrapDown : MonoBehaviour
{
    public GameObject arrowPrefab;    // 矢のプレハブ
    public Transform shootPoint;      // 矢を発射する位置
    public float shootInterval = 2f;  // 矢を発射する間隔（秒）
    public float arrowSpeed = 10f;    // 矢のスピード

    private void Start()
    {
        // 定期的に矢を発射する
        StartCoroutine(ShootArrows());
    }

    private IEnumerator ShootArrows()
    {
        while (true)
        {
            // 矢を発射
            ShootArrow();

            // 次の発射まで待機
            yield return new WaitForSeconds(shootInterval);
        }
    }

    private void ShootArrow()
    {
        // 矢のプレハブを発射位置からインスタンス化
        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, Quaternion.identity);

        // 矢の進行方向を決める
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // 矢の向きを決める（例えば右方向）
            rb.velocity = Vector2.down * arrowSpeed;
        }

        // 矢のスプライトを下向きに回転させる
        arrow.transform.rotation = Quaternion.Euler(0, 0, -90);  // Z軸を-90度回転させる
    }
}
