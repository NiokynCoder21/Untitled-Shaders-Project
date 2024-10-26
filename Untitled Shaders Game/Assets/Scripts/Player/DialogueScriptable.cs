using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Dialogue Set")]
public class DialogueScriptable : ScriptableObject
{
    public List<DialogueLine> dialogueLines;

    [System.Serializable]
    public class DialogueLine
    {
        public string lineText;
        public string speakerName;
    }
}
