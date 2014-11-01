public class NPCInstanceModel : DataModel
{
	public int npc_instance_id { get; set; }
	public string type { get; set; }
	public int entity_id { get; set; }
	public int npc_id { get; set; }
	public AttributeModel[] attributes { get; set; }
}
