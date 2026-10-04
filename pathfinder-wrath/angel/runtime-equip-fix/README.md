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
.\Build.ps1 -GameDir "C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure"
```

It builds and copies:

```
Mods\HansenRuntimeEquipFix\HansenRuntimeEquipFix.dll
Mods\HansenRuntimeEquipFix\Info.json
```

You need a .NET SDK capable of building `net481`. The project restores the .NET Framework reference-assemblies package automatically.

On this machine, 2026-09-30, `Build.ps1` did not run. `C:\Program Files\dotnet\dotnet.exe` is installed, but `dotnet --list-sdks` is empty. Only runtimes are present (`Microsoft.NETCore.App` 6.0.11, 8.0.19, and 8.0.21). `dotnet build` stopped with `No .NET SDKs were found`. Do not treat that as a source or API error.

## Verified compile without a .NET SDK

This is the compile that succeeded against the local WotR 2.7.0x assemblies. `Main.cs` was not changed. `party.json` was not changed.

Compiler, from Visual Studio 2022 Build Tools:

```
C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\Roslyn\csc.exe
```

Game assemblies, from:

```
C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure\Wrath_Data\Managed
```

Close `Wrath.exe`, then from PowerShell:

```powershell
$root = "C:\Users\timeg\Desktop\download\games\pathfinder-wrath\angel\runtime-equip-fix"
$managed = "C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure\Wrath_Data\Managed"
$fx = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319"
$csc = "C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\Roslyn\csc.exe"
$outDir = Join-Path $root "bin\Release"
New-Item -ItemType Directory -Force -Path $outDir | Out-Null
& $csc /nologo /target:library /langversion:latest /nullable:disable `
  /out:"$outDir\HansenRuntimeEquipFix.dll" `
  (Join-Path $root "Main.cs") `
  /r:"$managed\Assembly-CSharp.dll" `
  /r:"$managed\UnityEngine.CoreModule.dll" `
  /r:"$managed\UnityEngine.IMGUIModule.dll" `
  /r:"$managed\UnityModManager\UnityModManager.dll" `
  /r:"$fx\mscorlib.dll" `
  /r:"$fx\System.dll" `
  /r:"$fx\System.Core.dll"
```

That command exited 0 with no compiler messages. The output DLL is 15872 bytes, SHA256 `0A48CCD0149175395E3FC3768C1433077B49B606760C22C373FFACBF065153DD`.

Install by copying the DLL and `Info.json` to:

```
C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure\Mods\HansenRuntimeEquipFix\
```

The installed copy was checked against that hash. Unity Mod Manager on this machine is 0.32.4, which is newer than the `0.31.1` minimum in `Info.json`. The detected game version string is `2.7.0x`.

## Restore the already built mod

`dist\HansenRuntimeEquipFix\` is the backup of that successful build:

```
dist\HansenRuntimeEquipFix\HansenRuntimeEquipFix.dll
dist\HansenRuntimeEquipFix\Info.json
```

The DLL hash matches the file installed in `Mods\HansenRuntimeEquipFix`. If the game directory is gone, put the game back, then copy this folder over the mod folder. No compiler is required.

```powershell
$game = "C:\Program Files (x86)\Steam\steamapps\common\Pathfinder Second Adventure"
$dist = "C:\Users\timeg\Desktop\download\games\pathfinder-wrath\angel\runtime-equip-fix\dist\HansenRuntimeEquipFix"
$dest = Join-Path $game "Mods\HansenRuntimeEquipFix"
New-Item -ItemType Directory -Force -Path $dest | Out-Null
Copy-Item (Join-Path $dist "HansenRuntimeEquipFix.dll") $dest -Force
Copy-Item (Join-Path $dist "Info.json") $dest -Force
```

`bin\Release\` is only the local compiler output. Use `dist\HansenRuntimeEquipFix\` when restoring.

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

The 2026-09-30 build already succeeded with the Visual Studio compiler above. Do not rebuild, and do not edit `Main.cs`, unless this source or the installed assemblies have changed.

If a later compile fails, do not return to raw `party.json` editing. Fix only the compile error against the installed WotR 2.7.0x assemblies. Keep `ItemSlot.RemoveItem()` then `ItemSlot.InsertItem()`, and keep the allocation above.
