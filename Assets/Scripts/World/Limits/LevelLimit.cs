using UnityEngine;

public class LevelLimit : MonoBehaviour
{
    [SerializeField] bool isDeathLimit = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        // If gameobject is player, trigger death or respawn
        if(collider.CompareTag("Player")) {
            if(isDeathLimit) {
                // Trigger game over
                GameManager.Instance.GameOver();
            } 
        }
    }
}
