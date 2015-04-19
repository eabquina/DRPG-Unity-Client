public class InventoryItemModel : DataModel
{
	public int inventory_item_id { get; set; }
	public string type { get; set; }
	public int entity_id { get; set; }
	public int equipped { get; set; }
	public int item_id { get; set; }
}
