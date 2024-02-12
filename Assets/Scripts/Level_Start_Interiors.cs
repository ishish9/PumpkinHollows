using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level_Start_Interiors : MonoBehaviour
{
    [SerializeField] private GameObject playerOBJ;
    private int positionSelect;
    [SerializeField] private Animator Transition = null;
    [SerializeField] private string transitionEffectName;
    [SerializeField] private Transform[] playerStartPosition;
    [SerializeField] private AudioClip TransitionSound;
    private Rigidbody rb;



    private void Awake()
    {
        rb = playerOBJ.GetComponent<Rigidbody>();
    }
    void Start()
    {
        switch (LevelTransition.levelPosition)
        {
            case "":
                positionSelect = 3;
                rb.MovePosition(playerStartPosition[positionSelect].position);
                break;
            case "Library":
                Transition.Play(transitionEffectName, 0, 0.0f);
                AudioManager.Instance.PlaySound(TransitionSound);
                positionSelect = 0;
                rb.MovePosition(playerStartPosition[positionSelect].position);
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
                break;           
        }
    }
}
