using MelonLoader;

namespace FingerPhysics;

public class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        Bone_Menu_Creator.OnInitialize();
    }
}
