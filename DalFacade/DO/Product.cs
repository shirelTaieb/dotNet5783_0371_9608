
namespace DO;

public struct Product
{
    
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Category { get; set; }
    public double Price { get; set; }
    public int InStuck { get; set; }

    public override string ToString() => $@"
	Product ID={ID}: 
        Product Name {Name}, 
	category - {Category}
    	Price: {Price}
    	Amount in stock: {InStuck}
	";


}
