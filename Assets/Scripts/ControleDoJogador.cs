using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoJogador : MonoBehaviour
{

    //rotacao
    public float sensibilidadeMouse = 100f;
	public Transform jogador;
	float rotacaoX = 0f;

    //translacao
    public CharacterController controller; 
    public float velocidade = 4.0f;
    public float gravidade = -9.81f;
    Vector3 aceleracao;

    //animacao
    public GameObject arma;

    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }
    // Update is called once per frame
    void Update()
    {
        //animacao
        Arma scriptArma = GameObject.Find("Gun").GetComponent<Arma>();
        scriptArma.VoltaTiro();
        
        //rotacao
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse * Time.deltaTime;

		rotacaoX -= mouseY;
		rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f);

		transform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);
		jogador.Rotate(Vector3.up * mouseX);

        //translacao
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * velocidade * Time.deltaTime);

        aceleracao.y += gravidade * Time.deltaTime;
        controller.Move(aceleracao * Time.deltaTime);

        //tiro
        if (Input.GetMouseButtonDown(0)){


            scriptArma.Atira();

            Vector3 origem = transform.position;
            Vector3 direcao = transform.forward;
            Ray ray = new Ray(origem, direcao);

            RaycastHit informacao;
            bool hit = Physics.Raycast(ray, out informacao);

            

            if (informacao.collider.CompareTag("Enemy")){

                Inimigo script = informacao.collider.gameObject.GetComponent<Inimigo>();

                script.Destroy_Respawn();

                PontosTimer scriptPontos = GameObject.Find("Canvas").GetComponent<PontosTimer>();
                scriptPontos.AumentaPontuacao();
            }
        }
    }
}