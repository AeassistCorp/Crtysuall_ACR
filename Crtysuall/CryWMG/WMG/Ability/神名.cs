using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;
using CryWMG.WMG;


namespace CryWMG.WMG.Ability;

public class 神名 : ISlotResolver
{
    public SlotMode SlotMode { get; } = SlotMode.OffGcd;

    public int Check()
    {
        //检查等级
        if(Core.Me.ClassLevel < 60) return -3;
        //检查开关
        if (!Qt.GetQt("能力技治疗")) return -3;
        //检查CD
        if (!SpellsDefine.Tetragrammaton.IsReady()) return -1;
        //检查是否有满足条件的目标
        List<uint> Pbuff = new List<uint>
        {
            3255,
            AurasDefine.Holmgang,
            AurasDefine.Superbolide,
        };
        CharacterAgent skillTarget;
        if (WMGSettings.Instance.OnlyTank)
        {
            skillTarget = PartyHelper.CastableAlliesWithin30
                .Where(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.TetragrammatonPP && r.IsTank() && !r.IsInvincible()&&!r.HasAura(AurasDefine.LivingDead)&&!r.HasAura(AurasDefine.WalkingDead)&&!r.HasAnyAura(Pbuff,3000))
                .OrderBy(r => r.CurrentHealthPercent)
                .FirstOrDefault();
        }
        else
        {
            skillTarget = PartyHelper.CastableAlliesWithin30
                .Where(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.TetragrammatonPP && !r.IsInvincible()&&!r.HasAura(AurasDefine.LivingDead)&&!r.HasAura(AurasDefine.WalkingDead)&&!r.HasAnyAura(Pbuff,3000))
                .OrderBy(r => r.CurrentHealthPercent)
                .FirstOrDefault();
        }
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
        if (WMGSettings.Instance.OnlyTank)
        {
            skillTarget = PartyHelper.CastableAlliesWithin30
                .Where(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.TetragrammatonPP && r.IsTank() && !r.IsInvincible()&&!r.HasAura(AurasDefine.LivingDead)&&!r.HasAura(AurasDefine.WalkingDead)&&!r.HasAnyAura(Pbuff,3000))
                .OrderBy(r => r.CurrentHealthPercent)
                .FirstOrDefault();
        }
        else
        {
            skillTarget = PartyHelper.CastableAlliesWithin30
                .Where(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= WMGSettings.Instance.TetragrammatonPP && !r.IsInvincible()&&!r.HasAura(AurasDefine.LivingDead)&&!r.HasAura(AurasDefine.WalkingDead)&&!r.HasAnyAura(Pbuff,3000))
                .OrderBy(r => r.CurrentHealthPercent)
                .FirstOrDefault();
        }
        slot.Add(new Spell(SpellsDefine.Tetragrammaton, skillTarget));
    }
}