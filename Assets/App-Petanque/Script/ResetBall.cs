using UnityEngine;

public class Resetball : MonoBehaviour
{
    [SerializeField] private GameObject petanqueBall1;
    [SerializeField] private GameObject petanqueBall2;
    [SerializeField] private GameObject petanqueBall3;

    private Vector3 initialPosition1;
    private Vector3 initialPosition2;
    private Vector3 initialPosition3;

    void Start()
    {
        Debug.Log("Le jeu a démarré !");
        // Stocke la position de départ des objets
        if (petanqueBall1 != null) initialPosition1 = petanqueBall1.transform.position;
        if (petanqueBall2 != null) initialPosition2 = petanqueBall2.transform.position;
        if (petanqueBall3 != null) initialPosition3 = petanqueBall3.transform.position;
    }

    // Méthode pour réinitialiser les positions
    public void ResetToInitialPositions()
    {
        Debug.Log("Le jeu a démarré !");
        if (petanqueBall1 != null) petanqueBall1.transform.position = initialPosition1;
        if (petanqueBall2 != null) petanqueBall2.transform.position = initialPosition2;
        if (petanqueBall3 != null) petanqueBall3.transform.position = initialPosition3;
    }
}
