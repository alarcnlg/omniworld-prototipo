using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    Character _character;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get Character script from its parent (it should be Player object)
        GameObject parent = transform.parent.gameObject;
        _character = parent.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // If touch the ground
        if (collider.gameObject.layer == LayerMask.NameToLayer("Platforms"))
        {
            _character.InGround = true;
        }

    }
    void OnTriggerExit2D(Collider2D collider)
    {
        // If leave the ground
        if (collider.gameObject.layer == LayerMask.NameToLayer("Platforms"))
        {
            _character.InGround = false;
        }

    }
}
