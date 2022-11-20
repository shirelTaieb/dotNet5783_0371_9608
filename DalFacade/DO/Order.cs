

namespace DO;
public struct Order
{
    public int ID { get; set; }
    public string? CostumerName { get; set; }
    public string? CostumerEmail { get; set; }
    public string? CostumerAdress { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
 
}
