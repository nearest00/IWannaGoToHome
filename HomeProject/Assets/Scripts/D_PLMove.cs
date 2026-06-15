using UnityEngine;
using UnityEngine.InputSystem;

public class D_PLMove : MonoBehaviour
{
    public GameObject Player;
    Vector2 inputVector; //점프안할거니까 2차원 벡터로 입력
    void Update()
    {
        if (D_InputLockManager.IsLocked)
            return;

        transform.position += new Vector3(inputVector.x, 0, inputVector.y) * Time.deltaTime;//z이동 없이 x y만 인풋받은대로 이동
    }
    public void OnMoveMent(InputValue value)
    {
        inputVector = value.Get<Vector2>(); 
    }

    public void Ending()
    {
        Player.SetActive(false);
    }
}
