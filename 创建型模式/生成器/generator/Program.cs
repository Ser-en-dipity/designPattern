using System;
namespace generator{
    public interface Builder{
        void reset();
        void setSeats(int num);
        void setTripComputer(int num);
        void setGps();
        void setEngine(string en);
    }

    public class CarBuilder:Builder{
        private Car car = new Car();
        public void Builder(){
            this.reset();
        }
        public void reset(){
            this.car = new Car();
        }
        public void setSeats(int num){
            this.car.Add("seats"+num.ToString());
        }
        public void setTripComputer(int num){
            this.car.Add("computer"+num.ToString());
        }
        public void setGps(){
            this.car.Add("gps");
        }
        public void setEngine(string s){
            this.car.Add("engine"+s);
        }
        public Car Getpro(){
            Car result = this.car;
            this.reset();
            return result;

        }
    }
    public class Car{
        private List<object> parts = new List<object>();
        public void Add(string c){
            this.parts.Add(c);
        }
        public string Listparts(){
            string result = string.Empty;
            for(int i=0;i<parts.Count();i++){
                result += parts[i]+",";
            }
            return "products" + result + '\n';
        }
    }   
    class Director{
        private Builder ber;
        public Builder setbuild
        {
            set {ber = value;}
        }
        public void runMethod(){
            this.ber.setSeats(4);
        }
        public void runMethod3(){
            this.ber.setGps();
            this.ber.setEngine("4t");
            this.ber.setTripComputer(2);
        }
        
    }
    class Program{
        static void Main(){
            var di = new Director();
            var c = new CarBuilder();
            di.setbuild = c;
            di.runMethod();
            Console.WriteLine(c.Getpro().Listparts());
            Console.WriteLine("sign\n");
            di.runMethod3();
            Console.WriteLine(c.Getpro().Listparts());
        }
    }
}