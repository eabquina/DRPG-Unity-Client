public class RoomModel : DataModel
{
	public int room_id { get; set; }
	public string label { get; set; }
	public int item_container_quantity { get; set; }
	public ItemContainerModel[] item_containers { get; set; }
	public NPCModel[] npcs { get; set; }
	public NPCInstanceModel[] npc_instances { get; set; }
}
