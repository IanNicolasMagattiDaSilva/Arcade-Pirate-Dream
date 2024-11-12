using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirObjeto : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.gameObject.tag == "Fruta")
        {
            Destroy(other.gameObject);
        }        
        if (other.gameObject.tag == "Bomba")
        {
            Destroy(other.gameObject);
        }
    }
}
