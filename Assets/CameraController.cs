using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Référence publique à l'objet que la caméra doit suivre
    public GameObject SphereCochonet;

    // Variable privée pour stocker l'offset initial entre la caméra et l'objet
    private Vector3 offset;

    // Stocke l'orientation initiale de la caméra
    private Quaternion initialRotation;

    // Start est appelé avant la première frame
    void Start()
    {
        // Vérifie si l'objet est assigné pour éviter une erreur NullReferenceException
        if (SphereCochonet != null)
        {
            // Calcule l'offset initial entre la caméra et l'objet suivi
            offset = transform.position - SphereCochonet.transform.position;

            // Stocke l'orientation initiale de la caméra
            initialRotation = transform.rotation;
        }
        else
        {
            Debug.LogError("L'objet SphereCochonet n'est pas assigné dans le script CameraController !");
        }
    }

    // LateUpdate est appelé après que tous les objets aient été mis à jour
    void LateUpdate()
    {
        // Assure que l'objet est assigné avant de suivre sa position
        if (SphereCochonet != null) 
        {
            // Met à jour la position de la caméra pour suivre l'objet
            transform.position = SphereCochonet.transform.position + offset;

            // Maintient l'orientation initiale de la caméra
            transform.rotation = initialRotation;
        }
    }
}
