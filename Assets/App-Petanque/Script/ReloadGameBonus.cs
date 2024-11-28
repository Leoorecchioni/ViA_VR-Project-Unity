using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour gérer les scènes

public class RestartScene : MonoBehaviour
{
    // Méthode pour relancer la scène
    public void ReloadScene()
    {
        // Récupérer le nom ou l'index de la scène actuelle
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Recharger la scène
        SceneManager.LoadScene(currentSceneName);
    }
}
