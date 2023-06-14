using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionManager : MonoBehaviour
{
    public List<SelectableGameObject> m_LevelGameObjects = null;

    private SelectableGameObject m_SelectedLevel = null;

    public SelectableGameObject SelectedLevel
    {
        get
        {
            return m_SelectedLevel;
        }
    }

    public void OnEnterSelected(SelectableGameObject level)
    {
        foreach (var levelGameObject in m_LevelGameObjects)
        {
            if (levelGameObject != level)
            {
                levelGameObject.DeselectGameObject();
            }
        }
        m_SelectedLevel = level;

        GameManager.Instance.UIController.ChangeLevelSelectionText(level.name);
    }

    public void OnLevelDeselected(GameObject go)
    {
        m_SelectedLevel = null;
        GameManager.Instance.UIController.ChangeLevelSelectionText("Select Level");
    }
}

