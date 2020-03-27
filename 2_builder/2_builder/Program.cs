using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder builder = new ConcreteBuilder();
            var director = new Director();
            var res = director.Construct(builder);

            Console.WriteLine(res.ToString());
        }
    }

    /* Simply Builder pattern */

  public interface Builder
    {
        void MakeFrame();
        void SetSize(double size);
        void SetWidth(double width);
        void SetName(string name);
        Product build();
    }

    public class ConcreteBuilder : Builder
    {
        Product product = new Product();
        string _name = "";
        double _size = 0;
        double _width = 0;
        
        public Product build()
        {
            product.name = this._name;
            product.size = this._size;
            product.width = this._width;

            return this.product;
        }

        public void MakeFrame()
        {
            product.frame = "Concrete Style";
        }

        public void SetName(string name)
        {
            this._name = String.Format("Name is {0}", name);
        }

        public void SetSize(double size)
        {
            this._size = size;
        }

        public void SetWidth(double width)
        {
            this._width = width;
        }
    }

    public class Product
    {
        public string frame { get; set; }
        public string name { get; set; }
        public double size { get; set; }
        public double width { get; set; }
        public override string ToString()
        {
            return String.Format("frame : {0}, name : {1}, size : {2}, width : {3}", frame, name, size, width);
        }
    }

    public class Director
    {
        public Product Construct(Builder Ibuilder)
        {
            Ibuilder.MakeFrame();
            Ibuilder.SetName("Director");
            Ibuilder.SetSize(100);
            Ibuilder.SetWidth(200);
            
            Product pd = Ibuilder.build();

            return pd;
        }
    }

    /* Simply Builder pattern */


}
