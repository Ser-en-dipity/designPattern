using System;
namespace StateConcept{
    class Context{
        private State state;
        public Context(State state){
            this.Transition(state);
        }
        public void Transition(State state){

            this.state = state;
            this.state.SetContext(this);
        }
        public void request(){
            this.state.clickPlay();
        }
        public void require(){
            this.state.clickNext();
        }
    }
    abstract class State{
        protected Context ctx;
        public void SetContext(Context ctx){
            this.ctx = ctx;
        }
        public abstract void clickPlay();
        public abstract void clickNext();
    }
    class ConcreteState:State{
        public override void clickPlay()
        {
            Console.WriteLine("handled click pley \n");
            Console.WriteLine("transfer to another state\n");
            this.ctx.Transition(new MovingState());
        }
        public override void clickNext()
        {
            Console.WriteLine("click next handled\n");
        }
    }
    class MovingState:State{
        public override void clickPlay()
        {
            Console.WriteLine("handled click pley \n");
            Console.WriteLine("transfer to another state\n");
            this.ctx.Transition(new ConcreteState());
        }
        public override void clickNext()
        {
            Console.WriteLine("click next handled and move to another state\n");
        }
    }
    class Program{
        static void Main(){
            var context = new Context(new ConcreteState());
            context.request();
            context.require();
        }
    }
}