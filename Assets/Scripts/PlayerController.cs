using UnityEngine;

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
    public class PlayerController : MonoBehaviour
    {
        private Player player;
        private PlayerControls playerControls;

        private void Awake()
        {
            player = GetComponent<Player>();
            playerControls = new PlayerControls();

            playerControls.Player.Move.performed += context => MovePlayer(context.ReadValue<Vector2>());
            playerControls.Player.Move.canceled += context => MovePlayer(context.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            playerControls.Player.Move.Enable();
        }

        private void OnDisable()
        {
            playerControls.Player.Move.Disable();
        }

        private void MovePlayer(Vector2 input)
        {
            player.Velocity = input * player.MoveSpeed;
        }
    }
}