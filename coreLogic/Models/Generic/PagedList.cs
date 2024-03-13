namespace coreApi.Models.Generic;

public class PagedList<T,TSearch>
{
    public Pager<TSearch> Pager { get; set; } = new Pager<TSearch>();

    public Result Result { get; set; } = new Result();

    public List<T> ListItems { get; set; } = new List<T>();
}

public class PagedList<T> : PagedList<T, Search>{}
