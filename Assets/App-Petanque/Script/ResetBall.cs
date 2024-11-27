using UnityEngine;

public class Resetball : MonoBehaviour
{
    // Références aux boules de pétanque
    [SerializeField] private GameObject petanqueBall1;
    [SerializeField] private GameObject petanqueBall2;
    [SerializeField] private GameObject petanqueBall3;

    // Références aux cylindres
    [SerializeField] private GameObject cylinder1;
    [SerializeField] private GameObject cylinder2;
    [SerializeField] private GameObject cylinder3;
    [SerializeField] private GameObject cylinder4;
    [SerializeField] private GameObject cylinder5;
    [SerializeField] private GameObject cylinder6;

    // Références aux cylindres
    [SerializeField] private GameObject cochonette;

    // Stockage des positions initiales des boules
    private Vector3 initialPosition1;
    private Vector3 initialPosition2;
    private Vector3 initialPosition3;

    // Stockage des positions initiales des cylindres
    private Vector3 initialPositionCylinder1;
    private Vector3 initialPositionCylinder2;
    private Vector3 initialPositionCylinder3;
    private Vector3 initialPositionCylinder4;
    private Vector3 initialPositionCylinder5;
    private Vector3 initialPositionCylinder6;

    private Vector3 initialPositioncochonette;

    void Start()
    {
        Debug.Log("Le jeu a démarré !");

        // Stocke la position initiale des boules
        if (petanqueBall1 != null) initialPosition1 = petanqueBall1.transform.position;
        if (petanqueBall2 != null) initialPosition2 = petanqueBall2.transform.position;
        if (petanqueBall3 != null) initialPosition3 = petanqueBall3.transform.position;

        // Stocke la position initiale des cylindres
        if (cylinder1 != null) initialPositionCylinder1 = cylinder1.transform.position;
        if (cylinder2 != null) initialPositionCylinder2 = cylinder2.transform.position;
        if (cylinder3 != null) initialPositionCylinder3 = cylinder3.transform.position;
        if (cylinder4 != null) initialPositionCylinder4 = cylinder4.transform.position;
        if (cylinder5 != null) initialPositionCylinder5 = cylinder5.transform.position;
        if (cylinder6 != null) initialPositionCylinder6 = cylinder6.transform.position;

        if (cochonette != null) initialPositioncochonette = cochonette.transform.position;
    }

    // Méthode pour réinitialiser les positions des boules et des cylindres
    public void ResetToInitialPositions()
    {
        Debug.Log("Réinitialisation des objets...");

        // Réinitialisation des boules de pétanque
        if (petanqueBall1 != null) petanqueBall1.transform.position = initialPosition1;
        if (petanqueBall2 != null) petanqueBall2.transform.position = initialPosition2;
        if (petanqueBall3 != null) petanqueBall3.transform.position = initialPosition3;

        // Réinitialisation des cylindres
        if (cylinder1 != null) cylinder1.transform.position = initialPositionCylinder1;
        if (cylinder2 != null) cylinder2.transform.position = initialPositionCylinder2;
        if (cylinder3 != null) cylinder3.transform.position = initialPositionCylinder3;
        if (cylinder4 != null) cylinder4.transform.position = initialPositionCylinder4;
        if (cylinder5 != null) cylinder5.transform.position = initialPositionCylinder5;
        if (cylinder6 != null) cylinder6.transform.position = initialPositionCylinder6;

        if (cochonette != null) cochonette.transform.position = initialPositioncochonette;
    }
}
