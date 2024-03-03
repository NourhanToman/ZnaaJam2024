using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LevelBoxManager : MonoBehaviour
{
    [SerializeField] private List<LevelBox> _boxRotationList;
    [SerializeField] private GameObject _player;
    [SerializeField] private Light2D _light2D;
    [SerializeField] internal GameEvents levelCompleted;

    private LevelBox _levelBox;

    private int _levelBoxIndex = 0;
    private Coroutine currentPlayerScale;

    private ServiceLocator _serviceLocator;

    private int _lastRotation = -1;

    private void Awake()
    {
        _serviceLocator = ServiceLocator.Instance;
        _serviceLocator.RegisterService(this);

        SetRandomInitialRotation();
    }

    private void Start() => SetLevelBox();

    private void OnEnable() => levelCompleted.GameAction += SetLevelCompleted;

    private void OnDisable() => levelCompleted.GameAction -= SetLevelCompleted;

    internal void SetLevelBox()
    {
        if (_levelBoxIndex >= _boxRotationList.Count)
            return;

        _levelBox = _boxRotationList[_levelBoxIndex];

        _levelBoxIndex++;

        if (currentPlayerScale != null)
            StopCoroutine(currentPlayerScale);
    }

    private void SetRandomInitialRotation()
    {
        int newRotation;
        foreach (var box in _boxRotationList)
        {
            do
            {
                newRotation = Random.Range(0, 4);
            } while (newRotation == _lastRotation);

            box.SetRandomInitialRotation(newRotation);
            _lastRotation = newRotation;
        }
    }

    internal LevelBox GetBoxRotation() => _levelBox;

    private void SetLevelCompleted()
    {
        _levelBox.Coolider2D.enabled = false;

        _levelBox.StartCoroutine(_levelBox.DisbaleObstcals());

        SetLevelBox();
        currentPlayerScale = StartCoroutine(SetPlayerScale());

        _serviceLocator.GetService<PlayerJumping>().SetJumpForce = _levelBox.PlayerJumpForce;

        _light2D.pointLightOuterRadius += 1;
    }

    private IEnumerator SetPlayerScale()
    {
        Vector3 targetScale = new(_levelBox.PlayerScale, _levelBox.PlayerScale);

        while (Vector3.Distance(_player.transform.localScale, targetScale) > 0.01f)
        {
            _player.transform.localScale = Vector3.Lerp(_player.transform.localScale, targetScale, Time.deltaTime);
            yield return null;
        }

        _player.transform.localScale = targetScale;
    }
}