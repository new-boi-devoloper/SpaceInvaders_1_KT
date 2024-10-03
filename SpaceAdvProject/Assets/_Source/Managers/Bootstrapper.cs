using PlayerScripts;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private Player player;
    [SerializeField] private GameManager gameManager;

    private PlayerCombat _playerCombat;
    private PlayerControls _playerControls;

    private PlayerInvoker _playerInvoker;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerMovement = new PlayerMovement();
        _playerCombat = new PlayerCombat();

        _playerInvoker = new PlayerInvoker(player, _playerMovement, _playerCombat);

        inputListener.Initialize(_playerControls, _playerInvoker);

        // Активируем контроллер ввода
        _playerControls.Enable();
    }

    private void OnDestroy()
    {
        _playerControls.Disable();
    }
}