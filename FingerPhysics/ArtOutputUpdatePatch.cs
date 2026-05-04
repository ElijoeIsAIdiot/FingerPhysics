using HarmonyLib;
using Il2CppSLZ.Marrow;
using Il2CppSLZ.Marrow.Interaction;
using Il2CppSLZ.Marrow.Utilities;
using Il2CppSLZ.VRMK;
using System.Collections.Generic;

namespace FingerPhysics
{
    [HarmonyPatch(typeof(ArtRig))]
    public static class ArtOutputUpdatePatch
    {
        public static Dictionary<ArtRig, Avatar> lastFoundAvatars = [];

        [HarmonyPatch(nameof(ArtRig.ArtOutputLateUpdate))]
        [HarmonyPostfix]
        public static void LateUpdatePostfix(ArtRig __instance)
        {
            foreach (var controller in __instance.GetComponentInParent<PhysicsRig>().GetComponentsInChildren<PhysicalFingersController>())
            {
                controller.OnApplyPoseToTransforms();
                var lastFoundAvatar = lastFoundAvatars[__instance];
                if (lastFoundAvatar == null) continue;
                if(controller.handedness == Handedness.LEFT)
                {
                    PhysicalFinger currentFinger = controller.index;
                    lastFoundAvatar.artTransforms.leftIndexProximal.SetPositionAndRotation(currentFinger.proximalArtOffset.position, currentFinger.proximalArtOffset.rotation);
                    lastFoundAvatar.artTransforms.leftIndexIntermediate.SetPositionAndRotation(currentFinger.intermediateArtOffset.position, currentFinger.intermediateArtOffset.rotation);
                    lastFoundAvatar.artTransforms.leftIndexDistal.SetPositionAndRotation(currentFinger.distalArtOffset.position, currentFinger.distalArtOffset.rotation);

                    currentFinger = controller.middle;
                    lastFoundAvatar.artTransforms.leftMiddleProximal.SetPositionAndRotation(currentFinger.proximalArtOffset.position, currentFinger.proximalArtOffset.rotation);
                    lastFoundAvatar.artTransforms.leftMiddleIntermediate.SetPositionAndRotation(currentFinger.intermediateArtOffset.position, currentFinger.intermediateArtOffset.rotation);
                    lastFoundAvatar.artTransforms.leftMiddleDistal.SetPositionAndRotation(currentFinger.distalArtOffset.position, currentFinger.distalArtOffset.rotation);
                    
                    currentFinger = controller.ring;
                    lastFoundAvatar.artTransforms.leftRingProximal.SetPositionAndRotation(currentFinger.proximalArtOffset.position, currentFinger.proximalArtOffset.rotation);
                    lastFoundAvatar.artTransforms.leftRingIntermediate.SetPositionAndRotation(currentFinger.intermediateArtOffset.position, currentFinger.intermediateArtOffset.rotation);
                    lastFoundAvatar.artTransforms.leftRingDistal.SetPositionAndRotation(currentFinger.distalArtOffset.position, currentFinger.distalArtOffset.rotation);
                    
                    currentFinger = controller.pinky;
                    lastFoundAvatar.artTransforms.leftLittleProximal.SetPositionAndRotation(currentFinger.proximalArtOffset.position, currentFinger.proximalArtOffset.rotation);
                    lastFoundAvatar.artTransforms.leftLittleIntermediate.SetPositionAndRotation(currentFinger.intermediateArtOffset.position, currentFinger.intermediateArtOffset.rotation);
                    lastFoundAvatar.artTransforms.leftLittleDistal.SetPositionAndRotation(currentFinger.distalArtOffset.position, currentFinger.distalArtOffset.rotation);
                    
                    currentFinger = controller.thumb;
                    lastFoundAvatar.artTransforms.leftThumbProximal.SetPositionAndRotation(currentFinger.proximalArtOffset.position, currentFinger.proximalArtOffset.rotation);
                    lastFoundAvatar.artTransforms.leftThumbIntermediate.SetPositionAndRotation(currentFinger.intermediateArtOffset.position, currentFinger.intermediateArtOffset.rotation);
                    lastFoundAvatar.artTransforms.leftThumbDistal.SetPositionAndRotation(currentFinger.distalArtOffset.position, currentFinger.distalArtOffset.rotation);
                }
                else
                {
                    PhysicalFinger currentFinger = controller.index;
                    lastFoundAvatar.artTransforms.rightIndexProximal.SetPositionAndRotation(currentFinger.proximalArtOffset.position, currentFinger.proximalArtOffset.rotation);
                    lastFoundAvatar.artTransforms.rightIndexIntermediate.SetPositionAndRotation(currentFinger.intermediateArtOffset.position, currentFinger.intermediateArtOffset.rotation);
                    lastFoundAvatar.artTransforms.rightIndexDistal.SetPositionAndRotation(currentFinger.distalArtOffset.position, currentFinger.distalArtOffset.rotation);

                    currentFinger = controller.middle;
                    lastFoundAvatar.artTransforms.rightMiddleProximal.SetPositionAndRotation(currentFinger.proximalArtOffset.position, currentFinger.proximalArtOffset.rotation);
                    lastFoundAvatar.artTransforms.rightMiddleIntermediate.SetPositionAndRotation(currentFinger.intermediateArtOffset.position, currentFinger.intermediateArtOffset.rotation);
                    lastFoundAvatar.artTransforms.rightMiddleDistal.SetPositionAndRotation(currentFinger.distalArtOffset.position, currentFinger.distalArtOffset.rotation);

                    currentFinger = controller.ring;
                    lastFoundAvatar.artTransforms.rightRingProximal.SetPositionAndRotation(currentFinger.proximalArtOffset.position, currentFinger.proximalArtOffset.rotation);
                    lastFoundAvatar.artTransforms.rightRingIntermediate.SetPositionAndRotation(currentFinger.intermediateArtOffset.position, currentFinger.intermediateArtOffset.rotation);
                    lastFoundAvatar.artTransforms.rightRingDistal.SetPositionAndRotation(currentFinger.distalArtOffset.position, currentFinger.distalArtOffset.rotation);

                    currentFinger = controller.pinky;
                    lastFoundAvatar.artTransforms.rightLittleProximal.SetPositionAndRotation(currentFinger.proximalArtOffset.position, currentFinger.proximalArtOffset.rotation);
                    lastFoundAvatar.artTransforms.rightLittleIntermediate.SetPositionAndRotation(currentFinger.intermediateArtOffset.position, currentFinger.intermediateArtOffset.rotation);
                    lastFoundAvatar.artTransforms.rightLittleDistal.SetPositionAndRotation(currentFinger.distalArtOffset.position, currentFinger.distalArtOffset.rotation);

                    currentFinger = controller.thumb;
                    lastFoundAvatar.artTransforms.rightThumbProximal.SetPositionAndRotation(currentFinger.proximalArtOffset.position, currentFinger.proximalArtOffset.rotation);
                    lastFoundAvatar.artTransforms.rightThumbIntermediate.SetPositionAndRotation(currentFinger.intermediateArtOffset.position, currentFinger.intermediateArtOffset.rotation);
                    lastFoundAvatar.artTransforms.rightThumbDistal.SetPositionAndRotation(currentFinger.distalArtOffset.position, currentFinger.distalArtOffset.rotation);

                }
            }
        }

        [HarmonyPatch(nameof(ArtRig.SetArtOutputAvatar))]
        [HarmonyPostfix]
        public static void SetAvatarPostfix(ArtRig __instance, Avatar avatar)
        {
            lastFoundAvatars[__instance] = avatar;
            foreach( var controller in __instance.GetComponentInParent<PhysicsRig>().GetComponentsInChildren<PhysicalFingersController>())
            {
                controller.OnAvatarSwapped(avatar);
            }
        }
    }

    [HarmonyPatch(typeof(PhysicsRig))]
    public static class PhysRigPatches
    {
        [HarmonyPatch(nameof(PhysicsRig.OnAwake))]
        [HarmonyPostfix]
        public static void OnAwake(PhysicsRig __instance)
        {
            if(Bone_Menu_Creator.ModEnabled)
            {
                PhysicalFingersController.CreatePhysicalFingers(__instance.leftHand.physHand);
                PhysicalFingersController.CreatePhysicalFingers(__instance.rightHand.physHand);
            }
        }
    }
}
