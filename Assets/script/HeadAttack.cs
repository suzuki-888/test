using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAttack : MonoBehaviour
{
    public AudioClip sound;
    public GameObject effectPrefab;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RaycastHit2D hit2d = Physics2D.Raycast(transform.position, Vector2.up, 0.25f);

        if(hit2d.collider != null)
        {
            if(hit2d.collider.CompareTag("SoftBlock"))
            {
                Destroy(hit2d.collider.gameObject);

                AudioSource.PlayClipAtPoint(sound, transform.position);

                Instantiate(effectPrefab, hit2d.collider.transform.position, Quaternion.identity);

                // （テクニック）下向きに反発させることで一度に二個のブロック破壊を防止する（二個抜き禁止）
                rb2d.velocity = Vector2.down * 1.2f;
            }
        }
    }
}
