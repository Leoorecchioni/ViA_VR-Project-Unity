using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateScriptOnCollisionWithDelay : MonoBehaviour
{
    // Références aux objets
    public GameObject cochonette;
    public GameObject gamezone;

    // Script à activer
    public MonoBehaviour scriptToActivate;

    // Temps d'attente avant l'activation
    public float delay = 3f;

    // Flag pour éviter des activations multiples
    private bool isActivated = false;

    // Méthode pour charger la scène (recharger la scène)
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnEnable()
    {
        // Réinitialiser les états et références lors du rechargement de la scène
        if (scriptToActivate != null)
        {
            scriptToActivate.enabled = false;  // Désactiver le script au démarrage
        }
        else
        {
            Debug.LogError("Script to activate is not assigned. Assign it in the Inspector.");
        }

        isActivated = false;  // Réinitialiser le flag
    }

    private void Start()
    {
        // Désactiver le script cible au démarrage
        if (scriptToActivate != null)
        {
            scriptToActivate.enabled = false;
        }
        else
        {
            Debug.LogError("Script to activate is not assigned. Assign it in the Inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'objet qui entre est la cochonette et si la zone de jeu est valide
        if (other.gameObject == cochonette && !isActivated)
        {
            Debug.Log("Cochonette entered gamezone. Starting delay...");
            isActivated = true; // Éviter une activation multiple

            // Démarrer la coroutine pour activer le script avec un délai
            StartCoroutine(ActivateScriptAfterDelay());
        }
    }

    private System.Collections.IEnumerator ActivateScriptAfterDelay()
    {
        // Attendre le délai spécifié
        yield return new WaitForSeconds(delay);

        // Activer le script
        if (scriptToActivate != null)
        {
            Debug.Log("Activating script after delay.");
            scriptToActivate.enabled = true;
        }
    }
}
