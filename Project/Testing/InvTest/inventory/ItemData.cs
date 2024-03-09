using Godot;
using System;

[GlobalClass]
public partial class ItemData : Resource
{
	[Export(PropertyHint.None)]
	public String Name { get; set; }

	[Export(PropertyHint.MultilineText)]
	public String Description  { get; set; }

	[Export(PropertyHint.None)]
	public int Stack_size  { get; set; }
	
	[Export(PropertyHint.None)]
	public AtlasTexture Texture  { get; set; }
}
