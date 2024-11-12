using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cair : MonoBehaviour
{
    public float velocidade;

    void Update()
    {
        transform.Translate(Vector2.up * -1 * velocidade * Time.deltaTime);
    }
}
