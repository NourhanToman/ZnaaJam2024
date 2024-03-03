using UnityEngine;

public class InputManager : MonoBehaviour
{
    internal GameInputSystem PlayerInput { get; private set; }
    private GameInputSystem.PlayerActions _playerActions;

    private ServiceLocator _serviceLocator;
    private LevelBoxManager _boxRotationManager;
    private PlayerJumping _playerJumping;

    private void Awake()
    {
        _serviceLocator = ServiceLocator.Instance;
        _serviceLocator.RegisterService(this);

        PlayerInput = new GameInputSystem();
        _playerActions = PlayerInput.Player;
    }

    private void Start()
    {
        _boxRotationManager = _serviceLocator.GetService<LevelBoxManager>();
        _playerJumping = _serviceLocator.GetService<PlayerJumping>();

        _playerActions.BoxRotateRight.performed += _ => _boxRotationManager.GetBoxRotation().RotateRight();
        _playerActions.BoxRotateLeft.performed += _ => _boxRotationManager.GetBoxRotation().RotateLeft();

        _playerActions.Jump.performed += context => _playerJumping.HandleJump(context.ReadValue<float>() > 0);
    }

    private void OnEnable() => PlayerInput.Enable();

    private void OnDisable() => PlayerInput.Disable();
}