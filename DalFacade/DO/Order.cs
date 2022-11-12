

namespace DO;
public struct Order
{
    public int ID { get; set; }
    public string? CustomerName { get; set; }
    public string? CostomerEmail { get; set; }
    public string? CostomerAdress { get; set; }
    public DateTime? OrderDate { get; set; }
    public OrderStatus? Status { get; set; }
    public DateTime? PaymentDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public OrderItem Item { get; set; }
    public double TotalPrice { get; set; }


}
