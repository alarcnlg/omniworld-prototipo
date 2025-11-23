using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterJump : MonoBehaviour
{
    Character _character;
    Rigidbody2D _rigidbody2D;
    
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;

    private InputAction jumpAction;

    private void Awake()
    {
        // Create input action for jump (space key)
        jumpAction = new InputAction("Jump", binding: "<Keyboard>/space");
        jumpAction.performed += OnJump;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get Character script from its parent (it should be Player object)
        _character = GetComponent<Character>();        
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        jumpAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Apply extra gravity when falling or releasing jump early
        if (_rigidbody2D.linearVelocity.y < 0)
        {
            // Falling - apply extra gravity
            _rigidbody2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rigidbody2D.linearVelocity.y > 0 && !jumpAction.IsPressed())
        {
            // Rising but jump button released - apply extra gravity for variable jump height
            _rigidbody2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {        
        if (_character != null && _character.InGround && _rigidbody2D != null)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

}
