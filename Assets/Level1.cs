using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
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
        }
        else
        {
            ChangeCubeColor(defaultColor);
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
