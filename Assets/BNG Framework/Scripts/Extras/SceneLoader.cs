using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BNG {
    public class SceneLoader : MonoBehaviour {

        [Tooltip("The Unity 'LoadSceneMode' method of loading the scene (In most cases should be 'Single').")]
        public LoadSceneMode loadSceneMode = LoadSceneMode.Single;

        [Tooltip("If true, the ScreenFader component will fade the screen to black before loading a level.")]
        public bool UseScreenFader = true;

        [Tooltip("Wait this long in seconds before attempting to load the scene. Useful if you need to fade the screen out before attempting to load the level.")]
        public float ScreenFadeTime = 0.5f;

        private ScreenFader sf;
        private string _loadSceneName = string.Empty;

        /// <summary>
        /// Load a new scene by name.
        /// </summary>
        /// <param name="sceneName">Name of the scene to load</param>
        public void LoadScene(string sceneName) {
            if (string.IsNullOrWhiteSpace(sceneName)) {
                Debug.LogError("SceneLoader: Cannot load scene. Scene name is null or empty.");
                return;
            }

            _loadSceneName = sceneName;

            if (UseScreenFader) {
                StartCoroutine(nameof(FadeThenLoadScene));
            } else {
                SceneManager.LoadScene(_loadSceneName, loadSceneMode);
            }
        }

        /// <summary>
        /// Fade the screen out before loading the scene.
        /// </summary>
        private IEnumerator FadeThenLoadScene() {
            // Try to find the ScreenFader if it hasn't been assigned
            if (UseScreenFader && sf == null) {
                sf = FindObjectOfType<ScreenFader>();

                if (sf == null) {
                    Debug.LogWarning("SceneLoader: ScreenFader component not found in the scene. Skipping fade effect.");
                } else {
                    sf.DoFadeIn();
                }
            }

            // Wait for the fade to complete
            if (ScreenFadeTime > 0) {
                yield return new WaitForSeconds(ScreenFadeTime);
            }

            // Load the scene
            SceneManager.LoadScene(_loadSceneName, loadSceneMode);
        }
    }
}
