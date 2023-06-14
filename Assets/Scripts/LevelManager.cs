using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using UnityEngine.Playables;
using Gamekit3D;

public class LevelManager : Singleton<LevelManager>
{
    private SceneTransitionDestination.DestinationTag m_ZoneRestartDestinationTag = SceneTransitionDestination.DestinationTag.A;
    private PlayableDirector[] m_Directors = null;

    public PlayableDirector[] Directors
    {
        get
        {
            return m_Directors;
        }
    }

    public SceneTransitionDestination.DestinationTag ZoneRestartDestinationTag
    {
        get
        {
            return m_ZoneRestartDestinationTag;
        }
    }

    private void Start()
    {
        m_Directors = GetComponents<PlayableDirector>();
    }

    public void OnClickEnter()
    {
        if (EnterSelectionManager.Instance.SelectedAnswer.name == ("Correct"))
        {
            GameManager.Instance.GoHome();
        }
        else
        {
            GameManager.Instance.GameOver();
        }
    }
    
    public void MoveToTransitionDestination(SceneTransitionDestination transitionDestination)
    {
        if (transitionDestination == null)
        {
            Debug.LogWarning("Entering Transform's location has not been set.");
            return;
        }
        if (transitionDestination.transitioningGameObject == null)
        {
            transitionDestination.OnReachDestination.Invoke();
            return;
        }
        transitionDestination.transitioningGameObject.transform.position = transitionDestination.transform.position;
        transitionDestination.transitioningGameObject.transform.rotation = transitionDestination.transform.rotation;
        transitionDestination.OnReachDestination.Invoke();
    }

    public SceneTransitionDestination GetDestination(SceneTransitionDestination.DestinationTag destinationTag)
    {
        SceneTransitionDestination[] entrances = FindObjectsOfType<SceneTransitionDestination>();
        for (int i = 0; i < entrances.Length; i++)
        {
            if (entrances[i].destinationTag == destinationTag)
                return entrances[i];
        }
        Debug.LogWarning("No entrance was found with the " + destinationTag + " tag.");
        return null;
    }
}
