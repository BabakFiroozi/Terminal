using System;
using Cinemachine;
using UnityEngine;

namespace DefaultNamespace
{
    public class CinemachineController : MonoBehaviour
    {
        private CinemachineVirtualCamera _vCam;

        private bool _set;

        private void Start()
        {
            _vCam = GetComponent<CinemachineVirtualCamera>();
        }

        private void Update()
        {
            if(Player.LocalPlayer == null)
                return;

            if (!_set)
            {
                _set = true;
                _vCam.Follow = Player.LocalPlayer.transform;
                _vCam.LookAt = Player.LocalPlayer.transform;
            }
        }
    }
}