using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance => _instance;
    List<Pin> pinsLeft;

    [SerializeField] TMPro.TextMeshProUGUI victoryText;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        pinsLeft = new(FindObjectsOfType<Pin>());
    }

    public void PinFell(Pin pin)
    {
        pinsLeft.Remove(pin);

        Debug.Log("Pin fell: " + pin.gameObject.name);

        if (pinsLeft.Count == 0)
        {
            Victory();
        }
    }

    void Victory()
    {
        victoryText.gameObject.SetActive(true);

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        Invoke(nameof(RestartGame), audioSource.clip.length + 2f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
