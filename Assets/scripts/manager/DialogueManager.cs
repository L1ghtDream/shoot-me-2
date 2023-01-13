using dto;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour{
    private static readonly int PASSES_PER_CHARACTER = 2;


    [SerializeField] private GameObject dialogue;

    private int _currentPass;
    
    private GameObject _dialogueNextButton;
    private GameObject _dialogueTextBox;

    private TextMeshProUGUI _dialogueTextBoxComponent;

    private string _textToDisplay;
    private int _textToDisplayIndex;
    private DialogueLine _currentDialogueLine;

    private DialogueLine introduction = new(
        "Hi there...",
        new DialogueLine(
            "As you probably saw yourself there is an odd colored person on your screen. They are your target... " +
            "you can say the wanted person.\n",
            new DialogueLine("You know... just shoot him.")
        )
    );

    private void Start(){
        DisplayDialogue(introduction);
    }

    private void FixedUpdate(){
        DrawDialogue();
    }

    private void DrawDialogue(){
        if (_textToDisplay.Length <= _textToDisplayIndex){
            if (_dialogueNextButton != null) _dialogueNextButton.SetActive(true);
            return;
        }

        if (_currentPass < PASSES_PER_CHARACTER){
            _currentPass++;
            return;
        }

        _currentPass = 0;
        _dialogueTextBoxComponent.text += _textToDisplay[_textToDisplayIndex];
        _textToDisplayIndex++;
    }

    private void DisplayDialogue(DialogueLine dialogueLine){
        if (_dialogueTextBox == null){
            _dialogueTextBox = dialogue.transform.GetChild(1).gameObject;
        }

        if (_dialogueNextButton == null){
            _dialogueNextButton = dialogue.transform.GetChild(2).gameObject;
        }

        if (_dialogueTextBoxComponent == null){
            _dialogueTextBoxComponent = _dialogueTextBox.GetComponent<TextMeshProUGUI>();
        }
        
        dialogue.SetActive(true);

        _currentDialogueLine = dialogueLine;
        
        _dialogueNextButton.SetActive(false);
        _dialogueTextBoxComponent.text = "";
        _textToDisplay = _currentDialogueLine.message;
        _textToDisplayIndex = 0;
    }
    
    private void CloseDialogue(){
        dialogue.SetActive(false);
        GameController.GetInstance().SetTargetCursor();
    }

    public void NextDialogue(){
        if (_currentDialogueLine.nextDialogue == null){
            CloseDialogue();
            return;
        }
        DisplayDialogue(_currentDialogueLine.nextDialogue);
    }

    public void SkipDialogue(){
        if (_textToDisplayIndex == _textToDisplay.Length){
            NextDialogue();
            return;
        }
        
        _dialogueTextBoxComponent.text = _textToDisplay;
        _textToDisplayIndex = _textToDisplay.Length;
    }
}