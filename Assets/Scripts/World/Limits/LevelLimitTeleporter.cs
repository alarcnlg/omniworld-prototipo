using UnityEngine;

public class LevelLimitTeleporter : MonoBehaviour
{
    public GameObject target;
    private LevelLimitTeleporter _targetLimitTeleporter;
    private Collider2D _collider;

    [HideInInspector]
    public bool teleport = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _targetLimitTeleporter = target.GetComponent<LevelLimitTeleporter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player and if teleportation is allowed
        if (other.CompareTag("Player") && teleport)
        {
            // Teleport the player to the target location
            _targetLimitTeleporter.teleport = false;
            other.transform.position = new Vector3(target.transform.position.x, other.transform.position.y, other.transform.position.z);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Optionally, you can add logic here for when the player exits the trigger
            teleport = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        if (_collider != null)
        {
            Bounds bounds = _collider.bounds;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
        
    }
}
