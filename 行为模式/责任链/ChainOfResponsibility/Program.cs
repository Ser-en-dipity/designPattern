using System;
namespace ChainOfRes{
    public interface Ihandler{
        public Ihandler SetNext(Ihandler hand);
        object Handle(object request);
    }
    public abstract class BaseHandler:Ihandler{
        private Ihandler _nexthandler;
        public Ihandler SetNext(Ihandler hand){
            this._nexthandler = hand;
            return hand;
        }
        public virtual object Handle(object request){
            if (this._nexthandler!=null){
                return this._nexthandler.Handle(request);
            }
            else{
                return null;
            }
        }
    }
    public class MonkeyHandler:BaseHandler{
        public override object Handle(object request)
        {
            if ((request as string)=="banana"){
                return "this is a banana. handled \n";
            }
            else {
                return base.Handle(request);
            }
        }
    }
    public class SquirrelHandler:BaseHandler{
        public override object Handle(object request)
        {
            if ((request as string) == "nut"){
                return "this is a nut . handled \n";
            }
            else{
                return base.Handle(request);
            }
        }
    }
    public class DogHandler:BaseHandler{
        public override object Handle(object request)
        {
            if ((request as string ) == "meatball"){
                return "this is a meatball . handled \n";
            }
            else {
                return base.Handle(request);
            }
        }
    }
    class Client {

        public static void ClientCode(BaseHandler handler){
            foreach (var food in new List<string> { "nut", "banana", "Cup of coffee" })
            {
                Console.WriteLine($"Client: Who wants a {food}?");

                var result = handler.Handle(food);

                if (result != null)
                {
                    Console.Write($"   {result}");
                }
                else
                {
                    Console.WriteLine($"   {food} was left untouched.");
                }
            }
        }
    }
    class Program{
        static void Main(){
            var monkey = new MonkeyHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();
            monkey.SetNext(squirrel).SetNext(dog);

            Console.WriteLine("Chain: Monkey > Squirrel > Dog\n");
            Client.ClientCode(monkey);
            Console.WriteLine();

            Console.WriteLine("Subchain: Squirrel > Dog\n");
            Client.ClientCode(squirrel);
        }
    }
}