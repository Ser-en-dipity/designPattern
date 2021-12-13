using System;
namespace CommandConcept{
    public interface ICommand{
        public void execute();
    }
    class SimpleCommand : ICommand{
        private string _payload ;
        public SimpleCommand(string s){
            this._payload = s;
        }
        public void execute(){
            Console.WriteLine("this is a simple command and print out "+ this._payload);
        }
    }
    class ComplexCommand : ICommand{
        private Receiver rec ;
        private string _a;
        private string _b;
        public ComplexCommand(Receiver rec,string a,string b){
            this.rec = rec;
            this._a = a;
            this._b = b;
        }
        public void execute(){
            Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object.");
            this.rec.dosomething(_a);
            this.rec.dothings(_b);

        }
    }
    class Receiver{
        public void dosomething(string a){
            Console.WriteLine($"Receiver: Working on ({a}.)");
        }
        public void dothings(string b){
            Console.WriteLine($"Receiver: Also working on ({b}.)");
        }
    }
    class Invoker{
        private ICommand startup;
        private ICommand finish;

        public void SetOnStart(ICommand command){
            this.startup = command;
        }
        public void SetOnFinish(ICommand command){
            this.finish = command;
        }
        public void Important(){
            Console.WriteLine("Invoker: Does anybody want something done before I begin?");
            if (this.startup is ICommand){
                this.startup.execute();
            }
            Console.WriteLine("Invoker: ...doing something really important...");
            
            Console.WriteLine("Invoker: Does anybody want something done after I finish?");
            if (this.finish is ICommand){
                this.finish.execute();
            }
        }
    }
    class Program{
        static void Main(){
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

            invoker.Important();
        }
    }

}