using Godot;
using System;

public partial class Inventory : PanelContainer
{
	private PackedScene slot = GD.Load<PackedScene>("res://Testing/InvTest/inventory/Slot.tscn");

	private GridContainer item_grid;

	public override void _Ready()
	{
		item_grid = GetNode<GridContainer>("MarginContainer/ItemGrid");
	}

	public void set_inventory_data(InventoryData inventory_data) {
		populate_item_grid(inventory_data.slot_datas);
	}

	public void populate_item_grid(SlotData[] slot_datas) {
		foreach (Node child in item_grid.GetChildren())
		{
			child.QueueFree();
		}

		foreach (SlotData slot_data in slot_datas) {
			Slot currentSlot = (Slot) slot.Instantiate();
			item_grid.AddChild(currentSlot);

			if (slot_data != null) {
				currentSlot.set_slot_data(slot_data);
			}
		}
	}
}

