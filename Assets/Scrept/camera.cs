using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camera : MonoBehaviour
{

    void Update()
    {

    }





}



/*public class camera : MonoBehaviour
{
    public Transform jogador; // Refer�ncia ao objeto do jogador
    public float offsetY = 1.3f; // Offset na posi��o Y da c�mera

    void Update()
    {
        if (jogador != null)
        {
            // Obt�m a posi��o atual do jogador
            Vector3 posicaoJogador = jogador.position;

            // Ajusta a posi��o Y da c�mera
            posicaoJogador.y += offsetY;

            // Mant�m a mesma posi��o Z da c�mera
            posicaoJogador.z = transform.position.z;

            // Define a posi��o da c�mera para a posi��o ajustada
            transform.position = posicaoJogador;
        }
    }
}


/* public Transform jogador; // Refer�ncia ao objeto do jogador
    public float offsetY = 1.3f; // Offset na posi��o Y da c�mera
    public float suavizacao = 5.0f; // Fator de suaviza��o

    void Update()
    {
        if (jogador != null)
        {
            // Obt�m a posi��o atual do jogador
            Vector3 posicaoJogador = jogador.position;

            // Ajusta a posi��o Y da c�mera
            posicaoJogador.y += offsetY;

            // Mant�m a mesma posi��o Z da c�mera
            posicaoJogador.z = transform.position.z;

            // Aplica a interpola��o suave (lerp) para suavizar o movimento da c�mera
            transform.position = Vector3.Lerp(transform.position, posicaoJogador, suavizacao * Time.deltaTime);
        }
    }*/