using CombatRoutine;
using Common;
using Common.Define;

namespace CryWMG.WMG.GCD;

public class 复活 : ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.Gcd;
    public int Check()
    {
        //没即刻不拉
        if (!SpellsDefine.Swiftcast.IsReady()) return -3;
        //是否打开拉人开关
        if (!Qt.GetQt("拉人")) return -3;
        //没蓝不拉
        if (Core.Me.CurrentMana < 2400 && !SpellsDefine.ThinAir.IsReady()) return -2;
        //检查有没有死的人
        var skillTarget = PartyHelper.DeadAllies.FirstOrDefault(r => !r.HasAura(AurasDefine.Raise));
        if (!skillTarget.IsValid) return -1;
        return 1;
    }

    public void Build(Slot slot)
    {
        var skillTarget = PartyHelper.DeadAllies.FirstOrDefault(r => !r.HasAura(AurasDefine.Raise));
        slot.Add(SpellsDefine.Swiftcast.GetSpell());
        if (SpellsDefine.ThinAir.IsReady()) slot.Add(SpellsDefine.ThinAir.GetSpell());
        slot.Add(new Spell(SpellsDefine.Raise, skillTarget));
    }

    
}