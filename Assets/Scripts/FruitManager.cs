using UnityEngine;

public class FruitManager : MonoBehaviour
{
    // Método que se llama para verificar si quedan frutas en la escena
    public void AllFruitsCollected()
    {
        // Si solo queda este GameObject (FruitManager), entonces ya no hay frutas hijas
        if (transform.childCount == 1)
        {
            Debug.Log("No quedan frutas, ¡Victoria!");
        }
    }
}
