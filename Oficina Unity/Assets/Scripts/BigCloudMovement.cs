using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCloudMovement : MonoBehaviour
{
    public GameObject[] clouds; // Array com as nuvens
    public float speed = 2f; // Velocidade de deslocamento
    public float cloudWidth; // Largura de cada nuvem (ajuste com base no tamanho real do sprite)
    public Camera mainCamera;
    public float offset;

    private void Start()
    {
        cloudWidth = clouds[0].GetComponent<SpriteRenderer>().bounds.size.x + offset;
        mainCamera = Camera.main;
    }

    void Update()
    {
        foreach (GameObject cloud in clouds)
        {
            // Move a nuvem para a esquerda
            cloud.transform.position += Vector3.left * speed * Time.deltaTime;

            // Reposiciona a nuvem quando ela sai da tela
            if (cloud.transform.position.x + 10 < -cloudWidth)
            {
                float newX = cloud.transform.position.x + (clouds.Length * cloudWidth);
                cloud.transform.position = new Vector3(newX, cloud.transform.position.y, cloud.transform.position.z);
            }
        }
    }
    // Função que verifica se a nuvem saiu da tela
    
}
