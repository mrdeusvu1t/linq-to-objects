using System;

namespace Linq.DataSources
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        
        public override string ToString() =>
            $"ProductId={ProductId} ProductName={ProductName} Category={Category} UnitPrice={UnitPrice:C2} UnitsInStock={UnitsInStock}";
        public bool Equals(Product other)
        {
            return ProductId == other.ProductId && ProductName == other.ProductName && Category == other.Category && UnitPrice == other.UnitPrice && UnitsInStock == other.UnitsInStock;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductId, ProductName, Category, UnitPrice, UnitsInStock);
        }
    }
}