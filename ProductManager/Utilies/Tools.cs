namespace ProductManager.Utilies
{
    public class Tools
    {
        public Tools()
        {
        }
       
        public bool ValidatePrice(decimal price, bool isANewProduct)
        {
            if (isANewProduct) 
            {
                if (price < 0)
                {
                    return false;
                }
            }
            else
            {
                if (price <= 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
