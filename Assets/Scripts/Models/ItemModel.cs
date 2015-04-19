public class ItemModel : DataModel
{
	public int item_id { get; set; }
	public string label { get; set; }
	public int rarity { get; set; }
	public int equippable { get; set; }
	public int currency_cost { get; set; }
	public int currency_value { get; set; }
	public string ui_asset_path { get; set; }
	public string game_asset_path { get; set; }
}
