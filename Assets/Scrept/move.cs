using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    Rigidbody2D rb;
    Animator playerAnim;
    float moveSpeed = 5f; // Velocidade de movimento do personagem
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
        playerAnim.SetBool("isJump", true); // Ativar a anima��o de pulo
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

            playerAnim.SetBool("isJump", !isGrounded); // Desativar a anima��o de pulo se estiver no ch�o
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
        FuncaoSetaEsquerda(); // Fun��o associada � tecla de seta para a esquerda
    }
    else if (Keyboard.current.rightArrowKey.isPressed)
    {            
        FuncaoSetaDireita(); // Fun��o associada � tecla de seta para a direita
    }
    else if (Keyboard.current.upArrowKey.isPressed)
    {
        FuncaoSetaCima(); // Fun��o associada � tecla de seta para cima
    }
    else if (Keyboard.current.spaceKey.isPressed)
    {
        FuncaoBarraEspaco(); // Fun��o associada � tecla de espa�o
    }

}


void inMove(InputValue value)
{
    moveInput = value.Get<Vector2>();
}
void Run()
{
    // L�gica de movimenta��o do personagem
    Vector2 playerSpeed = new Vector2(moveInput.x * speed, rb.velocity.y);
    rb.velocity = playerSpeed;

    bool playerHasXSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
    playerAnim.SetBool("isRun", playerHasXSpeed);
}

void FuncaoSetaEsquerda()
{
    // A��o associada � tecla de seta para a esquerda
    Debug.Log("Fun��o para a seta esquerda.");
}

void FuncaoSetaDireita()
{
    // A��o associada � tecla de seta para a direita
    Debug.Log("Fun��o para a seta direita.");
    Run(); // Chama a fun��o para executar o personagem


}

void FuncaoSetaCima()
{
    // A��o associada � tecla de seta para cima
    Debug.Log("Fun��o para a seta para cima.");
}

void FuncaoBarraEspaco()
{
    // A��o associada � tecla de espa�o
    Debug.Log("Fun��o para a tecla de espa�o.");
}

void FlipSprit()
{
    // L�gica para virar o sprite
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