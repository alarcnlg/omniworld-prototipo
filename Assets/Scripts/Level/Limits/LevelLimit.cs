using UnityEngine;

public class LevelLimit : MonoBehaviour
{
    [SerializeField] bool isDeathLimit = true;
    private Collider2D _collider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();

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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (_collider != null)
        {
            Bounds bounds = _collider.bounds;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
        
    }
}
