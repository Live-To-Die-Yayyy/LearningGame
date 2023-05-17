using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class EnterSelectionManager : Singleton<EnterSelectionManager>
{
    public List<SelectableGameObject> m_AnswerGameObjects = null;

    private SelectableGameObject m_SelectedAnswer = null;

    public SelectableGameObject SelectedAnswer
    {
        get
        {
            return m_SelectedAnswer;
        }
    }

    public void OnEnterSelected(SelectableGameObject answer)
    {
        foreach (var answerGameObject in m_AnswerGameObjects)
        {
            if (answerGameObject != answer)
            {
                answerGameObject.DeselectGameObject();
            }
        }
        m_SelectedAnswer = answer;
        if (EnterSelectionManager.Instance.SelectedAnswer != null)
        {
            Debug.Log("No answer selected");
        }
        
    }

    public void OnAnswerDeselected(GameObject go)
    {
        m_SelectedAnswer = null;
    }

    
        
}