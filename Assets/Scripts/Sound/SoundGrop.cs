using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGrop : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.soundGroup = transform;
    }
}
