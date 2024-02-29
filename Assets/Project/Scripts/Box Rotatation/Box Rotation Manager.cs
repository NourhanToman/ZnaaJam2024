using System.Collections.Generic;
using UnityEngine;

public class BoxRotationManager : MonoBehaviour
{
    [SerializeField] private List<BoxRotation> _boxRotationList;

    private BoxRotation _boxRotation;

    private int _boxRotationIndex = 0;

    private void Awake()
    {
        ServiceLocator.Instance.RegisterService(this);
        SetBoxRotation();
    }

    internal void SetBoxRotation()
    {
        if (_boxRotationIndex >= _boxRotationList.Count)
            _boxRotationIndex = 0;

        _boxRotation = _boxRotationList[_boxRotationIndex];

        _boxRotationIndex++;
    }

    internal BoxRotation GetBoxRotation() => _boxRotation;
}