using System;
using UnityEngine;
using UnityEngine.UIElements; // Import UI Toolkit
using System.Collections;

public class PlayerHealthScript : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private ProgressBar healthBar;
    private bool isInvincible = false;
    [SerializeField]
    private float invicibillitySeconds;
    [SerializeField]
    private GameObject model;

    void Start()
{
    currentHealth = maxHealth;

    // Find the UI Document
    UIDocument uiDocument = FindFirstObjectByType<UIDocument>();
    if (healthBar != null)
{
    // Get the fill element inside the ProgressBar
    VisualElement fillElement = healthBar.Q<VisualElement>("unity-progress-bar__fill");
    if (fillElement != null)
    {
        fillElement.style.backgroundColor = Color.green; // Set default color
    }
}

    if (uiDocument != null)
    {
        healthBar = uiDocument.rootVisualElement.Q<ProgressBar>("HealthBar");
        UpdateHealthBar();
    }
}


    public void TakeDamage(int damage)
{
    if(isInvincible) return;
    currentHealth -= damage;
    currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    if (currentHealth <= 0){
        currentHealth = 0;
        Debug.Log("player died");
        return;
    }

    StartCoroutine(BecomeTemporarilyInvincible());
    UpdateHealthBar();
}

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth * 100; // ProgressBar expects values from 0 to 100
        }
        Debug.Log(currentHealth);
    }
    void MethodThatTriggersInvulnerability(){
        if(!isInvincible){
            StartCoroutine(BecomeTemporarilyInvincible());
        }
    }

    // private IEnumerator BecomeTemporarilyInvincible(){
    //     Debug.Log("player in now invincible");
    //     isInvincible = true;

    //     if(model.transform.localScale == Vector3.one){
    //         ScaleModelto(Vector3.zero);
    //     }
    //     else
    //     {
    //         ScaleModelto(Vector3.one);
    //     }
    //     yield return new WaitForSeconds(invicibillitySeconds);
        
    //     Debug.Log("player is no longer invincible");
    //     ScaleModelto(Vector3.one);
    //     isInvincible = false;
    // } 
    private IEnumerator BecomeTemporarilyInvincible()
{
    Debug.Log("player is now invincible");
    isInvincible = true;

    float elapsedTime = 0f;
    bool isVisible = true;

    while (elapsedTime < invicibillitySeconds)
    {
        isVisible = !isVisible; // Toggle visibility
        ScaleModelto(isVisible ? Vector3.one : Vector3.zero);
        yield return new WaitForSeconds(0.2f); // Adjust flashing speed
        elapsedTime += 0.2f;
    }

    Debug.Log("player is no longer invincible");
    ScaleModelto(Vector3.one); // Make sure player is fully visible again
    isInvincible = false;
}

    private void ScaleModelto(Vector3 scale){
        model.transform.localScale = scale;
    }
    
}
