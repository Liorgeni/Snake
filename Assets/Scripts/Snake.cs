using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public static Snake instance;

    private void Awake()
    {
        instance = this;
    }
    #region Variables
    private Vector2 _direction = Vector2.right;
    private Vector2 _lastDirection;
    private List<Transform> _segments;
    public Transform segmentPrefab;
    public ParticleSystem deathEffect;
    public float speed = 10f;
    public bool isGameOver = false;
    #endregion

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(transform);

        if (deathEffect != null)
        {
            deathEffect.Stop();
        }
    }

    void Update()
    {
        if (!isGameOver)
        {
            HandleInput();
        }
    }

    private void FixedUpdate()
    {
        if (!isGameOver)
        {
            MoveSnake();
        }
    }


    private void MoveSnake()
    {

        for (int i = +_segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        transform.position = new Vector3(
             Mathf.Round(transform.position.x) + _direction.x,
             Mathf.Round(transform.position.y) + _direction.y,
             0.0f
             );
    }

    private void HandleInput()
    {
        _lastDirection = _direction;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_lastDirection != Vector2.down)
                _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_lastDirection != Vector2.up)
                _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_lastDirection != Vector2.left)
                _direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_lastDirection != Vector2.right)
                _direction = Vector2.left;
        }
    }



    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);

        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fruit")
        {
            ScoreManager.instance.UpdateScore();
            Fruit.instance.RandomizePosition();
            Grow();
        }

        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Player")
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            StartCoroutine(GameOverCo());
        }
    }

    public IEnumerator GameOverCo()
    {
        isGameOver = true;

        yield return new WaitForSeconds(1);

        if (UIController.Instance != null)
        {
            UIController.Instance.ShowGameOver();
        }

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

}
