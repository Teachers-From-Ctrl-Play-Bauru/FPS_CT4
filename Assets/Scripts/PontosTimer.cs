using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PontosTimer : MonoBehaviour
{
    public Text pontuacao;
    private int pontos = 0;

    public Text timer;
    public float tempo = 10.0f;

    void Update()
    {
        pontuacao.text = "Pontos: " + pontos;

        tempo -= Time.deltaTime;
        timer.text = "Tempo:" + Mathf.RoundToInt(tempo);

        if (tempo <= 0.0f){

            SceneManager.LoadScene("Menu");
        }
    }

    public void AumentaPontuacao()
    {
        pontos++;
    }
}




