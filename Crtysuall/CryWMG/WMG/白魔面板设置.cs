#region

using CombatRoutine.View;
using Common.GUI;
using Common.Language;
using CryWMG.WMG;
using ImGuiNET;


#endregion

namespace CryWMG.WMG;

public class HealWMGSettingView : ISettingUI
{
    public string Name => "白魔";

    public void Draw()
    {
        ImGui.Text("日随练级用ACR，如果你真敢拿去打高难，被挂了nga链接发我");

       ImGuiHelper.LeftInputInt("群抬数目", ref WMGSettings.Instance.Curenum);
        {
            WMGSettings.Instance.save();
        }

        if (ImGui.SliderFloat("医济阈值", ref WMGSettings.Instance.MedicalIIPP, 0.0f, 1.0f))
        {
            WMGSettings.Instance.save();
        }

        if (ImGui.SliderFloat("医治阈值", ref WMGSettings.Instance.MedicalPP, 0.0f, 1.0f))
        {
            WMGSettings.Instance.save();
        }

        if (ImGui.SliderFloat("愈疗阈值", ref WMGSettings.Instance.CureIIIPP, 0.0f, 1.0f))
        {
            WMGSettings.Instance.save();
        }

        if (ImGui.SliderFloat("治疗阈值", ref WMGSettings.Instance.CurePP, 0.0f, 1.0f))
        {
            WMGSettings.Instance.save();
        }

        if (ImGui.SliderFloat("救疗阈值", ref WMGSettings.Instance.CureIIPP, 0.0f, 1.0f))
        {
            WMGSettings.Instance.save();
        }

        if (ImGui.SliderFloat("再生阈值", ref WMGSettings.Instance.RegenPP, 0.0f, 1.0f))
        {
            WMGSettings.Instance.save();
        }

        if (ImGui.SliderFloat("狂喜之心阈值", ref WMGSettings.Instance.AfflatusRapturePP, 0.0f, 1.0f))
        {
            WMGSettings.Instance.save();
        }

        if (ImGui.SliderFloat("安慰之心阈值", ref WMGSettings.Instance.AfflatusSolacePP, 0.0f, 1.0f))
        {
            WMGSettings.Instance.save();
        }
        if (ImGui.SliderFloat("神名阈值", ref WMGSettings.Instance.TetragrammatonPP, 0.0f, 1.0f))
        {
            WMGSettings.Instance.save();
        }
        if (ImGui.SliderFloat("神祝祷阈值", ref WMGSettings.Instance.DivineBenisonPP, 0.0f, 1.0f))
        {
            WMGSettings.Instance.save();
        }
        if (ImGui.SliderFloat("全大赦阈值", ref WMGSettings.Instance.PlenaryPP, 0.0f, 1.0f))
        {
            WMGSettings.Instance.save();
        }
        if (ImGui.SliderFloat("天赐阈值", ref WMGSettings.Instance.BenedictionPP, 0.0f, 1.0f))
        {
            WMGSettings.Instance.save();
        }

        if (ImGui.SliderFloat("不上dot阈值", ref WMGSettings.Instance.dotpercent, 0.0f, 1.0f))
        {
            WMGSettings.Instance.save();
        }

        
        ImGui.Text("点击此按钮设置为默认阈值设置");
        if (ImGui.Button("默认设置"))
        {
            WMGSettings.Instance.BenedictionPP = 0.3f;
            WMGSettings.Instance.AfflatusRapturePP = 0.6f;
            WMGSettings.Instance.CureIIIPP = 0.4f;
            WMGSettings.Instance.CureIIPP = 0.4f;
            WMGSettings.Instance.CurePP = 0.4f;
            WMGSettings.Instance.MedicalPP = 0.6f;
            WMGSettings.Instance.MedicalIIPP = 0.6f;
            WMGSettings.Instance.AquaveilPP = 0.7f; 
            WMGSettings.Instance.DivineBenisonPP = 0.8f; 
            WMGSettings.Instance.RegenPP = 0.3f;
            WMGSettings.Instance.PlenaryPP = 0.6f;
            WMGSettings.Instance.TetragrammatonPP = 0.75f;
            WMGSettings.Instance.AfflatusSolacePP = 0.4f; 
            WMGSettings.Instance.dotpercent = 0.03f;
            WMGSettings.Instance.save();
        }

        ImGui.Text("点击此按钮设置为本分奶阈值设置");
        if (ImGui.Button("本分奶设置"))
        {
            WMGSettings.Instance.BenedictionPP = 0.3f;
            WMGSettings.Instance.AfflatusSolacePP = 0.5f; 
            WMGSettings.Instance.AfflatusRapturePP = 0.75f;
            WMGSettings.Instance.CureIIIPP = 0.5f;
            WMGSettings.Instance.CureIIPP = 0.5f;
            WMGSettings.Instance.CurePP = 0.5f;
            WMGSettings.Instance.MedicalPP = 0.75f;
            WMGSettings.Instance.MedicalIIPP = 0.75f;
            WMGSettings.Instance.AquaveilPP = 0.8f; 
            WMGSettings.Instance.DivineBenisonPP = 0.8f; 
            WMGSettings.Instance.RegenPP = 0.4f;
            WMGSettings.Instance.PlenaryPP = 0.6f;
            WMGSettings.Instance.TetragrammatonPP = 0.75f;
            WMGSettings.Instance.dotpercent = 0.03f;
            WMGSettings.Instance.save();
        }

        ImGui.Text("点击此按钮设置为输出奶阈值设置");
        if (ImGui.Button("输出设置"))
        {
            WMGSettings.Instance.BenedictionPP = 0.3f;
            WMGSettings.Instance.AfflatusSolacePP = 0.35f; 
            WMGSettings.Instance.AfflatusRapturePP = 0.55f;
            WMGSettings.Instance.CureIIIPP = 0.35f;
            WMGSettings.Instance.CureIIPP = 0.35f;
            WMGSettings.Instance.CurePP = 0.35f;
            WMGSettings.Instance.MedicalPP = 0.55f;
            WMGSettings.Instance.MedicalIIPP = 0.55f;
            WMGSettings.Instance.AquaveilPP = 0.8f; 
            WMGSettings.Instance.DivineBenisonPP = 0.8f; 
            WMGSettings.Instance.RegenPP = 0.3f;
            WMGSettings.Instance.PlenaryPP = 0.6f;
            WMGSettings.Instance.TetragrammatonPP = 0.75f;
            WMGSettings.Instance.dotpercent = 0.03f;
            WMGSettings.Instance.save();
        }

      
    }
}