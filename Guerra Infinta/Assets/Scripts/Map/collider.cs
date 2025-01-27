using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collider : MonoBehaviour
{
    bool verificar = true;
    IEnumerator Espera()
    {
        //Debug.Log("Delay");
        yield return new WaitForSeconds(0.1f);
        verificar = true;
    }

    private void OnTriggerStay2D(Collider2D Player)
    {
        if (verificar)
        {
            // Verifica se o jogador está pressionando as teclas de movimento
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                verificar = false;

                Debug.Log("Está mexendo na area do inimigo");

                // Chance de ocorrer o encontro com inimigo
                if (Random.Range(0, 100) >= 95)
                {
                    SceneManager.LoadScene("Scene2");
                }

                StartCoroutine(Espera());
            }

            else
            {
                verificar = true;
            }
        }
    }
}
