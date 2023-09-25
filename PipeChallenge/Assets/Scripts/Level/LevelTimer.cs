using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private View view;
    public static LevelTimer Instance { get; private set; }

    private float startTime;
    private bool isRunning;
    private float pausedTime;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (isRunning)
        {
            float elapsedSeconds = Time.time - startTime;
            view.UpdateTimer(elapsedSeconds);
        }
    }

    public void StartTimer()
    {
        ResetTimer();
        if (!isRunning)
        {
            if (pausedTime == 0f)
            {
                startTime = Time.time;
            }
            else
            {
                // Resume from the paused time
                startTime += (Time.time - pausedTime);
                pausedTime = 0f;
            }
            
            isRunning = true;
        }
    }

    public void PauseTimer()
    {
        if (isRunning)
        {
            pausedTime = Time.time;
            isRunning = false;
        }
    }

    public void ResumeTimer()
    {
        if (!isRunning && pausedTime > 0f)
        {
            startTime += (Time.time - pausedTime);
            pausedTime = 0f;
            isRunning = true;
        }
    }

    public float StopTimer()
    {
        if (isRunning)
        {
            float elapsedSeconds = Time.time - startTime;
            isRunning = false;
            return elapsedSeconds;
        }
        else
        {
            return 0f;
        }
    }

    public void ResetTimer()
    {
        startTime = 0f;
        pausedTime = 0f;
        isRunning = false;
        view.UpdateTimer(0f);
    }
}
