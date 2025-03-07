using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma : MonoBehaviour
{
    Image arma;
    public Sprite novoSprite;
    public Sprite antigoSprite;

    
    void Start(){

        arma = GameObject.Find("Gun").GetComponent<Image>();
    }

    public void Atira(){

        arma.sprite = novoSprite;
    }

    public void VoltaTiro(){

        arma.sprite = antigoSprite;
    }
}