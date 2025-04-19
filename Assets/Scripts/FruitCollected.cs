using UnityEngine;

public class FruitCollected : MonoBehaviour
{
    private FruitManager fruitManager; // Referencia al script FruitManager

    void Start()
    {
        // Busca el primer objeto del tipo FruitManager (reemplazo moderno y seguro)
        fruitManager = FindFirstObjectByType<FruitManager>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colisionó tiene el tag "Player"
        if (collision.CompareTag("Player"))
        {
            // Oculta el sprite de la fruta
            GetComponent<SpriteRenderer>().enabled = false;

            // Activa un hijo del objeto fruta (por ejemplo, una animación o efecto)
            transform.GetChild(0).gameObject.SetActive(true);

            // Llama al método que verifica si todas las frutas han sido recolectadas
            fruitManager.AllFruitsCollected();

            // Destruye esta fruta después de 0.5 segundos
            Destroy(gameObject, 0.5f);
        }
    }
}
