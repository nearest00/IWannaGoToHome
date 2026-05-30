using UnityEngine;
using UnityEngine.InputSystem;

public class D_PLMove : MonoBehaviour
{
    Vector2 inputVector; //점프안할거니까 2차원 벡터로 입력
    public D_CamZoom leftZoom;
    public D_CamZoom rightZoom;
    void Update()
    {
        if (leftZoom.isZooming || rightZoom.isZooming)
            return;

        transform.position += new Vector3(inputVector.x, 0, inputVector.y) * Time.deltaTime;//z이동 없이 x y만 인풋받은대로 이동
    }
    public void OnMoveMent(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        Debug.Log(inputVector);
    }
}
