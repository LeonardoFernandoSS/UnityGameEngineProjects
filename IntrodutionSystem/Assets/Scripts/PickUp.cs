using IntroductionSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, IIntroductable
{
    [SerializeField] private IntroductionData introductionData;

    public IntroductionData IntroductionData { get => introductionData; }

    public bool InitIntroduction() => IntroductionController.Instance.OnInitIntroduction(this);
}
