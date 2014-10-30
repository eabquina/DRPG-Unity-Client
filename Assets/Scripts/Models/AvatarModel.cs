public class AvatarModel : DataModel
{
	public int avatar_id { get; set; }
	public int owner_uid { get; set; }
	public string label { get; set; }
	public int currency { get; set; }
	public AttributeModel[] attributes { get; set; }

	public int GetAttributeValue(string name)
	{
		if (this.attributes != null)
		{
			AttributeModel attribute = null;
			for (int i = 0; i < this.attributes.Length; i++)
			{
				attribute = this.attributes[i];

				if (attribute.attribute_name == name)
				{
					return attribute.value;
				}
			}
		}

		return 0;
	}
}
