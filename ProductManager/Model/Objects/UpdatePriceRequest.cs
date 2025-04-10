namespace ProductManager.Model.Objects
{
    public class UpdatePriceRequest
    {
        public int IdProduct { get; set; }
        public decimal Price { get; set; }
    }
}
