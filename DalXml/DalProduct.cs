﻿using DalApi;
using System.Xml.Linq;

namespace Dal
{
    internal class DalProduct : IProduct
    {
        const string s_products = "Product";//the name of the file;

        #region createProductElement מקבל פרודקט ומחזיר אלמנט
        static IEnumerable<XElement> createProductElement(DO.Product product)
        {
            yield return new XElement("ID", product.ID);
            if (product.Name != null)
                yield return new XElement("Name", product.Name);
            if (product.Category != null)
                yield return new XElement("Category", product.Category);
            if (product.Price != null)
                yield return new XElement("Price", product.Price);
            yield return new XElement("InStock", product.InStock);
            if (product.path != null)
                yield return new XElement("path", product.path);
        }
        #endregion

        #region get product מקבל אלמנט וממיר לפרודקט
        static DO.Product? getProduct(XElement p)
        {
            if (p.ToIntNullable("ID") == null)
                return null;
            else
                return new DO.Product()
                {
                    ID = (int)p.Element("ID")!,
                    Name = (string?)p.Element("Name")??null,
                    Price = (double?)p.Element("Price")??null,
                    Category = p.ToEnumNullable<DO.Category>("Category")??null,
                    InStock = (int)p.Element("InStock")!,
                    path = (string?)p.Element("path") ?? null
                };
        }
        #endregion

        #region פונקציה מוסיפה מוצר לאקסמל ומחזירה את המספר המזהה שהעניקה לו
        public int Add(DO.Product product)
        {
            XElement productsRoot = XMLTools.LoadListFromXMLElement(s_products);

            XElement? temp = XMLTools.LoadListFromXMLElement(s_products)?.Elements().FirstOrDefault(pro => pro.ToIntNullable("ID") == product.ID);
            if (temp != null)
                throw new doubleException();
            else if (product.ID <= 100000 || product.ID >= 999999) //the id isnt valid
                product.ID = XMLTools.ConfigProduct.getNumber(); //get a run number
            productsRoot.Add(new XElement("Product", createProductElement(product)));
            XMLTools.SaveListToXMLElement(productsRoot, s_products); // return to the xml
            return product.ID;
        }
        #endregion 

        #region פונקציה מקבלת מספר מזהה של מוצר ומחזירה את המוצר
        public DO.Product GetById(int id)
        {
            XElement? productElement = XMLTools.LoadListFromXMLElement(s_products)?.Elements()
            .FirstOrDefault(pro => pro.ToIntNullable("ID") == id);
            if (productElement == null) //there is no match product
                throw new NotExistException();
            else
                return (DO.Product)getProduct(productElement!)!; //return the product
        }
        #endregion

        #region פונקציה מוחקת 
        public void Delete(int id)
        {
            XElement productsRoot = XMLTools.LoadListFromXMLElement(s_products);  //get the root element of the file

            try
            {
                //var list = productsRoot.Elements();
                var one = (from p in productsRoot.Elements()
                           where Convert.ToInt32(p.Element("ID")!.Value) == id
                           select p).FirstOrDefault();//list.FirstOrDefault(pro => pro.Element("ID")!.Value == id.ToString()) ?? throw new NotExistException();
                if (one != null)
                    one.Remove();
                else
                    throw new NotExistException();
                XMLTools.SaveListToXMLElement(productsRoot, s_products); //save the products after the deleting

            } //try to remove
            catch { throw new NotExistException(); }
        }
        #endregion

        #region פונקציה מעדכנת
        public void Update(DO.Product product)
        {
            Delete(product.ID);
            Add(product);
        }
        #endregion

        #region מחזירה את רשימת המוצרים
        public IEnumerable<DO.Product?> GetAll(Func<DO.Product?, bool>? filter = null)
        {

            if (filter == null)
            {
                return XMLTools.LoadListFromXMLElement(s_products).Elements().Select(s => getProduct(s));
            }
            else
                return XMLTools.LoadListFromXMLElement(s_products).Elements().Select(s => getProduct(s)).Where(filter);
        }
        #endregion
    }
}
