using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private Renderer rend;
    private Material mat;
    private float offset;
    public float velocidade;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += 1;
        mat.SetTextureOffset( "_MainTex", new Vector2((offset*velocidade/1000),0 ) );
    }
}
