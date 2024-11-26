using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderColorChecker : MonoBehaviour
{
    // Références aux cylindres
    public GameObject cylinder1;
    public GameObject cylinder2;
    public GameObject cylinder3;
    public GameObject cylinder4;
    public GameObject cylinder5;
    public GameObject cylinder6;

    // Références aux empty objects
    public GameObject nextGreen;
    public GameObject nextRed;

    // Couleur cible RGBA (0, 255, 20, 199)
    private Color targetColor = new Color(0f, 1f, 0.078f, 0.7803922f); // Normalisé en [0, 1]

    void Start()
    {
        // Vérifie que les références aux empty objects sont correctement assignées
        if (nextGreen == null || nextRed == null)
        {
            Debug.LogError("Assurez-vous d'assigner les objets Next-Green et Next-Red dans l'inspecteur.");
        }

        // Désactive les deux empty objects au début
        if (nextGreen != null) nextGreen.SetActive(false);
        if (nextRed != null) nextRed.SetActive(true);
    }

    void Update()
    {
        // Vérifie si tous les cylindres ont la couleur cible
        if (AreAllCylindersTargetColor())
        {
            // Affiche Next-Green et masque Next-Red
            if (nextGreen != null) nextGreen.SetActive(true);
            if (nextRed != null) nextRed.SetActive(false);
        }
        else
        {
            // Affiche Next-Red et masque Next-Green
            if (nextGreen != null) nextGreen.SetActive(false);
            if (nextRed != null) nextRed.SetActive(true);
        }
    }

    // Vérifie si tous les cylindres ont la couleur cible
    bool AreAllCylindersTargetColor()
    {
        return CheckCylinderColor(cylinder1) &&
               CheckCylinderColor(cylinder2) &&
               CheckCylinderColor(cylinder3) &&
               CheckCylinderColor(cylinder4) &&
               CheckCylinderColor(cylinder5) &&
               CheckCylinderColor(cylinder6);
    }

    // Vérifie la couleur d'un cylindre
    bool CheckCylinderColor(GameObject cylinder)
    {
        if (cylinder != null)
        {
            Renderer renderer = cylinder.GetComponent<Renderer>();
            if (renderer != null)
            {
                return renderer.material.color == targetColor;
            }
        }
        return false; // Retourne false si le cylindre ou son renderer est manquant
    }
}
