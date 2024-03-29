#region

using CombatRoutine;
using CombatRoutine.View.JobView;
using Common;
using Common.Define;
using Common.GUI;
using Common.Helper;
using Common.Language;
using ImGuiNET;


#endregion

namespace CryWMG.WMG;

public class WhiteMageOverlay
{
    private bool isHorizontal;

    public void DrawGeneral(JobViewWindow jobViewWindow)
    {
        
        if (ImGui.CollapsingHeader("插入技能状态"))
        {
            if (ImGui.Button("清除队列"))
            {
                AI.Instance.BattleData.HighPrioritySlots_OffGCD.Clear();
                AI.Instance.BattleData.HighPrioritySlots_GCD.Clear();
            }

            ImGui.SameLine();
            if (ImGui.Button("清除一个"))
            {
                AI.Instance.BattleData.HighPrioritySlots_OffGCD.Dequeue();
                AI.Instance.BattleData.HighPrioritySlots_GCD.Dequeue();
            }

            ImGui.Text("-------能力技-------");
            if (AI.Instance.BattleData.HighPrioritySlots_OffGCD.Count > 0)
                foreach (var spell in AI.Instance.BattleData.HighPrioritySlots_OffGCD)
                    ImGui.Text(spell.Name);
            ImGui.Text("-------GCD-------");
            if (AI.Instance.BattleData.HighPrioritySlots_GCD.Count > 0)
                foreach (var spell in AI.Instance.BattleData.HighPrioritySlots_GCD)
                    ImGui.Text(spell.Name);
        }

        if (ImGui.CollapsingHeader("杂项设置"))
        {
            if (ImGui.Checkbox("能力技只奶T", ref WMGSettings.Instance.OnlyTank)) WMGSettings.Instance.Save();
        }
    }

    public void DrawTimeLine(JobViewWindow jobViewWindow)
    {
        var currTriggerline = AI.Instance.TriggerlineData.CurrTriggerLine;
        var notice = "无";
        if (currTriggerline != null) notice = $"[{currTriggerline.Author}]{currTriggerline.Name}";

        ImGui.Text(notice);
        if (currTriggerline != null)
        {
            ImGui.Text("导出变量:".Loc());
            ImGui.Indent();
            foreach (var v in currTriggerline.ExposedVars)
            {
                var oldValue = AI.Instance.ExposedVars.GetValueOrDefault(v);
                ImGuiHelper.LeftInputInt(v, ref oldValue);
                AI.Instance.ExposedVars[v] = oldValue;
            }

            ImGui.Unindent();
        }
    }

    public void DrawDev(JobViewWindow jobViewWindow)
    {
        if (ImGui.TreeNode("循环"))
        {
            ImGui.Text($"爆发药：{Qt.GetQt("爆发药")}");

            ImGui.TreePop();
        }

        if (ImGui.TreeNode("技能释放"))
        {
            ImGui.Text($"上个技能：{Core.Get<IMemApiSpellCastSucces>().LastSpell}");
            ImGui.Text($"上个GCD：{Core.Get<IMemApiSpellCastSucces>().LastGcd}");
            ImGui.Text($"上个能力技：{Core.Get<IMemApiSpellCastSucces>().LastAbility}");
            ImGui.TreePop();
        }

        if (ImGui.TreeNode("小队"))
        {
            ImGui.Text($"小队人数：{PartyHelper.CastableParty.Count}");
            ImGui.Text($"小队坦克数量：{PartyHelper.CastableTanks.Count}");
            ImGui.TreePop();
        }
        if (ImGui.TreeNode("CanCast"))
        {
            ImGui.Text($"闪灼：{SpellsDefine.GlareIii.GetSpell().CanCast()}");
            ImGui.Text($"医技：{SpellsDefine.Cure3.GetSpell().CanCast()}");
            ImGui.Text($"神速：{SpellsDefine.PresenceofMind.GetSpell().CanCast()}");
            ImGui.Text($"铃铛：{SpellsDefine.LiturgyOfTheBell.GetSpell().CanCast()}");
            ImGui.Text($"蓝花：{SpellsDefine.AfflatusRapture.GetSpell().CanCast()}");
            
            ImGui.Text($"闪灼：{Core.Get<IMemApiSpell>().GetActionState(SpellsDefine.GlareIii)}");
            ImGui.Text($"医技：{Core.Get<IMemApiSpell>().GetActionState(SpellsDefine.Cure3)}");
            ImGui.Text($"神速：{Core.Get<IMemApiSpell>().GetActionState(SpellsDefine.PresenceofMind)}");
            ImGui.Text($"铃铛：{Core.Get<IMemApiSpell>().GetActionState(SpellsDefine.LiturgyOfTheBell)}");
            ImGui.Text($"蓝花：{Core.Get<IMemApiSpell>().GetActionState(SpellsDefine.AfflatusRapture)}");
            
            
            
            ImGui.TreePop();
        }
        if (ImGui.TreeNode("当前目标"))
        {
            ImGui.Text($"当前目标：{Core.Me.SelfTarget().Name}");
            ImGui.Text($"当前目标：{Core.Me.SelfTarget().ObjectId}");
            ImGui.TreePop();
        }
    }


    private void DrawOverlay()
    {
    }
}

public static class Qt
{
    public static bool GetQt(string qtName)
    {
        return WhiteMageRotationEntry.JobViewWindow.GetQt(qtName);
    }

    /// 反转指定qt的值
    /// <returns>成功返回true，否则返回false</returns>
    public static bool ReverseQt(string qtName)
    {
        return WhiteMageRotationEntry.JobViewWindow.ReverseQt(qtName);
    }

    /// 设置指定qt的值
    /// <returns>成功返回true，否则返回false</returns>
    public static bool SetQt(string qtName, bool qtValue)
    {
        return WhiteMageRotationEntry.JobViewWindow.SetQt(qtName, qtValue);
    }

    /// 重置所有qt为默认值
    public static void Reset()
    {
        WhiteMageRotationEntry.JobViewWindow.Reset();
    }

    /// 给指定qt设置新的默认值
    public static void NewDefault(string qtName, bool newDefault)
    {
        WhiteMageRotationEntry.JobViewWindow.NewDefault(qtName, newDefault);
    }

    /// 将当前所有Qt状态记录为新的默认值，
    /// 通常用于战斗重置后qt还原到倒计时时间点的状态
    public static void SetDefaultFromNow()
    {
        WhiteMageRotationEntry.JobViewWindow.SetDefaultFromNow();
    }

    /// 返回包含当前所有qt名字的数组
    public static string[] GetQtArray()
    {
        return WhiteMageRotationEntry.JobViewWindow.GetQtArray();
    }
}