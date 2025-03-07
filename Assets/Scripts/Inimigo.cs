using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public GameObject inimigo;
    public Transform respawn;
    public string nome;
    public Transform personagem;

    public Sprite inimigoIdle;
    public Sprite inimigoDead;
    public SpriteRenderer alien;

    //existem algumas formas diferentes de criar o spawn do inimigo nesse projeto. 
    //
    //1 - A maneira padrão que o código está trabalhando é criando um vetor aleatório (dentro de um espaço específico) de posição para
    //    que o inimigo apareça logo após ser destruído, isso valendo para todos os inimigos, de forma que para criar mais inimigos funcionais
    //    basta criar cópias de um inimigo. Essa maneira precisa de menos linhas no código para ser implementada, porém não possui uma
    //    organização bem definida de locais de spawn.

    //2 - A segunda maneira é criando uma lista de vetores que carregam a informação da posição de spawn e isso pode ser feito de duas formas:

    //    2.1 - A primeira forma de implementar a lista de posições de spawn é definindo os vetores de posição diretamente no script, 
    //          sendo necessário aumentar o código, mas em troca a mecânica do jogo fica mais previsível. Para implementar um exemplo dessa
    //          forma, você pode descomentar as linhas com a marcação "(2.1)" e comentar as linhas com a marcação "(2.1c)". É importante
    //          ressaltar que os vetores são carregados dentro dos scripts de cada inimigo, então com essa lógica é possível que os inimigos 
    //          surjam numa mesma posição eventualmente.
    //    2.2 - A segunda forma é muito similar à primeira, porém as posições para o spawn são referenciadas em objetos presentes em cena,
    //          mas depois a implementação da lista dentro do código é a mesma

    //List<Vector3> listaPosicoes = new List<Vector3>(); (2.1)
    
    //void Start(){ (2.1)

        //Vector3 vetorposicao1 = new Vector3(48.0f,1.5f,48.0f); (2.1)
        //Vector3 vetorposicao2 = new Vector3(-48.0f,1.5f,48.0f); (2.1)
        //Vector3 vetorposicao3 = new Vector3(48.0f,1.5f,-48.0f); (2.1)
        //Vector3 vetorposicao4 = new Vector3(-48.0f,1.5f,-48.0f); (2.1)
        //Vector3 vetorposicao5 = new Vector3(0f,1.5f,0f); (2.1)

        //listaPosicoes.Add(vetorposicao1); (2.1)
        //listaPosicoes.Add(vetorposicao2); (2.1)
        //listaPosicoes.Add(vetorposicao3); (2.1)
        //listaPosicoes.Add(vetorposicao3); (2.1)
        //listaPosicoes.Add(vetorposicao4); (2.1)
        //listaPosicoes.Add(vetorposicao5); (2.1)
    //} (2.1)

    public void Destroy_Respawn()
    {

        alien.sprite = inimigoDead;
        gameObject.GetComponent<MeshCollider>().enabled = false;
        //listaPosicoes.Add(respawn.position); (2.1)


        Invoke("Respawn", 0.5f);

    }
    

    void Update(){

        transform.LookAt(personagem);
        transform.Rotate(Vector3.right, 90);

    }

    public void Respawn(){

        gameObject.GetComponent<MeshCollider>().enabled = true;

        Destroy(inimigo);

        inimigo.name = nome;

        //Vector3 incremento = listaPosicoes[Random.Range(0,listaPosicoes.Count)]; (2.1)
        //listaPosicoes.Remove(incremento); (2.1)

        Vector3 incremento = new Vector3(Random.Range(-8f,8f),1.5f,Random.Range(-5f,5f)); //(2.1c)

        respawn.position = incremento;

        gameObject.GetComponent<Inimigo>().enabled = true;

        alien.sprite = inimigoIdle;

        Instantiate(inimigo, respawn.position, respawn.rotation);

    }
}
