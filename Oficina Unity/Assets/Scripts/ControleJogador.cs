using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleJogador : MonoBehaviour
{
    public float velocidade;
    public Controlador controlador;
    public Animator anim;
    float fator = 0;
    public int vida;
    private float movimento;

    
    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine("MoveSet");
    }
    // Update is called once per frame
    void Update()
    {
        

    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            Animator animOther = other.gameObject.GetComponent<Animator>();
            Cair cair = other.gameObject.GetComponent<Cair>();
            Debug.Log(other.name);
            cair.velocidade = 0;
            if (other.gameObject.tag == "Fruta")
            {
                controlador.EncostouFruta();
                animOther.SetBool("effect", true);
                StartCoroutine(TimeToDestroy(0.25f, other));
            }
            else if (other.gameObject.tag == "Bomba")
            {
                vida -= 1;
                if( vida == 0 )
                {
                    anim.SetBool("Dead", true);
                    StartCoroutine(TimeToDestroy(0.5f, other));
                    StopAllCoroutines();
                }
                else
                {
                    animOther.SetBool("explode", true);
                    StartCoroutine("AnimHit");
                    StartCoroutine(TimeToDestroy(0.5f, other));
                }
                
            }
        }

    }


    IEnumerator TimeToDestroy(float s, Collider2D other)
    {
        yield return new WaitForSeconds(s);
        if(other != null)
        {
            Destroy(other.gameObject);
        }
        yield return null;
    }

    IEnumerator AnimHit()
    {
        anim.SetBool("Hit", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("Hit", false);
        yield return null;
    }
    IEnumerator AnimDie()
    {
        anim.SetBool("Hit", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("Hit", false);
        yield return null;
    }
    IEnumerator MoveSet()
    {
        while (true)
        {
            movimento = Input.GetAxis("Horizontal");

            if (movimento != 0)
            {
                anim.SetBool("Move", true);
                if (movimento > 0)
                {
                    transform.eulerAngles = Vector3.zero;
                    fator = 1;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
                    fator = -1;
                }
                transform.Translate(Vector2.right * movimento * velocidade * fator * Time.deltaTime);
            }
            else
            {
                anim.SetBool("Move", false);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
