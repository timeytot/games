using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Items;
using Kingmaker.Items.Slots;
using UnityEngine;
using UnityModManagerNet;

namespace HansenRuntimeEquipFix
{
    public static class Main
    {
        private static UnityModManager.ModEntry.ModLogger Log;
        private static string Status = "Ready. Load the Hansen save, then click Equip.";

        private const string DaeranId = "d3da2a90-9520-4171-a346-c7971a171b77";
        private const string SosielId = "3e1e0b22-78e6-475f-b09c-e4beac1bbca1";
        private const string CamelliaId = "d489d1c3-83ff-45e0-bb90-8549b7b0c6dd";

        private const string WoljifId = "66befdb4-62f9-4faa-a788-65004482af56";
        private const string GreyborId = "E55C2";
        private const string GalfreyId = "5A6856";
        private const string LannId = "e437d264-30d0-4f82-b498-10d5779735e1";
        private const string RegillId = "6fb82a23-c68d-4964-aa5e-20f4c180a7ff";
        private const string NenioId = "a362b4fa-464a-43df-99cf-48216117e70b";

        private sealed class EquipSpec
        {
            public string TargetId;
            public string TargetName;
            public string SlotName;
            public string BlueprintName;
            public string DonorId;
            public Func<UnitEntityData, ItemSlot> Slot;

            public EquipSpec(string targetId, string targetName, string slotName, string blueprintName,
                Func<UnitEntityData, ItemSlot> slot, string donorId = null)
            {
                TargetId = targetId;
                TargetName = targetName;
                SlotName = slotName;
                BlueprintName = blueprintName;
                Slot = slot;
                DonorId = donorId;
            }
        }

        private static readonly List<EquipSpec> Specs = new List<EquipSpec>
        {
            // Daeran
            new EquipSpec(DaeranId, "Daeran", "Armor", "ChainshirtAcidResistance30Plus5", u => u.Body.Armor),
            new EquipSpec(DaeranId, "Daeran", "Shirt", "DLC3_RobeOfTheSinmageItem", u => u.Body.Shirt),
            new EquipSpec(DaeranId, "Daeran", "Belt", "BeltOfPerfection8", u => u.Body.Belt, WoljifId),
            new EquipSpec(DaeranId, "Daeran", "Head", "HeadbandOfPerfection8", u => u.Body.Head, GreyborId),
            new EquipSpec(DaeranId, "Daeran", "Glasses", "DLC3_GlassesOfundeniableTruthItem", u => u.Body.Glasses, GalfreyId),
            new EquipSpec(DaeranId, "Daeran", "Feet", "BootsOfFreestReinItem", u => u.Body.Feet, LannId),
            new EquipSpec(DaeranId, "Daeran", "Gloves", "StarEmbroideredGlovesItem", u => u.Body.Gloves),
            new EquipSpec(DaeranId, "Daeran", "Neck", "AmuletOfNaturalArmor7", u => u.Body.Neck, RegillId),
            new EquipSpec(DaeranId, "Daeran", "Ring 1", "RingOfProtection7", u => u.Body.Ring1, NenioId),
            new EquipSpec(DaeranId, "Daeran", "Ring 2", "DLC3_RingOfInstantTriumphItem", u => u.Body.Ring2, GreyborId),
            new EquipSpec(DaeranId, "Daeran", "Shoulders", "CloakOfResistance7", u => u.Body.Shoulders, WoljifId),
            new EquipSpec(DaeranId, "Daeran", "Primary hand", "RapierPlus5", u => u.Body.PrimaryHand),

            // Sosiel
            new EquipSpec(SosielId, "Sosiel", "Armor", "MithralFullplateStandartPlus5", u => u.Body.Armor),
            new EquipSpec(SosielId, "Sosiel", "Primary hand", "DawnflowersKiss_Good_Scimitar", u => u.Body.PrimaryHand),
            new EquipSpec(SosielId, "Sosiel", "Secondary hand", "TheUndyingLoveOfTheHopebringerShieldItem", u => u.Body.SecondaryHand),
            new EquipSpec(SosielId, "Sosiel", "Feet", "BootsOfStampedeItem", u => u.Body.Feet),
            new EquipSpec(SosielId, "Sosiel", "Gloves", "GlovesOfMartialExcellenceItem", u => u.Body.Gloves),
            new EquipSpec(SosielId, "Sosiel", "Glasses", "GogglesOfPiercingGazeItem", u => u.Body.Glasses),
            new EquipSpec(SosielId, "Sosiel", "Ring 1", "RingOfEvasionItem", u => u.Body.Ring1, RegillId),
            new EquipSpec(SosielId, "Sosiel", "Ring 2", "PaladinsRingItem", u => u.Body.Ring2),
            new EquipSpec(SosielId, "Sosiel", "Belt", "BeltOfPerfection8", u => u.Body.Belt, RegillId),
            new EquipSpec(SosielId, "Sosiel", "Head", "HeadbandOfPerfection8", u => u.Body.Head, RegillId),
            new EquipSpec(SosielId, "Sosiel", "Shoulders", "CloakOfResistance7", u => u.Body.Shoulders, RegillId),
            new EquipSpec(SosielId, "Sosiel", "Wrist", "BracersOfHeavyHandItem", u => u.Body.Wrist, RegillId),
            new EquipSpec(SosielId, "Sosiel", "Neck", "AmuletOfNaturalArmor7", u => u.Body.Neck, LannId),

            // Camellia's empty neck slot from Gear.md.
            new EquipSpec(CamelliaId, "Camellia", "Neck", "CameliaAmuletItem", u => u.Body.Neck),
        };

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            Log = modEntry.Logger;
            modEntry.OnGUI = OnGUI;
            Log.Log("HansenRuntimeEquipFix loaded.");
            return true;
        }

        private static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            GUILayout.Label("Hansen runtime equipment fix");
            GUILayout.Label("Uses Owlcat ItemSlot.RemoveItem/InsertItem. It does not edit party.json.");
            GUILayout.Label(Status);

            if (GUILayout.Button("Equip Daeran + Sosiel (+ Camellia neck)", GUILayout.Width(360)))
            {
                try
                {
                    Run();
                }
                catch (Exception ex)
                {
                    Status = "FAILED: " + ex.Message;
                    Log.Error(ex.ToString());
                }
            }
        }

        private static void Run()
        {
            if (Game.Instance == null || Game.Instance.Player == null)
                throw new InvalidOperationException("No loaded game.");

            var daeran = FindUnit(DaeranId);
            var sosiel = FindUnit(SosielId);
            if (daeran == null || sosiel == null)
                throw new InvalidOperationException("This is not the expected Hansen party: Daeran or Sosiel UnitId was not found.");

            int equipped = 0;
            int skipped = 0;
            var failures = new List<string>();

            foreach (var spec in Specs)
            {
                try
                {
                    var target = FindUnit(spec.TargetId);
                    if (target == null)
                    {
                        failures.Add(spec.TargetName + " missing");
                        continue;
                    }

                    var targetSlot = spec.Slot(target);
                    if (targetSlot == null)
                    {
                        failures.Add(spec.TargetName + " " + spec.SlotName + ": slot missing");
                        continue;
                    }

                    if (SlotHasBlueprint(targetSlot, spec.BlueprintName))
                    {
                        skipped++;
                        continue;
                    }

                    var item = FindSourceItem(spec);
                    if (item == null)
                    {
                        failures.Add(spec.TargetName + " " + spec.SlotName + ": item not found: " + spec.BlueprintName);
                        continue;
                    }

                    // If the item is currently worn by a donor, unequip it through the game API first.
                    if (item.HoldingSlot != null)
                    {
                        if (!item.HoldingSlot.RemoveItem())
                        {
                            failures.Add(spec.TargetName + " " + spec.SlotName + ": could not unequip donor item " + spec.BlueprintName);
                            continue;
                        }
                    }

                    // Preserve any replaced target item by unequipping it normally into the shared collection.
                    if (targetSlot.HasItem && !targetSlot.RemoveItem())
                    {
                        failures.Add(spec.TargetName + " " + spec.SlotName + ": could not clear target slot");
                        continue;
                    }

                    targetSlot.InsertItem(item);

                    if (!SlotHasBlueprint(targetSlot, spec.BlueprintName))
                    {
                        failures.Add(spec.TargetName + " " + spec.SlotName + ": InsertItem did not leave expected item equipped");
                        continue;
                    }

                    equipped++;
                    Log.Log("Equipped " + spec.TargetName + " / " + spec.SlotName + " / " + spec.BlueprintName);
                }
                catch (Exception ex)
                {
                    failures.Add(spec.TargetName + " " + spec.SlotName + ": " + ex.Message);
                    Log.Error(spec.TargetName + " " + spec.SlotName + ": " + ex);
                }
            }

            Status = "Done. Equipped " + equipped + ", already correct " + skipped + ", failures " + failures.Count + ".";
            if (failures.Count > 0)
            {
                Status += " See Unity Mod Manager log.";
                foreach (var f in failures)
                    Log.Warning(f);
            }
            else
            {
                Status += " Open Inventory now. If it works, make a NEW manual save before removing the mod.";
            }
        }

        private static UnitEntityData FindUnit(string id)
        {
            return Game.Instance.Player.AllCharacters
                .FirstOrDefault(u => string.Equals(Convert.ToString(u.UniqueId), id, StringComparison.OrdinalIgnoreCase));
        }

        private static ItemEntity FindSourceItem(EquipSpec spec)
        {
            var items = Game.Instance.Player.Inventory.Items;

            // For pieces explicitly assigned from a donor in Gear.md, prefer that exact worn copy.
            if (!string.IsNullOrEmpty(spec.DonorId))
            {
                var donor = FindUnit(spec.DonorId);
                if (donor != null)
                {
                    var worn = items.FirstOrDefault(i =>
                        ItemMatches(i, spec.BlueprintName) &&
                        i.HoldingSlot != null &&
                        ReferenceEquals(i.HoldingSlot.Owner, donor));
                    if (worn != null)
                        return worn;
                }
            }

            // Otherwise use an unworn shared-inventory copy. Runtime InsertItem safely splits stacks itself.
            return items.FirstOrDefault(i => ItemMatches(i, spec.BlueprintName) && i.HoldingSlot == null);
        }

        private static bool ItemMatches(ItemEntity item, string blueprintName)
        {
            return item != null &&
                   item.Blueprint != null &&
                   string.Equals(item.Blueprint.name, blueprintName, StringComparison.Ordinal);
        }

        private static bool SlotHasBlueprint(ItemSlot slot, string blueprintName)
        {
            return slot != null &&
                   slot.MaybeItem != null &&
                   ItemMatches(slot.MaybeItem, blueprintName);
        }
    }
}
