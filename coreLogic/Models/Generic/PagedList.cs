namespace coreApi.Models.Generic;

public class PagedList<T,TSearch>
{
    public Pager<TSearch> Pager { get; set; } = new Pager<TSearch>();

    public List<T> ListItems { get; set; } = new List<T>();

	public Result Result { get; set; } 
}

public class PagedList<T> : PagedList<T, Search>{}
