using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controlador : MonoBehaviour
{
    public TMP_Text placarTexto;
    public Transform brotador;
    private Animator anim;
    public GameObject Gcoin,Scoin,Gdiamond,Bdiamond,Rdiamond, bomba;

    public float tempo;

    private int placar;

    void Start()
    {
        anim = GetComponent<Animator>();
        placar = 0;
        placarTexto.SetText(placar.ToString());
        StartCoroutine(AparecerObjetos());
    }

    public void EncostouBomba()
    {
        anim.SetTrigger("Shake");
        Debug.Log("Recomeçar jogo");
    }

    public void EncostouFruta(int pontos)
    {
        placar += pontos;
        placarTexto.SetText(placar.ToString());
    }
    public void ExitGame()
    {
        Debug.Log("Saindo do Jogo");
        Application.Quit();
    }

    IEnumerator AparecerObjetos()
    {
        while (true)
        {
            yield return new WaitForSeconds(tempo);

            float posicao = Random.Range(-8f, 8f);
            float item = Random.Range(0,10);
            if (item > 8f)
            {
                Instantiate(bomba, new Vector3(posicao, brotador.position.y, 0), Quaternion.identity);
            }
            else if(item > 7.5f)
            {
                Instantiate(Rdiamond, new Vector3(posicao, brotador.position.y, 0), Quaternion.identity);
            }
            else if (item > 6.25f)
            {
                Instantiate(Bdiamond, new Vector3(posicao, brotador.position.y, 0), Quaternion.identity);
            }
            else if (item > 5f)
            {
                Instantiate(Gdiamond, new Vector3(posicao, brotador.position.y, 0), Quaternion.identity);
            }
            else if (item > 3f)
            {
                Instantiate(Gcoin, new Vector3(posicao, brotador.position.y, 0), Quaternion.identity);
            }
            else if (item > 0f)
            {
                Instantiate(Scoin, new Vector3(posicao, brotador.position.y, 0), Quaternion.identity);
            }
        }
    }
}
