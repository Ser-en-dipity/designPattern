using System;

namespace RefactoringGuru.DesignPatterns.AbstractFactory.Conceptual
{
   public interface AbstractFactory{
       chair sitMethod();
       desk writeMethod();

       }
    class RomanFactory:AbstractFactory{
        public chair sitMethod(){
            return new RomanChair();
        }
        public desk writeMethod(){
            return new RomanDesk();
        }
    }
    class EuroFactory:AbstractFactory{
        public chair sitMethod(){
            return new EuroChair();
        }
        public desk writeMethod(){
            return new EuroDesk();
        }
    }
   public interface chair{
       public string construct();
   }
   public interface desk{
       string deskcons();
       string adoptAno(chair c);
   }
   public class RomanChair:chair{
       public string construct(){
           return "this is a RomanChair";
       }
   }
   public class EuroChair:chair{
       public string construct(){
           return "this is a EuroChair";
       }
   }
   public class RomanDesk:desk{
       public string deskcons(){
           return "this is a RomanDesk";
       }
       public string adoptAno(chair c){
           return "Romandesk adopt Eurochair"+c.construct();
       }
   }
   class EuroDesk:desk{
       public string deskcons(){
           return "this is a EuroDesk";
       }
       public string adoptAno(chair d){
           return "Eurodesk adopt Romanchair"+d.construct();
       }
   }
   class Client{
       public void Main(){
           ClientNode(new RomanFactory());
           Console.WriteLine();
           ClientNode(new EuroFactory());
           Console.WriteLine();

       }
       public void ClientNode(AbstractFactory factory){
           var ch = factory.sitMethod();
           var ds = factory.writeMethod();

           Console.WriteLine(ch.construct());
           Console.WriteLine(ds.deskcons());
           Console.WriteLine("adopt"+ds.adoptAno(ch));
       }
   }
   class Program{
       static void Main(){
           new Client().Main();
       }
   }
}