using System.Collections;
using UnityEngine;
using TMPro;

public class Level_Start_Interiors : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelIntroDisplay;
    [SerializeField] private GameObject playerOBJ;
    [SerializeField] private GameObject introDisplayOBJ;
    private int positionSelect;
    [SerializeField] private Animator Transition = null;
    [SerializeField] private string transitionEffectName;
    [SerializeField] private Transform[] playerStartPosition;
    [SerializeField] private AudioClip TransitionSound;
    private string level;
    private Rigidbody rb;

    private void Awake()
    {
        rb = playerOBJ.GetComponent<Rigidbody>();
        level = LevelTransition.levelPosition;
    }
    void Start()
    {
        switch (level)
        {
            case "L1":
                positionSelect = 55;
                rb.MovePosition(playerStartPosition[positionSelect].position);
                break;
            case "Library":
                Transition.Play(transitionEffectName, 0, 0.0f);
                AudioManager.instance.PlaySound(TransitionSound);
                positionSelect = 0;
                rb.MovePosition(playerStartPosition[positionSelect].position);
                levelIntroDisplay.text = "Library";
                introDisplayOBJ.SetActive(true);
                StartCoroutine(wait0());

                IEnumerator wait0()
                {
                    yield return new WaitForSeconds(3);
                    gameObject.SetActive(false);
                }
                break;
            case "Home1":
                Transition.Play(transitionEffectName, 0, 0.0f);
                positionSelect = 1;
                rb.MovePosition(playerStartPosition[positionSelect].position);
                break;
            case "Windmill":
                Transition.Play(transitionEffectName, 0, 0.0f);
                positionSelect = 2;
                rb.MovePosition(playerStartPosition[positionSelect].position);
                levelIntroDisplay.text = "WindMill";
                introDisplayOBJ.SetActive(true);
                StartCoroutine(wait2());

                IEnumerator wait2()
                {
                    yield return new WaitForSeconds(4);
                    gameObject.SetActive(false);
                }
                break;
            case "Dungeon":
                Transition.Play(transitionEffectName, 0, 0.0f);
                positionSelect = 3;
                rb.MovePosition(playerStartPosition[positionSelect].position);
                levelIntroDisplay.text = "<wiggle>Dungeon<wiggle>";
                introDisplayOBJ.SetActive(true);
                StartCoroutine(wait3());

                IEnumerator wait3()
                {
                    yield return new WaitForSeconds(4);
                    gameObject.SetActive(false);
                }
                break;
        }
    }
}
