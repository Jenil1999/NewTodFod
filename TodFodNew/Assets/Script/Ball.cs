using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle Paddle1;
    [SerializeField] float Xpush = 1f;
    [SerializeField] float Ypush = 15f;
    [SerializeField] AudioClip[] ballsound;
    [SerializeField] float RandomFactor = 0.2f; 

    bool hasStarted = false;

    Vector2 PaddletoBallDist;

    AudioSource MyAudioSource;
    Rigidbody2D MyRigidbody;


    void Start()
    {
        PaddletoBallDist = transform.position - Paddle1.transform.position;
        MyAudioSource = GetComponent<AudioSource>();
        MyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBall();
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
      if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            MyRigidbody.velocity = new Vector2(Xpush, Ypush);
        }
    }

    private void LockBall()
    {
        Vector2 paddlepos = new Vector2(Paddle1.transform.position.x, Paddle1.transform.position.y);
        transform.position = paddlepos + PaddletoBallDist;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 VelocityTwik = new Vector2
            (Random.Range(0f,RandomFactor),Random.Range(0f,RandomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballsound[Random.Range(0, ballsound.Length)];
            MyAudioSource.PlayOneShot(clip);

            MyRigidbody.velocity += VelocityTwik;
        }

    }
}
