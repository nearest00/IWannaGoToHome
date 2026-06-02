using Unity.Cinemachine;
using UnityEngine;

public class D_CamZoom : MonoBehaviour
{
    public CinemachineCamera virtualCamera;

    public float startFOV = 100f;
    public float targetFOV = 40f;
    public float zoomSpeed = 1f;
    public bool isZooming = true; //카메라 줌 진행 상태(캐릭터 상호작용 차단)

    void Start()
    {
        virtualCamera.Lens.FieldOfView = startFOV;
    }

    void Update()
    {
        virtualCamera.Lens.FieldOfView =
            Mathf.Lerp(virtualCamera.Lens.FieldOfView, targetFOV, Time.deltaTime * zoomSpeed);
        if (Mathf.Abs(virtualCamera.Lens.FieldOfView - targetFOV) < 0.01f)
        {
            virtualCamera.Lens.FieldOfView = targetFOV;
            isZooming = false;
        }
    }
}