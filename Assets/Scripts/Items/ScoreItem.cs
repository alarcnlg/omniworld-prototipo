using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [SerializeField]
    int Score;

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
        // If gameobject is player, add to general score an destroy the current item
        if(collider.CompareTag("Player")) {
            ScoreManager.Instance.Score += Score;
            gameObject.SetActive(false);

            // Save object to reactivate in respawn 
            // GameManager.Instance.CheckpointGameObjectsToReset.Add(gameObject);
        }
    }
}
