using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPointRight : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * 15f;
    }
}