using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private LevelsOrderSO levels;
    [SerializeField] private Button validationButton;

    private int _currentLevelIndex = -1;
    private Vector2 _angleRange;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

    private void Start()
    {
        validationButton.onClick.AddListener(TryResolution);
        SetNextLevel();
    }

    private void OnDestroy()
    {
        validationButton.onClick.RemoveAllListeners();
    }

    private void SetNextLevel()
    {
        if (_currentLevelIndex < levels.Levels.Count - 1)
        {
            _currentLevelIndex++;
            ComputeAngleForLevel();
            return;
        }

        Debug.Log("You completed all the levels !");
    }

    private void ComputeAngleForLevel()
    {
        DifficultyDefinitionSO difficulty = levels.Levels[_currentLevelIndex];        
        float desiredAngle = Random.Range(-90f, 90f);
        float angleRangeWidth = difficulty.AngleRangeWidth;
        _angleRange.x = desiredAngle - angleRangeWidth / 2;
        _angleRange.y = desiredAngle + angleRangeWidth / 2;

        Debug.Log($"Starting new level: difficulty = {difficulty.Name}, angle = {desiredAngle}, range = ({_angleRange.x}, {_angleRange.y})");
    }

    public void TryResolution()
    {
        float angle = PinManager.Instance.PinAngle;
        if (TrySelectedAngle(angle))
        {
            Debug.Log($"Angle {angle} is in the range, level completed!");
            SetNextLevel();
        }
        else
        {
            Debug.Log($"Angle {angle} is not in the range, try again!");
        }
    }

    private bool TrySelectedAngle(float angle)
    {
        return angle >= _angleRange.x && angle <= _angleRange.y;
    }
}