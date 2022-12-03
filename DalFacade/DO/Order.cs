
using System.Linq;
using System.Data.Common;

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
    public override string ToString() => $@"Product ID={ID}
CostumerName- {CostumerName}
Costumer Email- {CostumerEmail}
Order Date: {OrderDate}
Ship Date: {ShipDate}
Delivery Date: {DeliveryDate}
	";

}
