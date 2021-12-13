using System;
namespace VisitorConcept{
    public interface Shape{
        void Accept(Visitor v);
    }
    public class dot : Shape{
        public dot(){}
        public void Accept(Visitor v){
            v.VisitDot(this);
        }
        public string print(){
            return "this is a dot\n";
        }
    }
    public class circle : Shape{
        public circle(){}
        public void Accept(Visitor v){
            v.VisitCircle(this);
        }
        public string print(){
            return "this is a circle\n";
        }
    }
    public class rect : Shape{
        public rect(){}
        public void Accept(Visitor v){
            v.VisitRect(this);
        }
        public string print(){
            return "this is a rectangle\n";
        }
    }
    public interface Visitor{
        public void VisitDot(dot d);
        public void VisitCircle(circle c);
        public void VisitRect(rect r);
    }
    public class XMLvisitor:Visitor{
        public XMLvisitor(){}
        public void VisitDot(dot d){
            Console.WriteLine("visit dot. \n" + d.print());
        }
        public void VisitCircle(circle c){
            Console.WriteLine("visit circle \n" + c.print());
        }
        public void VisitRect(rect r){
            Console.WriteLine("visit Rectangle\n" + r.print());
        }
    }
    class Program{
        static void Main(){
            var d = new dot();
            var c = new circle();
            var r = new rect();
            List<Shape> l = new List<Shape>();
            l.Add(d);
            l.Add(c);
            l.Add(r);
            var xml = new XMLvisitor();
            foreach(var shape in l){
                shape.Accept(xml);
            }
        }
    }
}