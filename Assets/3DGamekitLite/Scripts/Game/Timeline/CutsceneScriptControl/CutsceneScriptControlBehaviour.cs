using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class CutsceneScriptControlBehaviour : PlayableBehaviour
{
    public bool playerInputEnabled;
    public bool useRootMotion;
    public InputManager playerInput;

    public override void OnGraphStart (Playable playable)
    {
        
    }
}
