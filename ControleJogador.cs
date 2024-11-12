using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogador : MonoBehaviour
{
    public float velocidade;
    public Controlador controlador;

    private float movimento;

    // Update is called once per frame
    void Update()
    {
        movimento = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * movimento * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fruta")
        {
            controlador.EncostouFruta();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Bomba")
        {
            controlador.EncostouBomba();
            Destroy(other.gameObject);
        }
    }
}
