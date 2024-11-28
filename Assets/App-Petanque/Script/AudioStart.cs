using UnityEngine;

public class PlayAudioOnClick : MonoBehaviour
{
    public AudioClip audioClip;  // Le clip audio à jouer
    private AudioSource audioSource;  // Référence à l'AudioSource

    // Cette méthode est appelée lors du clic sur le bouton
    public void PlayAudio()
    {
        // Si l'AudioSource n'est pas encore initialisée, on la récupère
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Vérifie si l'AudioSource est désactivée et l'active si nécessaire
        if (audioSource != null)
        {
            if (!audioSource.isActiveAndEnabled)
            {
                audioSource.gameObject.SetActive(true);  // Active l'objet contenant l'AudioSource
            }

            // Joue le son uniquement si un clip audio est assigné
            if (audioClip != null)
            {
                audioSource.PlayOneShot(audioClip);  // Joue le clip audio une seule fois
            }
        }
        else
        {
            Debug.LogWarning("AudioSource n'est pas attaché à l'objet !");
        }
    }
}
