using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class start_button : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject pumpkin;
    [SerializeField] private GameObject start;
    [SerializeField] private AudioClip Music;
    public UnityEvent enableUiElements;

    public void startbutton()
    {
        AudioManager.instance.PlayMusic(Music);
        MainCamera.SetActive(true);
        menu.SetActive(false);
        pumpkin.SetActive(true);
        start.SetActive(false);
        enableUiElements.Invoke();
    }   

    public void LoadScene()
    {
        SceneManager.LoadScene("L1");
    }
}
