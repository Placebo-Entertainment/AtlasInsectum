using Godot;
using System;

public partial class InventoryInterface : Control
{
	[Export(PropertyHint.None)]
	public SlotData[] slot_datas;

	public Inventory playerInventory;

	public override void _Ready()
	{
		playerInventory = GetNode<Inventory>("PlayerInventory");
	}

	public void set_player_inventory_data(InventoryData inventory_data) {
		playerInventory.set_inventory_data(inventory_data);
	}
}
