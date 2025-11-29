using UnityEngine;

public class Level : MonoBehaviour
{


    [SerializeField] private float TimeToChangeWorld = 10f;
    [SerializeField] private float TimeToStartChange = 3f;

    GameObject[] _steps;
    private int _currentStepIndex = 0;
    private int _nextStepIndex = 0;
    private float _currentTimeToChangeWorld;
    private float _currentTime;
    private bool _isNextStepPreactivated = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentTimeToChangeWorld = TimeToChangeWorld;
        LoadSteps();
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime -= Time.deltaTime;
        
        if (_currentTime <= TimeToStartChange && !_isNextStepPreactivated)
        {
            PreactivateStep();
        }
        else if (_currentTime <= 0)
        {
            ActivateStep();
        }

    }

    void LoadSteps()
    {
        // Load all steps from children
        _steps = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _steps[i] = transform.GetChild(i).gameObject;
            _steps[i].SetActive(i == 0); // Activate only the first step
        }

        // Activate first step
        _currentStepIndex = -1;
        _nextStepIndex = 0;

        ActivateStep();

    }

    void PreactivateStep()
    {
        GameObject nextStep = _steps[_nextStepIndex];
        nextStep.SetActive(true);
   
        // Enable next step but only Marks objects
        nextStep.transform.Find("Marks").gameObject.SetActive(true);

        nextStep.transform.Find("World").gameObject.SetActive(false);
        nextStep.transform.Find("Items").gameObject.SetActive(false);

        _isNextStepPreactivated = true;
    }

    void ActivateStep()
    {
        // Enable worlds and items of the next step
        GameObject nextStep = _steps[_nextStepIndex];
        nextStep.transform.Find("World").gameObject.SetActive(true);

        // Enable items and its children
        GameObject items = nextStep.transform.Find("Items").gameObject;
        items.SetActive(true);
        EnableDisableChildrenObjects(items, true);

        // Disable current step
        if(_currentStepIndex >= 0) {
            GameObject currentStep = _steps[_currentStepIndex];
            currentStep.SetActive(false);
        }
        
        // Update control values
        _currentTime = _currentTimeToChangeWorld;

        // Set the next step index
        // Add logic to go back if we are at the end of the steps
        int previousStepIndex = _currentStepIndex;
        _currentStepIndex = _nextStepIndex;

        if(previousStepIndex < _currentStepIndex)
        {
            _nextStepIndex = _currentStepIndex + 1;
        }
        else if(previousStepIndex > _currentStepIndex)
        {
            _nextStepIndex = _currentStepIndex - 1;
        }

        if(_nextStepIndex >= _steps.Length || _nextStepIndex < 0)
            _nextStepIndex = previousStepIndex;

        _isNextStepPreactivated = false;
    }

    void EnableDisableChildrenObjects(GameObject parent, bool enable)
    {
        foreach(Transform child in parent.transform)
        {
            child.gameObject.SetActive(enable);
        }
    }

}
