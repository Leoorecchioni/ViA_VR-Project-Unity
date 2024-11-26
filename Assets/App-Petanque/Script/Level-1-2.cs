using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level12 : MonoBehaviour
{
    // Références directes aux objets spécifiques
    public GameObject petanqueBall1;
    public GameObject petanqueBall2;
    public GameObject petanqueBall3;

    // Liste des objets actuellement dans la zone
    private List<GameObject> objectsInZone = new List<GameObject>();

    // Matériau du cube (pour changer la couleur)
    private Renderer cubeRenderer;

    // Couleur à appliquer lorsque la condition est remplie
    public Color targetColor = Color.green;

    // Couleur par défaut du cube
    private Color defaultColor;

    // AudioSource pour jouer le son
    public AudioSource audioSource;

    // Indicateur pour savoir si le son a été joué
    private bool soundPlayed = false;

    // Références pour Next-Green et Next-Red
    public GameObject nextGreen;
    public GameObject nextRed;

    void Start()
    {
        // Récupère le Renderer du cube pour changer sa couleur
        cubeRenderer = GetComponent<Renderer>();

        // Sauvegarde la couleur par défaut du cube
        if (cubeRenderer != null)
        {
            defaultColor = cubeRenderer.material.color;
        }
        else
        {
            Debug.LogError("Aucun Renderer trouvé sur le Cube !");
        }

        // Vérifie que l'AudioSource est attachée
        if (audioSource == null)
        {
            Debug.LogError("Aucun AudioSource trouvé ! Assurez-vous de l'attacher au script.");
        }

        // Vérifie que les objets Next-Green et Next-Red sont assignés
        if (nextGreen == null || nextRed == null)
        {
            Debug.LogError("Assurez-vous d'assigner les objets Next-Green et Next-Red dans l'inspecteur.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant est une des PetanqueBalls
        if (other.gameObject == petanqueBall1 || other.gameObject == petanqueBall2 || other.gameObject == petanqueBall3)
        {
            // Ajoute l'objet à la liste s'il n'est pas déjà dedans
            if (!objectsInZone.Contains(other.gameObject))
            {
                objectsInZone.Add(other.gameObject);
                CheckObjectsInZone();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Vérifie si l'objet sortant est une des PetanqueBalls
        if (other.gameObject == petanqueBall1 || other.gameObject == petanqueBall2 || other.gameObject == petanqueBall3)
        {
            // Retire l'objet de la liste
            if (objectsInZone.Contains(other.gameObject))
            {
                objectsInZone.Remove(other.gameObject);
                CheckObjectsInZone();
            }
        }
    }

    void CheckObjectsInZone()
    {
        // Vérifie si les trois PetanqueBalls sont dans la zone
        if (objectsInZone.Contains(petanqueBall1) && 
            objectsInZone.Contains(petanqueBall2) && 
            objectsInZone.Contains(petanqueBall3))
        {
            ChangeCubeColor(targetColor);

            // Joue le son si ce n'est pas déjà fait
            if (!soundPlayed && audioSource != null)
            {
                audioSource.Play();
                soundPlayed = true;
            }

            // Rendre Next-Green visible et Next-Red invisible
            if (nextGreen != null) nextGreen.SetActive(true);
            if (nextRed != null) nextRed.SetActive(false);
        }
        else
        {
            ChangeCubeColor(defaultColor);
            soundPlayed = false; // Réinitialise l'indicateur pour rejouer le son si nécessaire

            // Rendre Next-Red visible et Next-Green invisible
            if (nextGreen != null) nextGreen.SetActive(false);
            if (nextRed != null) nextRed.SetActive(true);
        }
    }

    void ChangeCubeColor(Color newColor)
    {
        if (cubeRenderer != null)
        {
            cubeRenderer.material.color = newColor;
        }
    }
}
