using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelTransition : MonoBehaviour
{
    [SerializeField] private Animator Transition = null;
    [SerializeField] private AudioClip transitionAudio;
    [SerializeField] private string transitionEffectName;
    [SerializeField] private string levelStartPositionName;
    public static string levelPosition;
    [SerializeField] private string scene;
    [SerializeField] private float transitionTime;

    public static LevelTransition instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            levelPosition = levelStartPositionName;
            LevelLoad();
        }        
    }

    private void LevelLoad()
    {
        Transition.Play(transitionEffectName, 0, 0.0f);
        AudioManager.Instance.PlaySound(transitionAudio);

        StartCoroutine(wait());

        IEnumerator wait()
        {
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(scene);
            gameObject.SetActive(false);
        }
    }
}
