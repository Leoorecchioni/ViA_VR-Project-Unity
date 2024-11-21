using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderColorChanger : MonoBehaviour
{
    // Couleurs pour les différents états
    public Color defaultColor = Color.white;
    public Color alertColor = Color.red;

    // Renderer du cylindre
    private Renderer cylinderRenderer;

    // AudioSource pour jouer le son
    public AudioSource audioSource;

    // Indicateur pour savoir si le son est en cours de lecture
    private bool soundPlayed = false;

    void Start()
    {
        // Récupère le Renderer du cylindre
        cylinderRenderer = GetComponent<Renderer>();
        if (cylinderRenderer == null)
        {
            Debug.LogError("Renderer non trouvé sur l'objet !");
        }

        // Vérifie que l'AudioSource est attachée
        if (audioSource == null)
        {
            Debug.LogError("Aucun AudioSource trouvé ! Assurez-vous de l'attacher au script.");
        }

        // Initialise avec la couleur par défaut
        ChangeColor(defaultColor);
    }

    void Update()
    {
        // Récupère les rotations sur X et Z
        float rotationX = NormalizeAngle(transform.eulerAngles.x);
        float rotationZ = NormalizeAngle(transform.eulerAngles.z);

        // Vérifie si X ou Z est hors des limites
        if (Mathf.Abs(rotationX) > 60 || Mathf.Abs(rotationZ) > 60)
        {
            ChangeColor(alertColor);
            PlaySound();
        }
        else
        {
            ChangeColor(defaultColor);
            StopSound();
        }
    }

    // Change la couleur du cylindre
    void ChangeColor(Color newColor)
    {
        if (cylinderRenderer != null)
        {
            cylinderRenderer.material.color = newColor;
        }
    }

    // Normalise un angle pour qu'il soit entre -180 et 180
    float NormalizeAngle(float angle)
    {
        if (angle > 180)
            angle -= 360;
        return angle;
    }

    // Joue le son si ce n'est pas déjà en cours
    void PlaySound()
    {
        if (!soundPlayed && audioSource != null)
        {
            audioSource.Play();
            soundPlayed = true;
        }
    }

    // Arrête le son si nécessaire
    void StopSound()
    {
        if (soundPlayed && audioSource != null)
        {
            audioSource.Stop();
            soundPlayed = false;
        }
    }
}
