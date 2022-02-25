using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public PlayerController playerController;
    public void LockAction()
    {
        playerController.actionLock = true;
    }
    public void LockIdle()
    {
        playerController.idleLock = true;
    }
    public void UnlockAction()
    {
        playerController.actionLock = false;
    }
    public void UnlockIdle()
    {
        playerController.idleLock = false;
    }
    public void LockSecondStrike()
    {
        playerController.secondStrikeLock = true;
    }
    public void UnlockSecondStrike()
    {
        playerController.secondStrikeLock = false;
    }
}
