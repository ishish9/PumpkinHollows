using TMPro;
using UnityEngine;

public class NPCTalkTrigger : MonoBehaviour
{
    [SerializeField] private NpcSpeech npcSpeech;
    [SerializeField] private TextMeshProUGUI npcSpeechUI;
    [SerializeField] private GameObject OBJnpcSpeechUI;
    [SerializeField] private Animator FadeIn = null;
    [SerializeField] private Animator FadeOut = null;
    [SerializeField] private Animator SpeechBarTop = null;
    [SerializeField] private Animator SpeechBarBottom = null;
    [SerializeField] private int selectSpeech;
    private bool speechActive = true;
    private bool firstSpeech0 = true;
    private bool firstSpeech1 = true;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player") && speechActive)
        {
            speechActive = false;
            OBJnpcSpeechUI.SetActive(true);
            npcSpeechUI.text = "";
            FadeIn.Play("NPC_Speech_Text_fade_In", 0, 0.0f);
            SpeechBarTop.Play("Top_Bar_Enter", 0, 0.0f);
            SpeechBarBottom.Play("Bottom_Bar_Enter", 0, 0.0f);

            switch (selectSpeech)
            {
                case 0:
                    if (firstSpeech0)
                    {
                        firstSpeech0 = false;
                        npcSpeechUI.text = npcSpeech.npcWouldLikeBook0.ToString();
                    }
                    else
                    {
                        switch (Random.Range(0, 5))
                        {
                            case 0:
                                npcSpeechUI.text = npcSpeech.npcWouldLikeBook0.ToString();
                                break;
                            case 1:
                                npcSpeechUI.text = npcSpeech.npcWouldLikeBook1.ToString();
                                break;
                            case 2:
                                npcSpeechUI.text = npcSpeech.npcWouldLikeBook2.ToString();
                                break;
                            case 3:
                                npcSpeechUI.text = npcSpeech.npcWouldLikeBook3.ToString();
                                break;
                            case 4:
                                npcSpeechUI.text = npcSpeech.npcWouldLikeBook4.ToString();
                                break;
                        }
                    }
                    
                    break;
                    /////
                case 1:
                    if (firstSpeech1)
                    {
                        firstSpeech1 = false;
                        npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    }
                    else
                    {
                        switch (Random.Range(0, 4))
                        {
                            case 0:
                                npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                                break;
                            case 1:
                                npcSpeechUI.text = npcSpeech.npcLostKey1.ToString();
                                break;
                            case 2:
                                npcSpeechUI.text = npcSpeech.npcLostKey2.ToString();
                                break;
                            case 3:
                                npcSpeechUI.text = npcSpeech.npcLostKey3.ToString();
                                break;
                            
                        }
                    }
                        break;
                case 2:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 3:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 4:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 5:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 6:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 7:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 8:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 9:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 10:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 11:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 12:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 13:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 14:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
                case 15:
                    npcSpeechUI.text = npcSpeech.npcLostKey0.ToString();
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            speechActive = true;
            FadeOut.Play("NPC_Speech_Text_fade_Out", 0, 0.0f);
            SpeechBarTop.Play("Top_Bar_Exit", 0, 0.0f);
            SpeechBarBottom.Play("Bottom_Bar_Exit", 0, 0.0f);
        }
    }
}
