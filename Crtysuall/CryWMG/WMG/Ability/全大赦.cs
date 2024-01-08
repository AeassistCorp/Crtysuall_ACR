using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;

namespace CryWMG.WMG.Ability;

public class 全大赦 : ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.OffGcd;

    public int Check()
    {
        //等级
        if(Core.Me.ClassLevel < 70) return -3;
        //检查CD
        if (!SpellsDefine.PlenaryIndulgence.IsReady()) return -1;
        //检查开关
       
        if (!Qt.GetQt("能力技治疗")) return -3;
        //检查满足条件人数
        var skillTarget = PartyHelper.CastableAlliesWithin15.Count(r =>
            r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.PlenaryPP);
        if (skillTarget > WMGSettings.Instance.Curenum) return 0;
        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(SpellsDefine.PlenaryIndulgence.GetSpell());
    }
}