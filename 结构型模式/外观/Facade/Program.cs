using System;
namespace FacadeConce{
    public class Video{
        public string operation(){
            return "video start";
        }
    }
    public class MPEG{
        public string operation(){
            return "this is a mpeg";
        }
    }
    public class Facade{
        protected Video v;
        protected MPEG m;
        public Facade(Video _v,MPEG _m){
            this.v = _v;
            this.m = _m;
        }
        public string operation(){
            string result = string.Empty;
            result += v.operation();
            result += "\n";
            result += m.operation();
            return result;
        }
    }
    class Client{
        public void ClientCode(Facade fa){
            Console.WriteLine("Result"+fa.operation());
        }
    }
    class Program{
        static void Main(){
            Client client = new Client();
            Video v = new Video();
            MPEG m = new MPEG();
            Facade fa = new Facade(v,m);
            client.ClientCode(fa);
        }
    }
}