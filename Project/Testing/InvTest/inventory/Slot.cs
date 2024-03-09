using Godot;
using System;

public partial class Slot : PanelContainer
{
	[Export(PropertyHint.None)]
	public SlotData[] slot_datas;

	private TextureRect textureRect;
	private Label quantityLabel;

	public override void _Ready()
	{
		textureRect = GetNode<TextureRect>("MarginContainer/TextureRect");
		quantityLabel = GetNode<Label>("QuantityLabel");
	}

	public void set_slot_data(SlotData slot_data) {
		var item_data = slot_data.item_data;
		textureRect.Texture = item_data.Texture;

		if (slot_data.quantity > 1) {
			quantityLabel.Text = String.Format("x{0}", slot_data.quantity);
			quantityLabel.Show();
		}
	}
}
