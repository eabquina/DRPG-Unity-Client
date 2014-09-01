public class AvatarModel : DataModel
{
	public int avatar_id { get; set; }
	public int owner_uid { get; set; }
	public string label { get; set; }
	public int xp { get; set; }
	public int hp { get; set; }
	public int created { get; set; }
	public int updated { get; set; }
	public object rdf_mapping { get; set; }
}
