using System;
namespace DecConcept{
    abstract class DataSource{
        public abstract string Operation();
        
    }
    class FileSource : DataSource{
        public override string Operation()
        {
            return "this is a file";
        }
    }
    abstract class Decorator : DataSource{
        protected DataSource _data;
        public Decorator(DataSource data){
            this._data = data;
        }
        public void setData(DataSource da){
            this._data = da;
        }
        public override string Operation()
        {
            if (this._data==null){
                return String.Empty;

            }
            else{
                return this._data.Operation();
            }
        }
    }
    class DataDecorator:Decorator{
        public DataDecorator(DataSource da):base(da){}
        public override string Operation()
        {
            return "data"+base.Operation();
        }
    }
    class FileDecorator:Decorator{
        public FileDecorator(DataSource da):base(da){}
        public override string Operation()
        {
            return "file"+base.Operation();
        }
    }
    class Client{
        public void clientcode(DataSource data){
            Console.WriteLine("result"+data.Operation());
        } 
    }
    class Program{
        static void Main(){
            Client cli = new Client();
            var sm  = new FileSource();
            Console.WriteLine("Client: I get a simple component:");
            cli.clientcode(sm);
            Console.WriteLine();

            FileDecorator file = new FileDecorator(sm);
            DataDecorator data = new DataDecorator(file);
            Console.WriteLine("Client: Now I've got a decorated component:");
            cli.clientcode(data);
        }
    }
    
}