using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2; // Velocidad con la que el jugador se moverá horizontalmente. Es pública para poder modificarla desde el Inspector de Unity.
    public float jumpSpeed = 3; // Velocidad con la que el jugador saltará (aunque en este código aún no se usa).

    Rigidbody2D rb2D; // Variable para almacenar una referencia al componente Rigidbody2D del jugador.
    public bool betterJump = false; // Bandera que indica si se activará el salto mejorado.
    public float fallMultiplier = 0.5f; // Factor de multiplicación para hacer que las caídas sean más rápidas.
    public float lowJumpMultiplier = 1f; // Factor para reducir la altura del salto si se suelta el botón de salto antes de tiempo.
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    void Start() // Método llamado una vez al inicio del juego.
    {
        rb2D = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D del objeto al que está unido este script y lo guarda en la variable rb2D.
    }

    void FixedUpdate() // Método llamado a intervalos fijos, ideal para manejar física.
    {
        // Si se presiona la tecla "d" o la flecha derecha...
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            // ... se mueve al jugador hacia la derecha con la velocidad especificada en runSpeed.
            rb2D.linearVelocity = new Vector2(runSpeed, rb2D.linearVelocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        // Si se presiona la tecla "a" o la flecha izquierda...
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            // ... se mueve al jugador hacia la izquierda con la velocidad negativa.
            rb2D.linearVelocity = new Vector2(-runSpeed, rb2D.linearVelocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            // Si no se presiona ninguna tecla de movimiento horizontal, se detiene el movimiento horizontal.
            rb2D.linearVelocity = new Vector2(0, rb2D.linearVelocity.y);
            animator.SetBool("Run", false);
        }// Verifica si la tecla "espacio" está siendo presionada y esta tocando el suelo 
        if (Input.GetKey("space") && CheckGround.isGrounded)
        {// Si se cumple la condición, se aplica una velocidad vertical hacia arriba al Rigidbody2D
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpSpeed);
        }
        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);

        }

        if (betterJump)
        {
            // SALTO MEJORADO
            // Si el jugador está cayendo (velocidad vertical negativa)...
            if (rb2D.linearVelocity.y < 0)
            {
                // ...se incrementa la velocidad de caída usando el fallMultiplier.
                // Esto hace que la caída sea más rápida que el salto hacia arriba, creando un salto más "natural".
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            // Si el jugador está subiendo (velocidad positiva) y suelta la tecla de salto antes de tiempo...
            if (rb2D.linearVelocity.y > 0 && !Input.GetKey("space"))
            {
                // ...se reduce la velocidad del salto con lowJumpMultiplier.
                // Esto permite que si el jugador suelta el salto antes de tiempo, no llegue tan alto.
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }

        }


    }
}
