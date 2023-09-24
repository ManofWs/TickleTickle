using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //public Damage _damage;
    public int maxHealth = 10; // Maximum health of the enemy
    public int currentHealth; // Current health of the enemy

    public GameObject FloatingText;
    public GameObject FloatingTextSpawnArea;

    public float destroyDelay = 2f; // Time delay before destroying the text
    public float fadeDuration = 1f; // Time it takes for the text to fade out

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        Debug.Log(currentHealth);
        currentHealth -= damage;
        FloatingTextTrigger();
        // Check if the enemy's health has reached zero or below
        if (currentHealth <= 0)
        {
            // Handle enemy death (e.g., play death animation, destroy GameObject, etc.)
            Destroy(gameObject);
        }
    }

    public void FloatingTextTrigger()
    {
        var txt = Instantiate(FloatingText, FloatingTextSpawnArea.transform.position, Quaternion.identity);
        txt.GetComponent<TextMesh>().text = currentHealth.ToString();

        StartCoroutine(FadeAndDestroy(txt));
    }

    IEnumerator FadeAndDestroy(GameObject txt)
    {
        TextMesh textMesh = txt.GetComponent<TextMesh>();
        Material textMaterial = textMesh.GetComponent<Renderer>().material;
        Color startColor = textMaterial.color;

        // Calculate the rate at which the text will fade out
        float fadeSpeed = 1f / fadeDuration;

        // Wait for the destroyDelay before starting to fade
        yield return new WaitForSeconds(destroyDelay);

        // Fade out the text
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime * fadeSpeed);
            textMaterial.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        // Ensure the text is fully faded and then destroy it
        textMaterial.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        Destroy(txt);

    }
}
