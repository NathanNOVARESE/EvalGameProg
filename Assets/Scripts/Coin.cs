using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 1;
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private float soundVolume = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        
        // Gestion du score
        try 
        {
            GameManager.Instance?.AddScore(value);
        }
        catch (System.NullReferenceException)
        {
            Debug.LogWarning("GameManager non trouvé, mais pièce collectée");
        }

        // Gestion du son
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position, soundVolume);
        }
        else
        {
            Debug.LogWarning("Aucun son assigné pour la pièce");
        }

        Destroy(gameObject);
    }
}