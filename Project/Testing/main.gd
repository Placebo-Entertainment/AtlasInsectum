extends Node2D

@onready var character_bro = $CharacterBro
@onready var inventory_interface = $UI/InventoryInterface

const TEST_INV = preload("res://Testing/InvTest/test_inv.tres")

func _ready():	
	character_bro.ToggleInventory.connect(toggle_inventory_interface)
	inventory_interface.set_player_inventory_data(TEST_INV)

func toggle_inventory_interface():
	inventory_interface.visible = not inventory_interface.visible
