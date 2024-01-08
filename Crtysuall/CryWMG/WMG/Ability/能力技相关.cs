using CombatRoutine;

namespace CryWMG.WMG.Ability;

public class 能力技相关 : ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.OffGcd;

    public int Check()
    {
        //检查队列中有无技能
        if (WMGBattleData.Instance.SpellQueueoGCD.Count>0)
        {
            //检查队列第一个是否可用
            if (WMGBattleData.Instance.SpellQueueoGCD.Peek().Charges>=1)
            {
                return 1;
            }
            
        }
        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(WMGBattleData.Instance.SpellQueueoGCD.Peek());
    }
}