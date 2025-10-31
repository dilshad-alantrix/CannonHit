using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawn : MonoBehaviour, Iobserver
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private float spawnDistance = 1.5f;
    [SerializeField] private float shootForce = 10f;
    [SerializeField] private int startingAmmo = 10;
    [SerializeField] private float reloadTime = 2f;

    public TMP_Text text;
    public Image reloadImage;
    private int currentAmmo;
    private bool _isplaying;
    private bool _canShoot;

    private Pool<Ball> ballPool = new Pool<Ball>();
    void Start()
    {
        ballPool.Obj = ballPrefab;
        currentAmmo = startingAmmo;
        text.text = currentAmmo.ToString();
        _canShoot = true;
    }
    void OnEnable()
    {
        gameManager.AddObserver(this);
    }
    void OnDestroy()
    {
        gameManager.RemoveObserver(this);
    }
    public void OnNotify(GameState state)
    {
        if (state == GameState.Playing)
        {
            _isplaying = true;
        }
        else
        {
            _isplaying = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0 && _isplaying && _canShoot)
        {
            currentAmmo--;
            text.text = currentAmmo.ToString();
            ShootBall();
            StartCoroutine(Reload());
        }

    }

    private void ShootBall()
    {
        AudioManager.instance.PlaySfx(AudioManager.instance.throwClip);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 spowPoint = Camera.main.transform.position + Camera.main.transform.forward * spawnDistance;

        Ball ball = ballPool.GetObj();
        ball.transform.position = spowPoint;
        ball.Init((b) => ballPool.SetObj(b),BarralHit);

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(ray.direction * shootForce, ForceMode.VelocityChange);
    }

    public void BarralHit(Ball ball)
    {
        currentAmmo += 3;
        text.text = currentAmmo.ToString();
    }
    
    private IEnumerator Reload()
    {
        _canShoot = false;
        reloadImage.fillAmount = 0f;
        float elapsed = 0f;
        while (elapsed < reloadTime)
        {
            elapsed += Time.deltaTime;
            reloadImage.fillAmount = elapsed / reloadTime;
            yield return null;
        }
        _canShoot = true;
    }
}
