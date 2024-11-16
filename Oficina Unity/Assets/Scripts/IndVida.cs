using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IndVida : MonoBehaviour
{
    public ControleJogador Jogador;
    public float length, starPos;
    public GameObject vida;
    public int vidaAtual;
    public List<GameObject> Vidas = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        starPos = transform.position.x;
        length = vida.GetComponent<SpriteRenderer>().bounds.size.x;
        PrintVida();
        vidaAtual = Jogador.vida;
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaAtual > Jogador.vida)
        {
            Destroy(Vidas[vidaAtual-1]);
            vidaAtual = Jogador.vida;
        }
    }
    void PrintVida()
    {
        int i = 0;
        for(i = 0; i< Jogador.vida; i++)
        {
            Vidas.Add(Instantiate(vida, new Vector3(starPos + (i * length), transform.position.y, 0), Quaternion.identity));
        }
        
    }
}
