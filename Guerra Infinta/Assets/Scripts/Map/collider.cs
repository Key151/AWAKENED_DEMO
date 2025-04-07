using System.Collections;
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

    private void Encount(){
        // Chance de ocorrer o encontro com inimigo
        if (Random.Range(0, 100) >= 95)
        {
            SceneManager.LoadScene("Scene2");
        }
    }

    private void OnTriggerStay2D(Collider2D Player)
    {
        if (verificar)
        {
            // Verifica se o jogador est� pressionando as teclas de movimento
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                verificar = false;
                Debug.Log("Estao mexendo na area do inimigo");
                Encount();
                StartCoroutine(Espera());
            }

            else
            {
                verificar = true;
            }
        }
    }
}
