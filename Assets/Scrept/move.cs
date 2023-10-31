using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    Rigidbody2D rb;
    Animator playerAnim;
    float moveSpeed = 5f; // Velocidade de movimento do personagem
    float jumpForce = 10f; // Força do pulo do personagem
    bool isGrounded = true; // Verifica se o personagem está no chão

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        tesc(); // Chama a função para verificar as teclas pressionadas
        AtualizarAnimacao();

    }

    // ... (seu código anterior)

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

        // Verifica se está no chão e permite o pulo
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
        isGrounded = false; // Indica que o personagem está no ar
        playerAnim.SetBool("isJump", true); // Ativar a animação de pulo
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
                    playerAnim.SetBool("isRunRight", true); // Ativar a animação de corrida para direita
                    playerAnim.SetBool("isRunLeft", false); // Desativar a animação de corrida para esquerda
                }
                else if (move < 0) // Se estiver se movendo para a esquerda
                {
                    playerAnim.SetBool("isRunLeft", true); // Ativar a animação de corrida para esquerda
                    playerAnim.SetBool("isRunRight", false); // Desativar a animação de corrida para direita
                }
            }
            else // Se não estiver se movendo
            {
                playerAnim.SetBool("isRunRight", false); // Desativar a animação de corrida para direita
                playerAnim.SetBool("isRunLeft", false); // Desativar a animação de corrida para esquerda
            }

            playerAnim.SetBool("isJump", !isGrounded); // Desativar a animação de pulo se estiver no chão
        }
        else // Se estiver no ar
        {
            playerAnim.SetBool("isJump", true); // Ativar a animação de pulo enquanto estiver no ar
            playerAnim.SetBool("isRunRight", false); // Desativar a animação de corrida para direita no ar
            playerAnim.SetBool("isRunLeft", false); // Desativar a animação de corrida para esquerda no ar
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // O personagem está no chão
        }

     
    }


}


/*




CapsuleCollider2D playerColl;
Vector2 moveInput;
float speed = 8f;
// float jumpForce = 8f;
//string split = null;

void Start()
{
    rb = GetComponent<Rigidbody2D>();
    playerAnim = GetComponent<Animator>();
    playerColl = GetComponent<CapsuleCollider2D>();
}

void Update()
{
    tesc();
    Run();
    FlipSprit();
}

void tesc() 
{
    if (Keyboard.current.leftArrowKey.isPressed)
    {
        FuncaoSetaEsquerda(); // Função associada à tecla de seta para a esquerda
    }
    else if (Keyboard.current.rightArrowKey.isPressed)
    {            
        FuncaoSetaDireita(); // Função associada à tecla de seta para a direita
    }
    else if (Keyboard.current.upArrowKey.isPressed)
    {
        FuncaoSetaCima(); // Função associada à tecla de seta para cima
    }
    else if (Keyboard.current.spaceKey.isPressed)
    {
        FuncaoBarraEspaco(); // Função associada à tecla de espaço
    }

}


void inMove(InputValue value)
{
    moveInput = value.Get<Vector2>();
}
void Run()
{
    // Lógica de movimentação do personagem
    Vector2 playerSpeed = new Vector2(moveInput.x * speed, rb.velocity.y);
    rb.velocity = playerSpeed;

    bool playerHasXSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
    playerAnim.SetBool("isRun", playerHasXSpeed);
}

void FuncaoSetaEsquerda()
{
    // Ação associada à tecla de seta para a esquerda
    Debug.Log("Função para a seta esquerda.");
}

void FuncaoSetaDireita()
{
    // Ação associada à tecla de seta para a direita
    Debug.Log("Função para a seta direita.");
    Run(); // Chama a função para executar o personagem


}

void FuncaoSetaCima()
{
    // Ação associada à tecla de seta para cima
    Debug.Log("Função para a seta para cima.");
}

void FuncaoBarraEspaco()
{
    // Ação associada à tecla de espaço
    Debug.Log("Função para a tecla de espaço.");
}

void FlipSprit()
{
    // Lógica para virar o sprite
    float positx = (Mathf.Sign(rb.velocity.x)) * 8f;
    float posity = 8f;

    bool playerHasXSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
    if (playerHasXSpeed)
    {
        transform.localScale = new Vector2(posity, posity);
    }
}
}
*/