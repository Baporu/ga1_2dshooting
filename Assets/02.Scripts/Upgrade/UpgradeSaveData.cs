[System.Serializable]
public class UpgradeSaveData
{
    public UpgradeType[] Type;
    public int[] Level;

    public UpgradeSaveData(int count)
    {
        Type = new UpgradeType[count];
        Level = new int[count];
    }
}