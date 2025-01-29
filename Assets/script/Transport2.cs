using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport2 : MonoBehaviour
{
    private int num = 1;

    void Update()
    {
        var pos = transform.position;

        transform.Translate(new Vector2(0, num) * Time.deltaTime * 1.2f);

        if (pos.y > 17f)
        {
            num = -1;
        }
        else if (pos.y < 10.7f)
        {
            num = 1;
        }
    }
}
