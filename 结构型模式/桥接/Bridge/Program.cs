using System;
namespace BridgeConcept{
    public class Shape{
        protected Color _color;
        public Shape(Color _c){
            this._color = _c;
        }
        public virtual void print(){
            Console.WriteLine(this._color.operation());
        }
    }
    public class Rect : Shape{
        public Rect(Color _c):base(_c){}
        public override void print()
        {
            Console.WriteLine(base._color.operation());
        }
    }
    public class Tri : Shape{
        public Tri (Color c):base(c){}
        public override void print()
        {
            Console.WriteLine(base._color.operation());
        }
    }
    public interface Color{
        public string operation();
    }
    public class Red:Color{
        public string operation(){
            return "this is red";
        }
    }
    public class Blue:Color{
        public string operation(){
            return "this is blue";
        }
    }
    class Program
    {
        static void Main(){
            Color c = new Red();
            Rect rectangle = new Rect(c);
            rectangle.print();
            Color d = new Blue();
            Tri triangle = new Tri(d);
            triangle.print();

        }   
    }
}