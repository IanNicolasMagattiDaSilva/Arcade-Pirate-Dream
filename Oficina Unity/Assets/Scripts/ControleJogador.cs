using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogador : MonoBehaviour
{
    public float velocidade;
    public Controlador controlador;
    public Animator anim;
    float fator = 0;
    private float movimento;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        movimento = Input.GetAxis("Horizontal");
        
        if (movimento != 0)
        {
            anim.SetBool("Move", true);
            if(movimento > 0)
            {
                transform.eulerAngles = Vector3.zero;
                fator = 1;
            }
            else
            {
                transform.eulerAngles = new Vector3(0f,180f,0f);
                fator = -1;
            }
            transform.Translate(Vector2.right * movimento * velocidade * fator * Time.deltaTime);
        }
        else
        {
            anim.SetBool("Move", false);
        }

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
