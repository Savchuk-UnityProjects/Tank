using UnityEngine;
using TMPro;

public class Tank : MonoBehaviour
{
    [SerializeField] private ConstantForce2D MoveForward;
    [SerializeField] private ConstantForce2D MoveBackward;
    [SerializeField] private ConstantForce2D Gravity;
    [SerializeField] private GameObject SampleProjectile;
    [SerializeField] private int MaximumQuantityOfTheProjectiles;
    [SerializeField] private TextMeshProUGUI TextWhichShowsTheQuantityOfTheProjectiles;
    [SerializeField] private TextMeshProUGUI TextWithScore;
    [SerializeField] private float MaximumPetrolVolume;
    [SerializeField] private RectTransform StripeForPetrolOnTheScreen;
    [SerializeField] private float SlopeDeltaInOneFrame;
    [SerializeField] private float CoefficientForTheSpeedOfTheShooting;
    [SerializeField] private float CoefficientForTheLosingOfThePetrol;
    [SerializeField] private InchangableValues CatalogOfInchangableValues;

    private bool IsLeftButtonPressed = false;
    private bool IsRightButtonPressed = false;
    private Rigidbody2D RigidbodyOfTheTank;
    private int CurrentQuantityOfTheProjectiles;
    private float CurrentPetrolVolume;
    private int OffsetForScore;

    public void IncreaseTheQuantityOfTheProjectiles()
    {
        if (CurrentQuantityOfTheProjectiles < MaximumQuantityOfTheProjectiles)
        {
            CurrentQuantityOfTheProjectiles++;
        }
    }

    public void IncreaseVolumeOfThePetrol(float DeltaVolume)
    {
        if (CurrentPetrolVolume + DeltaVolume <= MaximumPetrolVolume)
        {
            CurrentPetrolVolume += DeltaVolume;
        }
        else
        {
            CurrentPetrolVolume = MaximumPetrolVolume;
        }
    }

    private void Start()
    {
        RigidbodyOfTheTank = GetComponent<Rigidbody2D>();
        CurrentQuantityOfTheProjectiles = MaximumQuantityOfTheProjectiles;
        CurrentPetrolVolume = MaximumPetrolVolume;
        OffsetForScore = (int)System.Math.Round(transform.position.x, 0);
    }

    private void Shoot()
    {
        CurrentQuantityOfTheProjectiles--;
        GameObject NewProjectile = Instantiate(SampleProjectile, transform);
        NewProjectile.GetComponent<SpriteRenderer>().enabled = true;
        NewProjectile.transform.parent = null;
        NewProjectile.AddComponent<CircleCollider2D>();
        NewProjectile.AddComponent<DestroyingOnCollision>();
        NewProjectile.AddComponent<Rigidbody2D>();
        Rigidbody2D RigidbodyOfTheProjectile = NewProjectile.GetComponent<Rigidbody2D>();
        RigidbodyOfTheProjectile.AddForce(transform.right * CoefficientForTheSpeedOfTheShooting, ForceMode2D.Impulse);
    }

    private void Update()
    {
        TextWhichShowsTheQuantityOfTheProjectiles.text = $"{CurrentQuantityOfTheProjectiles}/{MaximumQuantityOfTheProjectiles}";

        if (Input.GetButtonDown(CatalogOfInchangableValues.MovingForward) && CurrentPetrolVolume > 0)
        {
            MoveForward.enabled = true;
        }
        if (Input.GetButtonUp(CatalogOfInchangableValues.MovingForward))
        {
            MoveForward.enabled = false;
        }
        if (CurrentPetrolVolume == 0)
        {
            MoveForward.enabled = false;
        }

        if (Input.GetButtonDown(CatalogOfInchangableValues.MovingBack) && CurrentPetrolVolume > 0)
        {
            MoveBackward.enabled = true;
        }
        if (Input.GetButtonUp(CatalogOfInchangableValues.MovingBack))
        {
            MoveBackward.enabled = false;
        }
        if (CurrentPetrolVolume == 0)
        {
            MoveForward.enabled = false;
        }

        IsLeftButtonPressed = Input.GetButton(CatalogOfInchangableValues.RotatingLeft) && CurrentPetrolVolume > 0;
        IsRightButtonPressed = Input.GetButton(CatalogOfInchangableValues.RotatingRight) && CurrentPetrolVolume > 0;

        if (Input.GetButtonDown(CatalogOfInchangableValues.Shooting) && CurrentQuantityOfTheProjectiles > 0)
        {
            Shoot();
        }

        TextWithScore.text = ((int)transform.position.x - OffsetForScore).ToString();
    }

    private void FixedUpdate()
    {
        if (IsLeftButtonPressed)
        {
            transform.rotation *= Quaternion.AngleAxis(SlopeDeltaInOneFrame, Vector3.forward);
        }
        if (IsRightButtonPressed)
        {
            transform.rotation *= Quaternion.AngleAxis(-SlopeDeltaInOneFrame, Vector3.forward);
        }

        CurrentPetrolVolume -= Mathf.Clamp(0, CoefficientForTheLosingOfThePetrol * Mathf.Abs(RigidbodyOfTheTank.velocity.x), 1);
        CurrentPetrolVolume = Mathf.Clamp(0, CurrentPetrolVolume, float.PositiveInfinity);

        StripeForPetrolOnTheScreen.localScale = new Vector3(CurrentPetrolVolume / MaximumPetrolVolume, StripeForPetrolOnTheScreen.localScale.y, StripeForPetrolOnTheScreen.localScale.z);
    }
}