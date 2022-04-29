using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraLook : MonoBehaviour
{
    private CinemachineFreeLook cinemachine;
    private Player playerInput;

    [SerializeField]
    private readonly float lookSpeed = 1f;

    void Awake()
    {
        playerInput = new Player();
        cinemachine = GetComponent<CinemachineFreeLook>();
    }

    void OnEnable()
    {
        playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }

    void Update()
    {
        Vector2 delta = playerInput.PlayerMain.Look.ReadValue<Vector2>();
        cinemachine.m_XAxis.Value += delta.x * 200 * lookSpeed * Time.deltaTime;
        cinemachine.m_YAxis.Value += delta.y * lookSpeed * Time.deltaTime;
    }
}
