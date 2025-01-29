using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float jumpSpeed;
    public AudioClip jumpSound;
    private Rigidbody2D rb2d;
    private AudioSource audioSource;

    public LayerMask floor; // 地面のレイヤー
    public float groundCheckDistance = 0.1f; // 足元のRaycastチェックの距離
    public float edgeCheckDistance = 0.2f; // 足場の端のチェック距離

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();   
    }

    void Update()
    {
        // 横移動の処理
        float moveH = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(moveH, 0);
        transform.Translate(movement * Time.deltaTime * speed);

        animator.SetFloat("Speed", Mathf.Abs(moveH));

        // スプライトの向きを反転
        if (moveH > 0.5f)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveH < -0.5f)
        {
            spriteRenderer.flipX = true;
        }

        // ジャンプの処理
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb2d.velocity = Vector2.up * jumpSpeed; // ジャンプ力を設定
            audioSource.PlayOneShot(jumpSound); // ジャンプ音を再生
            animator.SetTrigger("Jump"); // ジャンプアニメーションを設定
        }
    }

    // 足元が地面に接しているかどうかを判定するメソッド
    private bool IsGrounded()
    {
        // プレイヤーの足元から下方向にRaycastを飛ばして地面に接しているか確認
        RaycastHit2D hit2d = Physics2D.Raycast(
            new Vector2(transform.position.x, transform.position.y - 0.5f), // 足元の位置
            Vector2.down, // 下方向
            groundCheckDistance, // 足元からどれくらい下にRaycastを飛ばすか
            floor // 地面のレイヤー
        );

        // プレイヤーの足元の両側（端のチェック）のRaycast
        bool isEdgeGroundedLeft = Physics2D.Raycast(
            new Vector2(transform.position.x - edgeCheckDistance, transform.position.y - 0.5f), // 左側足元
            Vector2.down, 
            groundCheckDistance, 
            floor
        );

        bool isEdgeGroundedRight = Physics2D.Raycast(
            new Vector2(transform.position.x + edgeCheckDistance, transform.position.y - 0.5f), // 右側足元
            Vector2.down, 
            groundCheckDistance, 
            floor
        );

        // 足元と足場の端が接している場合もジャンプできるようにする
        return hit2d.collider != null || isEdgeGroundedLeft || isEdgeGroundedRight;
    }
}
