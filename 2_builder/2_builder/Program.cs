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


            // Fluent Builder Pattern은 유용해 보인다.

            IBedBuilder builder_fluent = new Simons();
            var bed = builder_fluent.MakeFrame()
                .MakeMatress()
                .MakePillow(10)
                .Build();

            Console.WriteLine(bed);
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



    /* Fluent Builder pattern */

    public interface IBedBuilder
    {
        IBedBuilder MakeFrame();
        IBedBuilder MakeMatress();
        IBedBuilder MakeSheet(string sheet);
        IBedBuilder MakePillow(int size);
        Bed Build();
    }

    public class Bed
    {
        public string Frame { get; set; }
        public string Mattress { get; set; }
        public string Pillow { get; set; }
        public string Sheet { get; set; }
        public override string ToString()
        {
            return String.Format("frame : {0}, name : {1}, size : {2}, {3}", Frame, Mattress, Pillow, Sheet);
        }
    }

    public class Simons : IBedBuilder
    {
        private Bed _bed = new Bed();
        private int pillowSize;
        private string sheetName;

        public Bed Build()
        {
            _bed.Pillow = "Pillow Size#" + pillowSize; // int to string 변환
            _bed.Sheet = "Sheet :" + sheetName;
            return _bed;
        }

        public IBedBuilder MakeFrame()
        {
            _bed.Frame = (DateTime.Now.Month > 5 && DateTime.Now.Month < 9) ? "Simons SummerFrame" : "Simons WoodFrame";
            return this; //Fluent Builder를 위하여
        }

        public IBedBuilder MakeMatress()
        {
            _bed.Mattress = "Simons Mattress";
            return this;
        }

        public IBedBuilder MakePillow(int size)
        {
            this.pillowSize = size;
            return this;
        }

        public IBedBuilder MakeSheet(string sheet)
        {
            this.sheetName = sheet;
            return this;
        }
    }

    // Fluent는 Director가 필요없다 - 사실 이게 필요한지도 모르겠다.

    /* Fluent Builder pattern */


}
