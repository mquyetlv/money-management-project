namespace money_management_service.Core
{
    public class Pagination
    {
        public int Total { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }

        public Pagination() 
        {
            Total = 0;
            Page = 0;
            Size = 0;
        }

        public Pagination (int total, int page = 0, int size = 20)
        {
            Total = total;
            Page = page;
            Size = size;
        }
    }
}
