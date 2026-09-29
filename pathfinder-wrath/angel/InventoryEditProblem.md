# Inventory edit status, 2026-09-30 04:39

The inventory window opens again. Daeran and Sosiel are still naked in `Hansen amulet test` because that file only changes Camellia's neck.

## What the screenshots show

`Hansen amulet test` loads. Pressing I opens the inventory. Sosiel's and Daeran's paper dolls are empty. The shared stash is still full. That is the intended content of the test file. It does not equip those two characters.

The only change in that file is Camellia's own amulet, blueprint `94b2b8b9ef254344cbc71663fecf8b99`, item `630f4d77-5c98-44f1-9d2f-d81e4c3b1c11`, on neck slot `$id` `5415`. Click Camellia, not Daeran or Sosiel, to see whether that one item appears.

## Files

```
C:\Users\timeg\AppData\LocalLow\Owlcat Games\Pathfinder Wrath Of The Righteous\Saved Games
```

| File | Header name | party.json | Safe to load |
|---|---|---|---|
| `Quick_7.zks` | `Quicksave1 1` | 2793831 characters, the pre-edit backup | Yes |
| `Quick_7.zks.bak-20260930-gear` | `Quicksave1 1` | same bytes as `Quick_7.zks` | Yes |
| `Manual_Hansen_inventory_ok.zks` | `Hansen inventory ok` | same party.json as the backup | Yes |
| `Manual_Hansen_amulet_test.zks` | `Hansen amulet test` | one neck edit, described below | Yes. Inventory opened |
| `Quick_7.zks.broken-gear` | old broken rewrite | do not load | No |

Player: Hansen. GameId: `fea04e92a6f54507a84b86b8444eec8f`.

## Crash from the earlier edits

```
NullReferenceException
  at Kingmaker.Items.UnitBody.Recalculate ()
  at Kingmaker.UnitLogic.EncumbranceHelper.GetAllCharactersEquipmentWeight ()
  at Kingmaker.UI.MVVM._VM.ServiceWindows.Inventory.InventoryStashVM..ctor
```

Edit 1 rewrote all of `party.json` with `json.dumps`. The inventory opened blank.

Edit 2 did not rewrite the file, but it moved each empty slot's `$id` definition from `Body` onto `Item.HoldingSlot`, and turned the body field into `{"$ref":"..."}`. Python `json.loads` succeeded. The inventory still crashed in `UnitBody.Recalculate`.

## Edit 3, the amulet test that opens

ChatGPT's conclusion: do not move the slot `$id`. Early Kingmaker save edits that worked kept the `$id` on the body and pointed `HoldingSlot` back at it with `$ref`. `m_Modifiers` is rebuilt by `ItemEntityArmor.RecalculateStats` and must not be copied from another character.

The amulet test follows that and does not call `json.dumps` on `party.json`.

Camellia's neck stayed:

```json
"Neck":{"$id":"5415","$type":"Kingmaker.Items.Slots.EquipmentSlot`1[[Kingmaker.Blueprints.Items.Equipment.BlueprintItemEquipmentNeck, Assembly-CSharp]], Assembly-CSharp","m_ItemRef":"630f4d77-5c98-44f1-9d2f-d81e4c3b1c11"}
```

The item tail became:

```json
"m_WielderRef":"d489d1c3-83ff-45e0-bb90-8549b7b0c6dd","Collection":{"$ref":"17"},"HoldingSlot":{"$ref":"5415"}
```

`m_InventorySlotIndex` was removed. `m_Modifiers` was not added. `"$id":"5415"` still occurs once. `"$ref":"5415"` occurs once. The inventory window opens.

## What is still empty, and why

Daeran `d3da2a90-9520-4171-a346-c7971a171b77` and Sosiel `3e1e0b22-78e6-475f-b09c-e4beac1bbca1` were not edited in `Hansen amulet test`. Their paper dolls stay empty. Final-party priority, if a later edit equips them:

1. Hansen `360c7122-3094-4ab4-9706-04ae85f7715a` is not stripped.
2. Seelah `0ad3253d-0009-464c-8fea-5162de292bb9`, Camellia, Arueshalae `166F1D`, Ember `7ea9b3f6-19ad-4b7c-98fb-3d935bf698f3`, and Daeran come next.
3. Sosiel is last.
4. Stacks with `m_Count` greater than 1 stay in the bag. A single worn copy may be taken from Woljif, Greybor, Lann, Nenio, Galfrey, or Regill.

There is no Wrath mod that chooses the best item for a build and calls equip. Quick Swap equips only the item under the cursor. ToyBox calls `ItemSlot.InsertItem`, which is the safe runtime path, but it does not pick the party set by itself.

## Question still open

Does Camellia's neck actually show the amulet in `Hansen amulet test`? The screenshots are Daeran and Sosiel, so they do not answer that. If her neck is also empty, `m_ItemRef` plus `HoldingSlot: {$ref}` is enough to open the window and not enough for the paper doll. The next experiment on a copy, not on `Quick_7.zks`, is one slot with `"m_Active":false` so `ItemSlot.PostLoad` can run `OnDidEquipped`. Do not copy another character's `m_Modifiers` tree.
