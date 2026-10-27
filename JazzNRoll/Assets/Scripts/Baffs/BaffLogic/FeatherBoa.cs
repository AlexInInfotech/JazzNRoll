using UnityEngine;
[CreateAssetMenu(fileName = "FeatherBoa", menuName = "Baffs/FeatherBoa")]
public class FeatherBoa : Baff
{
    [SerializeField] byte extraPity;
    public override void Start()
    {
        BaffManager.AddToPity(extraPity);
    }
}
