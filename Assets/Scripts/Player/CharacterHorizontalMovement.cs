using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterHorizontalMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float deceleration = 10f;
    
    private InputAction moveAction;
    private float horizontalInput;
    private float currentVelocity;

    private void Awake()
    {
        // Create input action for horizontal movement (A/D keys)
        moveAction = new InputAction("Move", binding: "<Keyboard>/a");
        moveAction.AddCompositeBinding("1DAxis")
            .With("Negative", "<Keyboard>/a")
            .With("Positive", "<Keyboard>/d");
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<float>();
        
        // Smoothly interpolate velocity towards target
        float targetVelocity = horizontalInput * moveSpeed;
        currentVelocity = Mathf.Lerp(currentVelocity, targetVelocity, deceleration * Time.deltaTime);
        
        // Move the character horizontally
        transform.Translate(Vector3.right * currentVelocity * Time.deltaTime);
    }

}
