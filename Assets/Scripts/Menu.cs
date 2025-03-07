using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button iniciar;

    public Button fechar;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        iniciar.onClick.AddListener(ComecaJogo);

        fechar.onClick.AddListener(FechaJogo);
    }

    void ComecaJogo()
    {
        SceneManager.LoadScene("FPS");
    }


    void FechaJogo()
    {
        Application.Quit();
    }
}