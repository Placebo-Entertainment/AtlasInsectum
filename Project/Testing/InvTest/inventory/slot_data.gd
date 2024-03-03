extends Resource
class_name SlotData

@export var item_data: ItemData
@export_range(1, 99) var quantity: int = 1: set = set_quantity

func set_quantity(value: int) -> void:
	quantity = value
	if quantity > item_data.stack_size:
		quantity = item_data.stack_size
		push_error("%s can not be stacked to %s, setting quantity to max value %s" % [item_data.name, quantity, item_data.stack_size])
