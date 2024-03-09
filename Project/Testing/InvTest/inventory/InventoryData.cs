using Godot;
using System;

[GlobalClass]
public partial class InventoryData : Resource
{
	[Export(PropertyHint.None)]
	public SlotData[] slot_datas;
}
