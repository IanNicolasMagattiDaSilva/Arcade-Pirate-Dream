using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controlador : MonoBehaviour
{
    public TMP_Text placarTexto;
    public Transform brotador;
    public GameObject fruta, bomba;

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
            float item = Random.Range(0,1);
            if (item > 0.8f)
            {
                Instantiate(bomba, new Vector3(posicao, brotador.position.y, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(fruta, new Vector3(posicao, brotador.position.y, 0), Quaternion.identity);
            }
        }
    }
}
