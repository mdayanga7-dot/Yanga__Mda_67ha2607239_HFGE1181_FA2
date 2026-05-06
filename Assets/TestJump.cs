using UnityEngine;

public class TestJump : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 10);
        }
    }
}