using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    private int num = 1;

    void Update()
    {
        var pos = transform.position;

        transform.Translate(new Vector2(0, num) * Time.deltaTime * 1.2f);

        if (pos.y > 0)
        {
            num = -1;
        }
        else if (pos.y < -4.3f)
        {
            num = 1;
        }
    }
}
