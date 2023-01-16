using System.Xml.Linq;
using System.Xml.Serialization;
namespace Dal;

static class XMLTools
{
    const string s_dir = @"..\xml\";
    static XMLTools()
    {
        if (!Directory.Exists(s_dir))
            Directory.CreateDirectory(s_dir);

        ////SaveListToXMLSerializer(new List<Product?> { }, "Product");
        ////SaveListToXMLSerializer(new List<Order?> { }, "Order");
        ////SaveListToXMLSerializer(new List<OrderItem?> { }, "OrderItem");
        ////SaveListToXMLSerializer(new List<OrderItem?> { }, "Config");
    }

    #region Extension Fuctions
    public static T? ToEnumNullable<T>(this XElement element, string name) where T : struct, Enum =>
        Enum.TryParse<T>((string?)element.Element(name), out var result) ? (T?)result : null;

    public static DateTime? ToDateTimeNullable(this XElement element, string name) =>
        DateTime.TryParse((string?)element.Element(name), out var result) ? (DateTime?)result : null;

    public static double? ToDoubleNullable(this XElement element, string name) =>
        double.TryParse((string?)element.Element(name), out var result) ? (double?)result : null;

    public static int? ToIntNullable(this XElement element, string name) =>
        int.TryParse((string?)element.Element(name), out var result) ? (int?)result : null;
    #endregion

    #region SaveLoadWithXElement
    public static void SaveListToXMLElement(XElement rootElem, string entity)
    {
        string filePath = $"{s_dir + entity}.xml";
        try
        {
            rootElem.Save(filePath);
        }
        catch (Exception ex)
        {
            // DO.XMLFileLoadCreateException(filePath, $"fail to create xml file: {dir + filePath}", ex);
            throw new Exception($"fail to create xml file: {filePath}", ex);
        }
    }

    public static XElement LoadListFromXMLElement(string entity)
    {
        string filePath = $"{s_dir + entity}.xml";
        try
        {
            if (File.Exists(filePath))
                return XElement.Load(filePath);
            XElement rootElem = new(entity);
            rootElem.Save(filePath);
            return rootElem;
        }
        catch (Exception ex)
        {
            //new DO.XMLFileLoadCreateException(filePath, $"fail to load xml file: {dir + filePath}", ex);
            throw new Exception($"fail to load xml file: {filePath}", ex);
        }
    }
    #endregion

    #region SaveLoadWithXMLSerializer
    //static readonly bool s_writing = false;
    public static void SaveListToXMLSerializer<T>(List<T?> list, string entity) where T : struct
    {
        string filePath = $"{s_dir + entity}.xml";
        try
        {
            using FileStream file = new(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            //using XmlWriter writer = XmlWriter.Create(file, new XmlWriterSettings() { Indent = true });

            XmlSerializer serializer = new(typeof(List<T?>));
            //if (s_writing)
            //    serializer.Serialize(writer, list);
            //else
            serializer.Serialize(file, list);
        }
        catch (Exception ex)
        {
            // DO.XMLFileLoadCreateException(filePath, $"fail to create xml file: {dir + filePath}", ex);            }
            throw new Exception($"fail to create xml file: {filePath}", ex);
        }
    }

    public static List<T?> LoadListFromXMLSerializer<T>(string entity) where T : struct
    {
        string filePath = $"{s_dir + entity}.xml";
        try
        {
            if (!File.Exists(filePath)) return new();
            using FileStream file = new(filePath, FileMode.Open);
            XmlSerializer x = new(typeof(List<T?>));
            return x.Deserialize(file) as List<T?> ?? new();
        }
        catch (Exception ex)
        {
            // DO.XMLFileLoadCreateException(filePath, $"fail to load xml file: {dir + filePath}", ex);            }
            throw new Exception($"fail to load xml file: {filePath}", ex);
        }
    }
    #endregion
    //public static int getNumber()
    //{
    //    XElement root = LoadListFromXMLElement("Config");

    //    int nextNumber = Convert.ToInt32(root!.Element("ConfigProduct").Value);
    //    root!.Element("ConfigProduct")!.Value = (nextNumber + 1).ToString();
    //    SaveListToXMLElement(root, "Config");
    //    return nextNumber + 1;
    //}
    public class ConfigOrder
    {
        public static int getNumber()
        {
            XElement root = LoadListFromXMLElement("Config");

            int nextNumber = Convert.ToInt32(root!.Element("ConfigOrder")!.Value);
            root!.Element("ConfigOrder")!.Value = (nextNumber + 1).ToString();
            SaveListToXMLElement(root, "Config");
            return nextNumber + 1;
        }
    }
    public class ConfigProduct
    {
        public static int getNumber()
        {
            XElement root = LoadListFromXMLElement("Config");

            int nextNumber = Convert.ToInt32(root!.Element("ConfigProduct")!.Value);
            root!.Element("ConfigProduct")!.Value = (nextNumber + 1).ToString();
            SaveListToXMLElement(root, "Config");
            return nextNumber + 1;
        }
    }
    public class ConfigOrderItem
    {
        public static int getNumber()
        {
            XElement root = LoadListFromXMLElement("Config");

            int nextNumber = Convert.ToInt32(root!.Element("ConfigOrderItem")!.Value);
            root!.Element("ConfigOrderItem")!.Value = (nextNumber + 1).ToString();
            SaveListToXMLElement(root, "Config");
            return nextNumber + 1;
        }
    }

}
