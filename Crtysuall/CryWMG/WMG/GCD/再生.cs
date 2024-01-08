using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;
namespace CryWMG.WMG.GCD;

public class 再生:ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.Gcd;
    public int Check()
    {
        //检查等级
        if(Core.Me.ClassLevel < 35) return -3;
        //检查开关
        if (!Qt.GetQt("GCD治疗")) return -3;
        if (!Qt.GetQt("再生")) return -3;
        //检查CD
        if (!SpellsDefine.Regen.IsReady()) return -3;
        List<uint> Pbuff = new List<uint>
        {
            3255,
            AurasDefine.Holmgang,
            AurasDefine.Superbolide,
        };
        CharacterAgent skillTarget;
        skillTarget = PartyHelper.CastableAlliesWithin30
            .Where(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.RegenPP && !r.IsInvincible()&&!r.HasMyAuraWithTimeleft(AurasDefine.Regen)&& !r.IsInvincible()&&!r.HasAura(AurasDefine.LivingDead)&&!r.HasAura(AurasDefine.WalkingDead)&&!r.HasAnyAura(Pbuff,3000))
            .OrderBy(r => r.CurrentHealthPercent)
            .FirstOrDefault();
        if (!skillTarget.IsValid) return -2;
        return 0;
    }

    public void Build(Slot slot)
    {
        List<uint> Pbuff = new List<uint>
        {
            3255,
            AurasDefine.Holmgang,
            AurasDefine.Superbolide,
        };
        CharacterAgent skillTarget;
        skillTarget = PartyHelper.CastableAlliesWithin30
            .Where(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.RegenPP && !r.IsInvincible() && !r.HasMyAuraWithTimeleft(AurasDefine.Regen)&& !r.IsInvincible()&&!r.HasAura(AurasDefine.LivingDead)&&!r.HasAura(AurasDefine.WalkingDead)&&!r.HasAnyAura(Pbuff,3000))
            .OrderBy(r => r.CurrentHealthPercent)
            .FirstOrDefault();
        slot.Add(new Spell(SpellsDefine.Regen, skillTarget));
    }

    
}