using UnityEngine;
using UnityEngine.InputSystem; // Assurez-vous d'inclure ce namespace

namespace UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Audio
{
    public class PetanqueBallResetter : MonoBehaviour
    {
        // Références aux objets 3D des boules de pétanque
        public GameObject petanqueBall1;
        public GameObject petanqueBall2;
        public GameObject petanqueBall3;

        // Positions initiales des boules de pétanque
        private Vector3 petanqueBall1InitialPos;
        private Vector3 petanqueBall2InitialPos;
        private Vector3 petanqueBall3InitialPos;

        // Référence à l'AudioSource (facultatif, si vous souhaitez jouer un son lors de la réinitialisation)
        [SerializeField]
        private AudioSource m_AudioSource;

        // Déclarez une action d'entrée pour capturer la touche 'R'
        private InputAction resetAction;

        private void Awake()
        {
            // Sauvegarde des positions initiales des boules
            petanqueBall1InitialPos = petanqueBall1.transform.position;
            petanqueBall2InitialPos = petanqueBall2.transform.position;
            petanqueBall3InitialPos = petanqueBall3.transform.position;

            // Initialisation de l'action de réinitialisation
            resetAction = new InputAction(binding: "<Keyboard>/r");
            resetAction.performed += _ => ResetPetanqueBalls(); // L'action se déclenche ici
        }

        private void OnEnable()
        {
            resetAction.Enable(); // Activer l'action
        }

        private void OnDisable()
        {
            resetAction.Disable(); // Désactiver l'action quand l'objet est désactivé
        }

        /// <summary>
        /// Réinitialise les boules de pétanque à leur position initiale.
        /// </summary>
        private void ResetPetanqueBalls()
        {
            // Réinitialisation des objets aux positions de départ
            if (petanqueBall1 != null)
                petanqueBall1.transform.position = petanqueBall1InitialPos;
            if (petanqueBall2 != null)
                petanqueBall2.transform.position = petanqueBall2InitialPos;
            if (petanqueBall3 != null)
                petanqueBall3.transform.position = petanqueBall3InitialPos;

            // Optionnel : jouer un son de réinitialisation si l'AudioSource est configuré
            if (m_AudioSource != null)
                m_AudioSource.PlayOneShot(m_AudioSource.clip); // Vous pouvez assigner le clip sonore ici
        }
    }
}
