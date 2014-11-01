public class ItemContainerModel : DataModel
{
	public int item_container_id { get; set; }
	public string label { get; set; }
	public int item_quantity { get; set; }
	public int item_rarity { get; set; }
	public string item_rarity_operator { get; set; }
	public ItemModel[] items { get; set; }
	public ItemInstanceModel[] item_instances { get; set; }
}
