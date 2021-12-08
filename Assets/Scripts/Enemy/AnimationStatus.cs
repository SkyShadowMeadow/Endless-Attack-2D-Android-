using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStatus : MonoBehaviour
{
    protected bool _deathAnimationFinished;

    public bool GetDeathAnimationStatus => _deathAnimationFinished;
    public void ChangeDeathAnimationStatus()
    {
        _deathAnimationFinished = true;
    }
}
