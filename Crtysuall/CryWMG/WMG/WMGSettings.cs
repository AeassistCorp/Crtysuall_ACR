using System.Numerics;
using CombatRoutine.View.JobView;
using Common.Helper;

namespace CryWMG.WMG;

public class WMGSettings
{
    public static WMGSettings Instance;
    private static string path;

    public static void Build(string settingPath)
    {
        path = Path.Combine(settingPath, "WMGSettings.json");
        if (!File.Exists(path))
        {
            Instance = new WMGSettings();
            Instance.Save();
            return;
        }

        try
        {
            Instance = JsonHelper.FromJson<WMGSettings>(File.ReadAllText(path));
        }
        catch (Exception e)
        {
            Instance = new WMGSettings();
            LogHelper.Error(e.ToString());
        }
    }

    public void Save()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path));
        File.WriteAllText(path, JsonHelper.ToJson(this));
    }

    public bool MedicalII;
    public bool CureIII;
    public bool AfflatusSolace;
    public bool Aquaveil = true;
    public bool Assize = true;
    public bool DivineBenison = true;
    public bool Plenary = true;
    public bool Tetragrammaton = true;
    public bool PresenceofMind = true;
    public bool ThinAir = true;
    public float BenedictionPP = 0.3f;
    public float AfflatusRapturePP = 0.6f;
    public float CureIIIPP = 0.3f;
    public float CureIIPP = 0.4f;
    public float CurePP = 0.4f;
    public float MedicalPP = 0.6f;
    public float MedicalIIPP = 0.6f;
    public float AquaveilPP = 0.7f;
    public float DivineBenisonPP = 0.8f;
    public float RegenPP = 0.3f;
    public float PlenaryPP = 0.6f;
    public float TetragrammatonPP = 0.75f;
    public float AfflatusSolacePP = 0.4f;
    public float dotpercent = 0.03f;
    public int Curenum = 2;
    public int time = 1500;
    public int opener = 0;
    public int Esuna = 2;
    public int stack = 3;
    public bool OnlyTank;
    public Dictionary<string, object> StyleSetting = new();
    public bool AutoReset = true;
    public JobViewSave JobViewSave = new(){MainColor = new Vector4(40 / 255f, 173 / 255f, 70 / 255f, 0.8f)};
    public void save()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path));
        File.WriteAllText(path, JsonHelper.ToJson(this));
    }
}