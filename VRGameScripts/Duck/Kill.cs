using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Kill : MonoBehaviour
{
    public Color flashDamage = Color.white;

    private SpriteRenderer spriteRenderer = null;
    private Color originColor = Color.white;

    public Vector3 spawnPosition;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;
    public GameObject enemy;

    private int maxHealth = 1;
    private int health = 0;
    public int pointValue = 10;

    public Animator animator;
    private Rigidbody rigidbody = null;

    private void Start()
    {

    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originColor = spriteRenderer.material.color;
    }

    private void OnEnable()
    {
        ResetHealth();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Damage();
        }
    }

    private void Damage()
    {
        StopAllCoroutines();
        StartCoroutine(Death());

        RemoveHealth();
    }

    private IEnumerator Death()
    {
        spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        Instantiate(enemy, spawnPosition, Quaternion.identity);
        gameObject.GetComponent<Duck>().enabled = false;
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(1);
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
        ScoreManager.instance.score += pointValue;
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

    private void RemoveHealth()
    {
        health--;
        CheckForDeath();
    }

    private void ResetHealth()
    {
        health = maxHealth;
    }

    private void CheckForDeath()
    {
        if(health <= 0)
        {
            Death();
        }
    }
}
