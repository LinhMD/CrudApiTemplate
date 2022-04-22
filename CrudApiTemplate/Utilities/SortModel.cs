namespace CrudApiTemplate.Utilities;

public class SortModel<TModel> where TModel: class
{
    public string PropertyName { get; set; }

    public bool IsAscending { get; set; }

}