using UnityEngine;

public class CheckGround : MonoBehaviour
{
    // Define una variable estática pública tipo bool llamada isGrounded. 
    // Al ser estática, puede ser accedida desde cualquier otro script como CheckGround.isGrounded.
    // Representa si el objeto (normalmente un personaje) está tocando el suelo.
    public static bool isGrounded;
    // Método que se ejecuta automáticamente cuando otro collider entra en el trigger de este objeto.
    // Se utiliza para detectar cuándo el personaje está tocando el suelo.
    private void OnTriggerEnter2D(Collider2D collision)
    {   // Cambia la variable isGrounded a true, indicando que el personaje está en el suelo.
        isGrounded = true;
    }
    // Método que se ejecuta automáticamente cuando otro collider sale del trigger de este objeto.
    private void OnTriggerExit2D(Collider2D collision)
    {   // Cambia la variable isGrounded a false, indicando que el personaje ya no está en el suelo.
        isGrounded = false;
    }

}
