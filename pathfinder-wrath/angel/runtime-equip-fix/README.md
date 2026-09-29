# Hansen runtime equipment fix

This is the safer replacement for direct `party.json` equipment editing.

It equips the Daeran/Sosiel loadout recorded in [../Gear.md](../Gear.md) **inside the running game**, using Owlcat's own `ItemSlot.RemoveItem()` and `ItemSlot.InsertItem()` methods. That lets the game create/update `HoldingSlot`, `m_WielderRef`, armor modifiers, enchantment state, equipment facts, slot indices, and equipment-weight state itself.

It also fills Camellia's empty neck slot with `CameliaAmuletItem`, as recorded in `Gear.md`.

## Why this exists

Two raw-save edits produced a blank Inventory window with:

```
NullReferenceException
  at Kingmaker.Items.UnitBody.Recalculate()
  at Kingmaker.UnitLogic.EncumbranceHelper.GetAllCharactersEquipmentWeight()
```

The raw-save experiments are documented in [../InventoryEditProblem.md](../InventoryEditProblem.md). Do not use those edits on the good save.

## Build and install

Close `Wrath.exe`.

From PowerShell in this folder:

```powershell
.\Build.ps1
```

The script assumes the game is installed at:

```
C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure
```

If not:

```powershell
.\Build.ps1 -GameDir "D:\path\to\Pathfinder Second Adventure"
```

It builds and copies:

```
Mods\HansenRuntimeEquipFix\HansenRuntimeEquipFix.dll
Mods\HansenRuntimeEquipFix\Info.json
```

You need a .NET SDK capable of building `net481`. The project restores the .NET Framework reference-assemblies package automatically.

## Use

1. Keep `Quick_7.zks.bak-20260930-gear` untouched.
2. Start the game.
3. Load the restored good Hansen save (`Quick_7.zks` / `Quicksave1 1`).
4. Open Unity Mod Manager.
5. Open **Hansen Runtime Equip Fix**.
6. Click **Equip Daeran + Sosiel (+ Camellia neck)** once.
7. Immediately open Inventory with `I`.
8. Verify Daeran and Sosiel are wearing the planned gear.
9. If Inventory works, create a **new manual save**. Do not overwrite the pre-edit backup yet.
10. Quit the game. The mod can then be removed; the equipment state is saved normally by Owlcat.

The button is idempotent for slots already containing the intended blueprint: it skips those slots.

## Exact allocation

The code follows `Gear.md`.

Daeran:
- `ChainshirtAcidResistance30Plus5`
- `DLC3_RobeOfTheSinmageItem`
- `BeltOfPerfection8` from Woljif
- `HeadbandOfPerfection8` from Greybor
- `DLC3_GlassesOfundeniableTruthItem` from Galfrey
- `BootsOfFreestReinItem` from Lann
- `StarEmbroideredGlovesItem`
- `AmuletOfNaturalArmor7` from Regill
- `RingOfProtection7` from Nenio
- `DLC3_RingOfInstantTriumphItem` from Greybor
- `CloakOfResistance7` from Woljif
- `RapierPlus5`

Sosiel:
- `MithralFullplateStandartPlus5`
- `DawnflowersKiss_Good_Scimitar`
- `TheUndyingLoveOfTheHopebringerShieldItem`
- `BootsOfStampedeItem`
- `GlovesOfMartialExcellenceItem`
- `GogglesOfPiercingGazeItem`
- `RingOfEvasionItem` from Regill
- `PaladinsRingItem`
- `BeltOfPerfection8` from Regill
- `HeadbandOfPerfection8` from Regill
- `CloakOfResistance7` from Regill
- `BracersOfHeavyHandItem` from Regill
- `AmuletOfNaturalArmor7` from Lann

Camellia:
- `CameliaAmuletItem` in Neck

For donor items the mod unequips them through the game's API before inserting them into the target slot. For stash stacks, `InsertItem` is allowed to perform Owlcat's normal one-item split.

## If it does not compile

Do not return to raw `party.json` editing. Give this folder to Cursor/Grok and ask only for **compile fixes against the installed WotR 2.7.0x assemblies**, preserving the runtime `RemoveItem -> InsertItem` approach and the exact allocation above.
