using Unity.Cinemachine;
using UnityEngine;

public class D_CamZoom : MonoBehaviour
{
    public CinemachineCamera virtualCamera;

    public float startFOV = 100f;
    public float targetFOV = 40f;
    public float zoomSpeed = 1f;

    private bool zoomFinished;

    private void Start()
    {
        virtualCamera.Lens.FieldOfView = startFOV;

        // 줌 시작 → 입력 잠금
        D_InputLockManager.Lock();
    }

    private void Update()
    {
        if (zoomFinished)
            return;

        virtualCamera.Lens.FieldOfView =
            Mathf.Lerp(
                virtualCamera.Lens.FieldOfView,
                targetFOV,
                Time.deltaTime * zoomSpeed);

        if (Mathf.Abs(virtualCamera.Lens.FieldOfView - targetFOV) < 0.01f)
        {
            virtualCamera.Lens.FieldOfView = targetFOV;
            zoomFinished = true;

            // 줌 끝 → 입력 해제
            D_InputLockManager.Unlock();
        }
    }
}