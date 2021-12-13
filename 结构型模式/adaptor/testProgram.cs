using System;

namespace adaptorconceptForPeg
{
    public interface peg
    {
        public int getRadius();
    }

    public class RoundHole
    {
        public int r;
        public RoundHole(int r){
            this.r = r;
        }
        public int getRadius(){
            return this.r;
        }
        public bool fits(RoundPeg peg){
            return this.getRadius() >= peg.getRadius();
        }
    }
    public class RoundPeg
    {
        public int PegR;
        public RoundPeg(int r){
            this.PegR = r;
        }
        public int getRadius(){
            return this.PegR;
        } 
    }
    public interface ISquare{
        public int getWidth();
        public void SquarePrint();
    }
    public abstract class SquarePeg:ISquare
    {
        public int width;

        public SquarePeg(int w){
            this.width  = w;
        }
        public int getWidth(){
            return this.width;
        }
        public void SquarePrint(){
            Console.WriteLine("this is a square peg");
        }
    }
    public class  AdapterPeg : SquarePeg,ISquare
    {
        public int width;
        protected RoundPeg peg;
        public AdapterPeg(RoundPeg peg){
            this.peg = peg;
        }
        public int getWidth(){
            return this.peg.getRadius();
        }
        public void SquarePrint(){
            Console.WriteLine("adaptor : print square func\n");
        }
    }
    class Program{
        static void Main(){
            var hole = new RoundHole(5);
            var rpeg = new RoundPeg(5);
            Console.WriteLine(hole.fits(rpeg));
            ISquare adpeg = new AdapterPeg(rpeg);
            Console.WriteLine("ad + rhole\n");
            Console.WriteLine(hole.fits(adpeg.peg));
        }
    }
}
