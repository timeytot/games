# Inventory screen breaks after equipping items in a WotR save

This note is for review. The game is Pathfinder: Wrath of the Righteous (Unity 2020.3). A `.zks` save is a zip. `party.json` uses Unity `$id` / `$ref`.

The goal was to equip two naked characters from the shared inventory. Two edits were tried. Both made the inventory screen open as a blank page. Both edits have been reverted. The playable file is the pre-edit backup.

## Current files

Saved Games folder:

```
C:\Users\timeg\AppData\LocalLow\Owlcat Games\Pathfinder Wrath Of The Righteous\Saved Games
```

| File | What it is |
|---|---|
| `Quick_7.zks` | Restored pre-edit save. Header name `Quicksave1 1`. Player Hansen. GameId `fea04e92a6f54507a84b86b8444eec8f`. 2053668 bytes. `party.json` is 2793831 characters |
| `Quick_7.zks.bak-20260930-gear` | Same bytes as the restored `Quick_7.zks`. Timestamp 2026-09-30 03:18:30 |
| `Manual_Hansen_inventory_ok.zks` | Same `party.json` as the backup. Header name changed to `Hansen inventory ok` |
| `Quick_7.zks.broken-gear` | First failed edit. The whole `party.json` was rewritten with `json.dumps`. 1980577 bytes |

The second edit, which only replaced item tails, was not kept as its own file. It was overwritten when `Quick_7.zks` was restored from the backup.

## Crash

After the second edit, pressing I opened a blank inventory. `Player.log` says:

```
NullReferenceException: Object reference not set to an instance of an object
  at Kingmaker.Items.UnitBody.Recalculate ()
  at Kingmaker.UnitLogic.EncumbranceHelper.GetAllCharactersEquipmentWeight ()
  at Kingmaker.UI.MVVM._VM.ServiceWindows.Inventory.InventoryStashVM..ctor
  at Kingmaker.UI.MVVM._VM.ServiceWindows.Inventory.InventoryVM..ctor
  at Kingmaker.UI.MVVM._VM.ServiceWindows.ServiceWindowsVM.ShowWindow
```

The character select screen still opens. Only the inventory window fails. `UnitBody.Recalculate()` walks every character, so one bad slot blanks the whole window.

## Save layout that worked before any edit

The Shared Stash grid is not `player.json` `SharedStash`. That object had 2 items. The grid is one `Descriptor.m_Inventory`. Every companion's `m_Inventory` is a `$ref` to it. This save has about 532 item entities in that collection.

A worn armor, copied from the good save:

```json
"Armor":{"$ref":"204"}
```

```json
"m_FactsAppliedToWielder":[],
"m_WielderRef":"E55C2",
"Collection":{"$ref":"17"},
"HoldingSlot":{"$id":"204","$type":"Kingmaker.Items.Slots.ArmorSlot, Assembly-CSharp","m_ItemRef":"faec25cf-f3a0-42fb-9a40-648bfb25d4fb"},
"Time":"...","IsIdentified":true,"OriginArea":"...","UniqueId":"faec25cf-f3a0-42fb-9a40-648bfb25d4fb"
```

The `$id` of the slot is defined inside the item's `HoldingSlot`. The body only has the `$ref`. The item stays in the collection. Worn items do not have `m_InventorySlotIndex`.

An empty paper-doll slot on a naked character:

```json
"Armor":{"$id":"8113"}
```

No `$type`. No `m_ItemRef`.

An empty main-hand slot:

```json
"PrimaryHand":{"$id":"8097","ParentFact":{"EntityId":null,"FactId":null}}
```

An unworn item tail:

```json
"m_Blueprint":"...","m_InventorySlotIndex":49,"Collection":{"$ref":"17"},"Time":"...","IsIdentified":true,"OriginArea":"...","UniqueId":"..."
```

Some unworn copies are stacks: `"m_Count":2`. Those were not equipped. An unworn armor is `ItemEntityArmor` with `"m_Modifiers":null`. A worn armor has a large `m_Modifiers` tree.

Slot classes seen on worn items:

| Slot | `$type` |
|---|---|
| Armor | `Kingmaker.Items.Slots.ArmorSlot, Assembly-CSharp` |
| Hands | `Kingmaker.Items.Slots.HandSlot, Assembly-CSharp` |
| Belt and the other paper-doll slots | generic EquipmentSlot for that item type. The belt example is below |

Belt slot type, copied from a worn item:

```
Kingmaker.Items.Slots.EquipmentSlot`1[[Kingmaker.Blueprints.Items.Equipment.BlueprintItemEquipmentBelt, Assembly-CSharp]], Assembly-CSharp
```

`ChainshirtAcidResistance30Plus5` is `BlueprintItemArmor`, not `BlueprintItemEquipmentArmor`. A shield is `BlueprintItemShield` and belongs in `SecondaryHand`. `GraspOfDevotionItem` is `BlueprintItemWeapon`.

## Edit 1

Python loaded all of `party.json`, changed `m_ItemRef`, `m_WielderRef`, and `HoldingSlot`, then `json.dumps` wrote the whole file back into the zip. The inventory opened blank.

## Edit 2

The whole file was not rewritten. For each chosen item, only the tail from `Collection` through `UniqueId` was replaced with `m_WielderRef` plus a `HoldingSlot`. The body's `{"$id":"8113"}` became `{"$ref":"8113"}`, and that same `$id` was defined on the item's `HoldingSlot`. When a worn item was taken from another character, the old slot object was written back onto that character's body with `m_ItemRef` removed.

After those replacements, `json.loads` succeeded and the moved slot ids were each defined once. In game, pressing I still threw the `UnitBody.Recalculate` null reference above.

## Question

How should one unworn item be attached to an empty Owlcat / Kingmaker body slot so `UnitBody.Recalculate` does not throw? The existing `$id` graph has to stay intact. The whole `party.json` must not be reserialized. If `m_Modifiers` or another field is required before the inventory screen can open, which fields are the minimum?
