
using UnityEngine;

public class AsteroidDamage : MonoBehaviour
{
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private int damage, scoreOfThis;
    [SerializeField] private float timeToDie;
    private ScoreBucket scoreBucketInScene;

    private float elapsed;
    private bool isScoreSet;


    private void Start()
    {
        isScoreSet = true;
        scoreBucketInScene = FindObjectOfType<ScoreBucket>();
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
        if(elapsed >= timeToDie && isScoreSet)
        {
            scoreBucketInScene.AddScore(scoreOfThis);
            scoreBucketInScene.AddMulitplier(1);
            elapsed = 0;
            isScoreSet = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            scoreBucketInScene.ResetMulitplier();
            isScoreSet = false;
            GameObject explode = Instantiate(impactEffect, collision.collider.transform.position, Quaternion.identity);
            Destroy(explode, 1f);
            Destroy(gameObject);
        }
    }


}
