namespace JazaniT1.Core.Paginations
{
    public class RequestPagination<T>
    {
        private int _page = 1;
        private int _perpage;
        public int Page { get => _page <= 0 ? 1 : _page; set => _page = value; }
        public int PerPage { get => _perpage <= 0 ? 10 : _perpage; set => _perpage = value; }
        public T? Filter { get; set; }
    }
}
