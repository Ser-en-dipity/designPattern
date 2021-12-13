using System;
namespace ProxyConcept{
    public interface ThirdTarget{
        public void Request();
    }
    class Concrete:ThirdTarget{
        public void Request(){
            Console.WriteLine( "request : handle concrete\n");
        }
    }
    class Proxy : ThirdTarget{
        protected Concrete cre ;
        public Proxy(Concrete cr){
            this.cre = cr;
        }
        public void Request(){
            if (this.CheckAccess()){
                this.cre.Request();
                this.Log();
            }
        }
        public bool CheckAccess(){
            Console.WriteLine("check access\n");
            return true;
        }
        public void Log(){
            Console.WriteLine("log : ...\n");
        }
    }
    class Client{
        public void ClientCode(ThirdTarget th){
            th.Request();
        }
    }
    class Program{
        static void Main(){
            Client cli = new Client();
            Concrete cre = new Concrete();
            cli.ClientCode(cre);
            Console.WriteLine();
            Proxy pro = new Proxy(cre);
            cli.ClientCode(pro);
        }
    }
}