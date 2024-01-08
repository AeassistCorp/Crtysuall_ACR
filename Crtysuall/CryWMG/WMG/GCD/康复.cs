using System.Runtime.InteropServices;
using CombatRoutine;
using Common;
using Common.Define;
using Common.Helper;

namespace CryWMG.WMG.GCD;

public class 康复 : ISlotResolver
{

    public SlotMode SlotMode { get; } = SlotMode.Gcd;
    public int Check()
    {
        if (Core.Get<IMemApiMove>().IsMoving())
        {
            return -1;
        }

        if (PartyHelper.CastableAlliesWithin30.Any(agent => agent.HasCanDispel()))
        {
            return 1;
        }

        return -1;

    }

    public void Build(Slot slot)
    {
        slot.Add(new Spell(SpellsDefine.Esuna,PartyHelper.CastableAlliesWithin30.FirstOrDefault(agent=>agent.HasCanDispel())));
    }

  
}