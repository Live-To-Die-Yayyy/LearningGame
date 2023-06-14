using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Pixelplacement;
using UnityEngine;

public class CameraLevelManager : Singleton<CameraLevelManager>
{
    private int CurrentLevelNumber = 1;
    public CinemachineFreeLook Camera; 
    public GameObject[] FollowObjects;
    public GameObject[] LookAtObjects;
    public void GoUpLevel()
    {
        if (CurrentLevelNumber == 3)
        {
            return;
        }
        CurrentLevelNumber++;
        Camera.Follow = FollowObjects[CurrentLevelNumber - 1].transform;
        Camera.LookAt = LookAtObjects[CurrentLevelNumber - 1].transform;
    }

    public void GoDownLevel()
    {
        if (CurrentLevelNumber == 1)
        {
            return;
        }
        CurrentLevelNumber--;
        Camera.Follow = FollowObjects[CurrentLevelNumber - 1].transform;
        Camera.LookAt = LookAtObjects[CurrentLevelNumber - 1].transform;
    }

}
