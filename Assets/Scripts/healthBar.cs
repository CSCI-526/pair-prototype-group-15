using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthBar : MonoBehaviour
{
    public Slider slider ; 
    public Gradient gradient ; 
    public Image fill ; 
    public Transform playerTransform; // Drag the player transform here in the Inspector
    public Vector3 offset; // Adjust the offset to position the health bar above the player


    public void SetMaxHealth(int health){
        slider.maxValue = health ; 
        slider.value = health ; 

        fill.color = gradient.Evaluate(1f);
    }

    // Start is called before the first frame update
    public void SetHealth(int health){
        slider.value = health ;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
     // Update is called once per frame
    void Update()
    {
        // Keep the health bar at a fixed position above the player
        transform.position = Camera.main.WorldToScreenPoint(playerTransform.position + offset);
    }

}
