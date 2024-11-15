using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controlador : MonoBehaviour
{
    public TMP_Text placarTexto;
    public Transform brotador;
    public GameObject Gcoin,Scoin,Gdiamond,Bdiamond,Rdiamond, bomba;

    public float tempo;

    private int placar;

    void Start()
    {
        placar = 0;
        placarTexto.SetText(placar.ToString());
        StartCoroutine(AparecerObjetos());
    }

    public void EncostouBomba()
    {
        Debug.Log("Recomeçar jogo");
    }

    public void EncostouFruta()
    {
        placar += 1;
        placarTexto.SetText(placar.ToString());
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
            else if(item > 7f)
            {
                Instantiate(Rdiamond, new Vector3(posicao, brotador.position.y, 0), Quaternion.identity);
            }
            else if (item > 6f)
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
