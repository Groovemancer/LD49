using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public Vector2 gravity = new Vector2(0, -2);
    public float gravityRange = 2f;
    public Vector2 newGravity;
    public Vector2 oldGravity;

    public int points = 0;
    public int maxPoints = 10;

    public float elapsedTime = 0f;

    public float changeFrequency = 10; // change every N seconds
    public float changeFrequencyMin = 3;
    public float changeFrequencyMax = 10;

    public float changeDuration = 5; // change takes N seconds to complete, so it's not instantaneous.
    public float changeDurationMin = 1;
    public float changeDurationMax = 5;
    private bool isChanging = false;
    private float changeElapsedTime = 0;

    public bool pauseChange = false;

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();

                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    private void Start()
    {
        gravity = new Vector2(0, -gravityRange);
    }

    // Update is called once per frame
    void Update()
    {


        if (!pauseChange)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= changeFrequency)
            {
                elapsedTime = 0f;
                isChanging = true;

                newGravity = new Vector2(Random.Range(-gravityRange, gravityRange), Random.Range(-gravityRange, gravityRange));
                oldGravity = gravity;
            }

            if (isChanging)
            {
                changeElapsedTime += Time.deltaTime;

                gravity = Vector2.Lerp(oldGravity, newGravity, changeElapsedTime / changeDuration);

                if (changeElapsedTime > changeDuration)
                {
                    changeElapsedTime = 0;
                    isChanging = false;
                }
            }
        }
    }

    public void SetMaxPoints(int newMaxPoints)
    {
        maxPoints = newMaxPoints;
    }

    public void AddPoint(int point)
    {
        points = Mathf.Clamp(points + point, 0, maxPoints);

        changeDuration = Mathf.Max(((changeDurationMax - changeDurationMin) * (maxPoints - points) / maxPoints) + changeDurationMin, changeDurationMin);
        changeFrequency = Mathf.Max(((changeFrequencyMax - changeFrequencyMin) * (maxPoints - points) / maxPoints) + changeFrequencyMin, changeFrequencyMin);
    }
}
