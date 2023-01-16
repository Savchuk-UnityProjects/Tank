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
    private float CurrentPetrolVolume;
    private int OffsetForScore;

    private int m_CurrentQuantityOfTheProjectiles;
    private int CurrentQuantityOfTheProjectiles
    {
        get => m_CurrentQuantityOfTheProjectiles;
        set
        {
            m_CurrentQuantityOfTheProjectiles = value;
            TextWhichShowsTheQuantityOfTheProjectiles.text = $"{CurrentQuantityOfTheProjectiles}/{MaximumQuantityOfTheProjectiles}";
        }
    }

    public void IncreaseQuantityOfProjectiles()
    {
        if (CurrentQuantityOfTheProjectiles < MaximumQuantityOfTheProjectiles)
        {
            CurrentQuantityOfTheProjectiles++;
        }
    }

    public void IncreaseVolumeOfThePetrol(float DeltaVolume)
    {
        CurrentPetrolVolume += DeltaVolume;
        CurrentPetrolVolume = Mathf.Clamp(CurrentPetrolVolume, float.NegativeInfinity, MaximumPetrolVolume);
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
        void EnableBehaviourOnVirtualButton(string VirtualButtonName, Behaviour BehaviourToBeEnabledOnThisButton)
        {
            if(Input.GetButtonDown(VirtualButtonName))
            {
                BehaviourToBeEnabledOnThisButton.enabled = true;
            }
            if(Input.GetButtonUp(VirtualButtonName))
            {
                BehaviourToBeEnabledOnThisButton.enabled = false;
            }
        }
        if (CurrentPetrolVolume > 0)
        {
            EnableBehaviourOnVirtualButton(CatalogOfInchangableValues.MovingForward, MoveForward);
            EnableBehaviourOnVirtualButton(CatalogOfInchangableValues.MovingBack, MoveBackward);
        }
        else
        {
            MoveForward.enabled = false;
            MoveBackward.enabled = false;
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
        void RotateAlongZAxisIfParameterIsTrue(bool DeterminingParameter, float SlopeDelta)
        {
            if(DeterminingParameter)
            {
                transform.rotation *= Quaternion.AngleAxis(SlopeDelta, Vector3.forward);
            }
        }

        RotateAlongZAxisIfParameterIsTrue(IsLeftButtonPressed, SlopeDeltaInOneFrame);
        RotateAlongZAxisIfParameterIsTrue(IsRightButtonPressed, -SlopeDeltaInOneFrame);

        CurrentPetrolVolume -= Mathf.Clamp01(CoefficientForTheLosingOfThePetrol * Mathf.Abs(RigidbodyOfTheTank.velocity.x));
        CurrentPetrolVolume = Mathf.Clamp(CurrentPetrolVolume, 0, float.PositiveInfinity);

        StripeForPetrolOnTheScreen.localScale = new Vector3(CurrentPetrolVolume / MaximumPetrolVolume, StripeForPetrolOnTheScreen.localScale.y, StripeForPetrolOnTheScreen.localScale.z);
    }
}