using UnityEngine;
using UnityEngine.InputSystem;

namespace Frontfire.Shapeshifter2
{
    /// 
    /// <summary>
    ///     Changes the players velocity based on input
    /// </summary>
    /// <remarks>
    ///     Relies on generated C# class from InputActionAsset
    /// </remarks>
    ///
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerController : MonoBehaviour
    {
        private Player player;
        private PlayerControls playerControls;
        private PlayerInput playerInput;
        private bool isGamepad;

        private void Awake()
        {
            player = GetComponent<Player>();
            playerInput = GetComponent<PlayerInput>();
            playerControls = new PlayerControls();

            playerControls.Player.Move.performed += context => MovePlayer(context.ReadValue<Vector2>());
            playerControls.Player.Move.canceled += context => MovePlayer(context.ReadValue<Vector2>());

            playerControls.Player.Fire.performed += context => player.Shoot();
        }

        private void Update()
        {
            if (isGamepad)
            {
                Vector2 stickDirection = playerControls.Player.Look.ReadValue<Vector2>();
                if (stickDirection.magnitude > 0f)
                {
                    player.LookTowards(stickDirection);
                }
            }
            else
            {
                player.LookAt(Camera.main.ScreenToWorldPoint(Pointer.current.position.ReadValue()));
            }
        }

        private void OnEnable()
        {
            playerControls.Player.Enable();
            playerInput.controlsChangedEvent.AddListener(OnControlsChange);
        }

        private void OnDisable()
        {
            playerControls.Player.Disable();
            playerInput.controlsChangedEvent.RemoveListener(OnControlsChange);
        }

        private void OnControlsChange(PlayerInput pi)
        {
            isGamepad = playerInput.currentControlScheme.Equals("Gamepad");
        }

        private void MovePlayer(Vector2 input)
        {
            player.Velocity = input * player.MoveSpeed;
        }
    }
}