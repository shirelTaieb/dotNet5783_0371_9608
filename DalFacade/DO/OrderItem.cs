

using Do;

namespace DO;
public struct OrderItem
{
    public int ID { get; set; }
    public int ProductID{ get; set; }
    public int OrderID { get; set; }
    public double? Price { get; set; }
    public int Amount { get; set; }
    public override string ToString() => this.ToStringProperty();
}

