using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoxManager : MonoBehaviour
{
    [SerializeField] private List<LevelBox> _boxRotationList;
    [SerializeField] private GameObject _player;
    [SerializeField] internal GameEvents levelCompleted;

    private LevelBox _boxRotation;

    private int _boxRotationIndex = 0;
    private Coroutine currentPlayerScale;

    private ServiceLocator _serviceLocator;

    private void Awake()
    {
        _serviceLocator = ServiceLocator.Instance;
        _serviceLocator.RegisterService(this);
    }

    private void Start() => SetLevelBox();

    private void OnEnable() => levelCompleted.GameAction += SetLevelCompleted;

    private void OnDisable() => levelCompleted.GameAction -= SetLevelCompleted;

    internal void SetLevelBox()
    {
        if (_boxRotationIndex >= _boxRotationList.Count)
            _boxRotationIndex = 0;

        _boxRotation = _boxRotationList[_boxRotationIndex];

        _boxRotationIndex++;

        if (currentPlayerScale != null)
            StopCoroutine(currentPlayerScale);
    }

    internal LevelBox GetBoxRotation() => _boxRotation;

    private void SetLevelCompleted()
    {
        _boxRotation.Coolider2D.enabled = false;

        SetLevelBox();
        currentPlayerScale = StartCoroutine(SetPlayerScale());

        _serviceLocator.GetService<PlayerJumping>().SetJumpForce = _boxRotation.PlayerJumpForce;
    }

    private IEnumerator SetPlayerScale()
    {
        Vector3 targetScale = new(_boxRotation.PlayerScale, _boxRotation.PlayerScale);

        while (Vector3.Distance(_player.transform.localScale, targetScale) > 0.01f)
        {
            _player.transform.localScale = Vector3.Lerp(_player.transform.localScale, targetScale, Time.deltaTime);
            yield return null;
        }

        _player.transform.localScale = targetScale;
    }
}