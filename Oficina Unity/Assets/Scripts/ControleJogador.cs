using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleJogador : MonoBehaviour
{
    public float velocidade;
    public AudioSource audioSorce;
    public Controlador controlador;
    public BoxCollider2D col;
    public Animator anim, juice;
    float fator = 0;
    public int vida;
    private float movimento;
    public bool die = false;
    public AudioClip pointEffect;
    public AudioClip damageEffect;
    public SpriteRenderer spriteRenderer;
    public  void Start()
    {
        die = false;
        vida = 3;
        anim = GetComponent<Animator>();
        anim.SetBool("Dead", die);
        StartCoroutine("MoveSet");
        col = GetComponent<BoxCollider2D>();
        audioSorce = GetComponent<AudioSource>();
        
        
    }
    // Update is called once per frame
    void Update()
    {
        

    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0f, -3.03f, 0f);
    }
    public void ResetOrderLayer()
    {
        spriteRenderer.sortingLayerName = "Player";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && !die)
        {
            Animator animOther = other.gameObject.GetComponent<Animator>();
            Cair cair = other.gameObject.GetComponent<Cair>();
            cair.velocidade = 0;
            int pontos = 0;
            StartCoroutine(TimeToDestroy(0.5f, other));
            if (other.gameObject.tag == "Fruta")
            {
                switch(other.gameObject.name)
                {
                    case "SilverCoin(Clone)": pontos = 1; break;
                    case "Coin(Clone)": pontos = 5; break;
                    case "GreenDiamond(Clone)": pontos = 10; break;
                    case "BlueDiamond(Clone)": pontos = 25; break;
                    case "RedDiamond(Clone)": pontos = 50; break;
                }
                controlador.EncostouFruta(pontos);
                audioSorce.PlayOneShot(pointEffect);
                animOther.SetBool("effect", true);
                StartCoroutine(TimeToDestroy(0.25f, other));
            }
            else if (other.gameObject.tag == "Bomba")
            {
                controlador.EncostouBomba();
                vida -= 1;
                audioSorce.PlayOneShot(damageEffect);
                if ( vida == 0 )
                {
                    anim.SetBool("Dead", true);
                    die = true;
                    controlador.GameOverT();
                    controlador.GameOverF();
                    StopCoroutine("MoveSet");

                    juice.SetBool("Dead", true);
                }
                else
                {
                    animOther.SetBool("explode", true);
                    StartCoroutine("AnimHit");
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
    
    IEnumerator MoveSet()
    {
        while (!die)
        {
            movimento = Input.GetAxis("Horizontal");

            if (movimento != 0)
            {
                anim.SetBool("Move", true);
                juice.SetBool("Run", true);
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
                juice.SetBool("Run", false);
            }
            yield return new WaitForEndOfFrame();
        }
    }
    
}
