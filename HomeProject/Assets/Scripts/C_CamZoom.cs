using Unity.Cinemachine;
using UnityEngine;
using System.Collections;

public class C_CamZoom : MonoBehaviour
{
    public CinemachineCamera virtualCamera;

    public float startFOV = 100f;
    public float targetFOV = 40f;
    public float zoomSpeed = 1f;
    public bool isZooming = true; //카메라 줌 진행 상태(캐릭터 상호작용 차단)

    public CanvasGroup panel;
    int speed=1;
    void Start()
    {
        virtualCamera.Lens.FieldOfView = startFOV;
    }

    void Update()
    {
        if (!isZooming) return;

        virtualCamera.Lens.FieldOfView =
            Mathf.Lerp(virtualCamera.Lens.FieldOfView, targetFOV, Time.deltaTime * zoomSpeed);
        if (Mathf.Abs(virtualCamera.Lens.FieldOfView - targetFOV) < 0.2f)
        {
            virtualCamera.Lens.FieldOfView = targetFOV;
            isZooming = false;
            StartCoroutine(FadeIn());
        }
    }
    IEnumerator FadeIn()
    {
        panel.gameObject.SetActive(true);

        panel.alpha = 0f;

        while (panel.alpha < 1f)
        {
            panel.alpha += speed * Time.deltaTime;

            yield return null;
        }

        panel.alpha = 1f;
    }
}