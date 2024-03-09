using Godot;
using System;

[GlobalClass]
public partial class SlotData : Resource
{
	[Export(PropertyHint.None)]
	public ItemData item_data;

	private int _quantity;

	[Export(PropertyHint.Range, "1,99,1")]
	public int quantity
	{
		get => _quantity;
		set
		{
			if (value > item_data.Stack_size)
			{
				_quantity = item_data.Stack_size;
				GD.PushError(String.Format("{0} can not be stacked to {1}, setting quantity to max value {2}", item_data.Name, value, item_data.Stack_size));
			} else {
				_quantity = value;
			}
		}
	}
}
