using System;
namespace TemplateConcept{
    public abstract class GameAi{
        public void Turn(){
        this.collectResources();
        this.buildStructures();
        this.buildUnits();
        this.attack();
        }
        protected void collectResources(){
            Console.WriteLine("practise, collected resource");
        }
        protected abstract void buildStructures();
        protected abstract void buildUnits();
        protected virtual void attack(){}
    }
    public class OrcAi:GameAi{
        protected override void buildStructures(){
            Console.WriteLine("build orc buildings\n");
        }
        protected override void buildUnits(){
            Console.WriteLine("grunt is coming\n");
        }
    }
    public class UdAi:GameAi{
        protected override void buildStructures()
        {
            Console.WriteLine("more gold is required\n");
        }
        protected override void buildUnits(){
            Console.WriteLine("ghost haunted\n");
        }
       
    }
    class Client{
        public static void ClientCode(GameAi game){
            game.Turn();
        }
    }
    class Program{
        static void Main(){
            UdAi ud = new UdAi();
            OrcAi orc = new OrcAi();
            Console.WriteLine("this is ud\n");
            Client.ClientCode(ud);
            Console.WriteLine("this is orc\n");
            Client.ClientCode(orc);
        }
    }
}