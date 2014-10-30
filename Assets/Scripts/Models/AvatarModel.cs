public class AvatarModel : DataModel
{
	public int avatar_id { get; set; }
	public int owner_uid { get; set; }
	public string label { get; set; }
	public int currency { get; set; }
	public AttributeModel[] attributes { get; set; }
}
