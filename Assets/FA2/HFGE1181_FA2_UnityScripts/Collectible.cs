using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int score;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            UIManager.Instance.AddScore(score);
            Destroy(this.gameObject);
        }
    }

}
