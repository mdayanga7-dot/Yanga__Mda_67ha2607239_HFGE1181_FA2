using System.Collections;
using UnityEngine;

public class UpdatedJumpPad : MonoBehaviour
{
    public Animator anim;
    public enum ForceDirection { up, left, right, leftDiagonal, rightDiagonal}
    public ForceDirection forceDirection;

    public float hangTime;

    public float force;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<UpdatedPlayerController>().SetJumpPadStatus(true);
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            Vector2 colDirection = col.transform.position - transform.position;
            rb.linearVelocity = Vector2.zero;
            anim.SetTrigger("playerCollision");

            switch (forceDirection)
            {
                case ForceDirection.up:
                    rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                    col.GetComponent<UpdatedPlayerController>().SetJumpPadStatus(false);
                    break;
                case ForceDirection.left:
                    rb.AddForce(Vector2.left * force, ForceMode2D.Impulse);
                    rb.AddForce(Vector2.up * 1.5f, ForceMode2D.Impulse);
                    StartCoroutine(HangTimer(col));
                    break;
                case ForceDirection.right:
                    rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
                    rb.AddForce(Vector2.up * 1.5f, ForceMode2D.Impulse);
                    StartCoroutine(HangTimer(col));
                    break;
                case ForceDirection.leftDiagonal:
                    rb.AddForce(Vector2.left * force, ForceMode2D.Impulse);
                    rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                    StartCoroutine(HangTimer(col));
                    break;
                case ForceDirection.rightDiagonal:
                    rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
                    rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                    StartCoroutine(HangTimer(col));
                    break;
                default:
                    rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                    col.GetComponent<UpdatedPlayerController>().SetJumpPadStatus(false);
                    break;
            }
        }
    }

    public IEnumerator HangTimer(Collider2D col)
    {
        yield return new WaitForSeconds(hangTime);
        col.GetComponent<UpdatedPlayerController>().SetJumpPadStatus(false);

    }
}
