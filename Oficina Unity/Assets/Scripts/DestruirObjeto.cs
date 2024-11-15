using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestruirObjeto : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            Animator anim = other.gameObject.GetComponent<Animator>();
            Cair cair = other.gameObject.GetComponent<Cair>();
            Debug.Log(other.name);
            cair.velocidade = 0;
            if (other.gameObject.tag == "Fruta")
            {
                anim.SetBool("explode", true);
                StartCoroutine(TimeToDestroy(0.25f, other));
            }
            if (other.gameObject.tag == "Bomba")
            {
                anim.SetBool("explode", true);
                StartCoroutine(TimeToDestroy(0.5f, other));
            }
        }
    }
    IEnumerator TimeToDestroy(float s, Collider2D other)
    {
        yield return new WaitForSeconds(s);
        Destroy(other.gameObject);
        yield return null;
    }
}
