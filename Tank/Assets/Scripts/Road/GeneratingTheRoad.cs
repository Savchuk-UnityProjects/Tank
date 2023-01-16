using UnityEngine;

public class GeneratingTheRoad : MonoBehaviour
{
    [SerializeField] private GameObject Tank;
    [SerializeField] private GameObject TheFurthestPartOfTheRoadGameObject;
    [SerializeField] private float LengthOfOnePartTheRoad;
    [SerializeField] private float MaximumSlope;
    [SerializeField] private float MinimumDistanceForGeneratingNewParts;
    [SerializeField] private int QuantityOfThePartsWhichShouldBeGeneratedAtOneTime;
    [SerializeField] private int HowRareAreTheBombs;
    [SerializeField] private int HowRareAreTheIncreasingBlocks;

    private Transform TheFurthestPointOnTheFurthestPartOfTheRoad;
    private System.Random SystemRandomObject;
    private float SlopeOfTheNewPartOfTheRoad;

    private float GenerateFloatFromMinusNumberToNumber(float Number)
    {
        return (float)((SystemRandomObject.NextDouble() - 0.5d) * Number * 2f);
    }

    private void Start()
    {
        SystemRandomObject = new System.Random();
        TheFurthestPointOnTheFurthestPartOfTheRoad = TheFurthestPartOfTheRoadGameObject.GetComponent<PartOfTheRoad>().GetTheFurthestPoint;
    }

    private void GenerateOnePartOfTheRoad()
    {
        SlopeOfTheNewPartOfTheRoad = GenerateFloatFromMinusNumberToNumber(MaximumSlope);
        GameObject TheNewPartOfTheRoad = Instantiate(TheFurthestPartOfTheRoadGameObject);
        TheNewPartOfTheRoad.name = "New Part";
        TheNewPartOfTheRoad.transform.position = TheFurthestPointOnTheFurthestPartOfTheRoad.position +
            LengthOfOnePartTheRoad / 2f * new Vector3(Mathf.Cos(SlopeOfTheNewPartOfTheRoad * Mathf.Deg2Rad), Mathf.Sin(SlopeOfTheNewPartOfTheRoad * Mathf.Deg2Rad), 0);
        TheNewPartOfTheRoad.transform.eulerAngles = SlopeOfTheNewPartOfTheRoad * Vector3.forward;
        TheFurthestPartOfTheRoadGameObject = TheNewPartOfTheRoad;

        PartOfTheRoad TheFurthestPartOfTheRoad = TheFurthestPartOfTheRoadGameObject.GetComponent<PartOfTheRoad>();
        TheFurthestPointOnTheFurthestPartOfTheRoad = TheFurthestPartOfTheRoad.GetTheFurthestPoint;

        void DecideIfGameObjectShouldBePresent(ref GameObject GameObjectForDecision, int ProbabilityOfPresenceCoefficient)
        {
            int NumberWhichShowsIfGameObjectShouldBePresent = SystemRandomObject.Next(1, ProbabilityOfPresenceCoefficient);
            bool ShouldGameObjectBePresent = NumberWhichShowsIfGameObjectShouldBePresent == 1 ? true : false;
            GameObjectForDecision.SetActive(ShouldGameObjectBePresent);
        }

        GameObject TheBomb = TheFurthestPartOfTheRoad.GetBomb;
        DecideIfGameObjectShouldBePresent(ref TheBomb, HowRareAreTheBombs);

        GameObject IncreasingTheQuantityOfTheProjectiles = TheFurthestPartOfTheRoad.GetIncreasingTheQuantityOfTheProjectiles;
        DecideIfGameObjectShouldBePresent(ref IncreasingTheQuantityOfTheProjectiles, HowRareAreTheIncreasingBlocks);
    }

    private void GenerateSeveralPartsOfTheRoad(int QuantityOfThePartsWhichShouldBeGenerated)
    {
        for (int i = 0; i < QuantityOfThePartsWhichShouldBeGenerated; i++)
        {
            GenerateOnePartOfTheRoad();
        }
    }

    private void Update()
    {
        if((TheFurthestPointOnTheFurthestPartOfTheRoad.position.x - Tank.transform.position.x) <= MinimumDistanceForGeneratingNewParts)
        {
            GenerateSeveralPartsOfTheRoad(QuantityOfThePartsWhichShouldBeGeneratedAtOneTime);
        }
    }
}