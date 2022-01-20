using UnityEngine;
using Cinemachine;

namespace Frontfire.Shapeshifter2
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraController : MonoBehaviour
    {
        CinemachineVirtualCamera vc;

        private void Awake()
        {
            vc = GetComponent<CinemachineVirtualCamera>();
            Follow(FindObjectOfType<Player>().transform);
        }

        private void Follow(Transform transform)
        {
            vc.Follow = transform;
        }
    }
}
