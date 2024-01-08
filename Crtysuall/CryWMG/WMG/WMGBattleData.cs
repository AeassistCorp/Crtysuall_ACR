using Common.Define;

namespace CryWMG.WMG;

public class WMGBattleData
{
    public static WMGBattleData Instance = new();

    public void Reset()
    {
        Instance = new WMGBattleData();
        SpellQueueGCD.Clear();
        SpellQueueoGCD.Clear();
    }
    public Queue<Spell> SpellQueueGCD = new();
    public Queue<Spell> SpellQueueoGCD = new();
}