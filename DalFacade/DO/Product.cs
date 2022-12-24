
using Do;
using System.Reflection.Metadata.Ecma335;

namespace DO;

public struct Product
{
    
    public int ID { get; set; }
    public string? Name { get; set; }
    public Category? Category { get; set; }
    public double? Price { get; set; }
    public int InStock { get; set; }
    public string? path { get; set; }  //for image
    public override string ToString() => this.ToStringProperty();



}
