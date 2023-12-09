using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    Rigidbody2D rb;
    Animator playerAnim;
    public float moveSpeed = 8f; // Velocidade de movimento do personagem
    float jumpForce = 10f; // For�a do pulo do personagem
    bool isGrounded = true; // Verifica se o personagem est� no ch�o

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        tesc(); // Chama a fun��o para verificar as teclas pressionadas
        AtualizarAnimacao();

    }

    // ... (seu c�digo anterior)

    void tesc()
    {
        Vector2 movement = Vector2.zero;

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            movement.x = -1; // Movimento para a esquerda
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            movement.x = 1; // Movimento para a direita
        }

        // Verifica se est� no ch�o e permite o pulo
        if (Keyboard.current.upArrowKey.wasPressedThisFrame && isGrounded)
        {
            Pular();
        }

        // Aplica o movimento horizontal ao Rigidbody
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    void Pular()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false; // Indica que o personagem est� no ar
    }

    void AtualizarAnimacao()
    {
        float move = rb.velocity.x;

        if (isGrounded)
        {
            if (move != 0) // Se estiver se movendo
            {
                if (move > 0) // Se estiver se movendo para a direita
                {
                    playerAnim.SetBool("isRunRight", true); // Ativar a anima��o de corrida para direita
                    playerAnim.SetBool("isRunLeft", false); // Desativar a anima��o de corrida para esquerda
                }
                else if (move < 0) // Se estiver se movendo para a esquerda
                {
                    playerAnim.SetBool("isRunLeft", true); // Ativar a anima��o de corrida para esquerda
                    playerAnim.SetBool("isRunRight", false); // Desativar a anima��o de corrida para direita
                }
            }
            else // Se n�o estiver se movendo
            {
                playerAnim.SetBool("isRunRight", false); // Desativar a anima��o de corrida para direita
                playerAnim.SetBool("isRunLeft", false); // Desativar a anima��o de corrida para esquerda
            }

            playerAnim.SetBool("isJump", false); // Desativar a anima��o de pulo se estiver no ch�o
        }
        else // Se estiver no ar
        {
            playerAnim.SetBool("isJump", true); // Ativar a anima��o de pulo enquanto estiver no ar
            playerAnim.SetBool("isRunRight", false); // Desativar a anima��o de corrida para direita no ar
            playerAnim.SetBool("isRunLeft", false); // Desativar a anima��o de corrida para esquerda no ar
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // O personagem est� no ch�o
        }


    }


}