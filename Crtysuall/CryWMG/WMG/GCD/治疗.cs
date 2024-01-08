using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;
namespace CryWMG.WMG.GCD;

public class 治疗 : ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.Gcd;

    public int Check()
    {
        //检查等级
        if(Core.Me.ClassLevel >= 30) return -3;
        //检查开关
        if (!Qt.GetQt("GCD治疗")) return -3;
        //检查CD
        if (!SpellsDefine.Cure.IsReady()) return -3;
        CharacterAgent skillTarget;
        skillTarget = PartyHelper.CastableAlliesWithin30
            .Where(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.CurePP && !r.IsInvincible())
            .OrderBy(r => r.CurrentHealthPercent)
            .FirstOrDefault();
        if (!skillTarget.IsValid) return -2;
        return 0;
    }

    public void Build(Slot slot)
    {
        CharacterAgent skillTarget;
        skillTarget = PartyHelper.CastableAlliesWithin30
            .Where(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.CurePP && !r.IsInvincible())
            .OrderBy(r => r.CurrentHealthPercent)
            .FirstOrDefault();
        slot.Add(new Spell(SpellsDefine.Cure, skillTarget));
    }
}