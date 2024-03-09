using Godot;
using System;

public partial class Main : Node2D
{
	[Export(PropertyHint.None)]
	public SlotData[] slot_datas;

	private PlayerController characterBro;
	
	private InventoryInterface inventoryInterface;

	public override void _Ready()
	{
		characterBro = GetNode<PlayerController>("CharacterBro");
		inventoryInterface = GetNode<InventoryInterface>("UI/InventoryInterface");

		inventoryInterface.set_player_inventory_data(characterBro.inventoryData);

		characterBro.ToggleInventory += Toggle_inventory_interface;
	}

	public void Toggle_inventory_interface() {
		inventoryInterface.Visible = !inventoryInterface.Visible;
	}
}
	
