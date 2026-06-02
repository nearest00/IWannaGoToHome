using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        bool isMove = h != 0 || v != 0;

        animator.SetBool("IsMove", isMove);
    }
}