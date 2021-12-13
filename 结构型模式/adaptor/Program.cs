using System;
namespace adaptorconcept{
    public interface Itarget{
        string functions();
    }
    public class adaptee
    {
        public adaptee(){

        }
        public string func(){return "this is a instance";}
    }
    public class Adapter:Itarget
    {
        public int s;
        private adaptee _ad;
        public Adapter(adaptee ada){
            this._ad = ada;
        }
        public string functions(){
            Console.WriteLine("define");
            return "this is a adapter";
        }   
    }
    class Client{
        public void print(Itarget tar){
            Console.WriteLine(tar.functions());
        }
    }
    class Program
    {
        static void Main(){
            adaptee ad = new adaptee();
            Itarget tar = new Adapter(ad);
            tar.functions();
            Client client = new Client();
            client.print(tar);
        }   
    }

}