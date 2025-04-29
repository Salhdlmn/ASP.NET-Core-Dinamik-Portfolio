namespace PortfolioCoreDay.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public List<Portfolio> Portfolios { get; set; }
    }
}
