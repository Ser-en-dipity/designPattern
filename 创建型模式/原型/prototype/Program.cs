using System;
namespace proto{
    public class Person{
        public int Age;
        public DateTime birthday;
        public string name;
        public Idinfo idinfo;
        public Person shallowcopy(){
            return (Person) this.MemberwiseClone();
        }
        public Person deepcopy(){
            Person clone = (Person) this.MemberwiseClone();
            clone.idinfo = new Idinfo(idinfo.Idnum);
            clone.name = this.name.Clone().ToString();
            return clone;
        }
    }
    public class Idinfo{
        public int Idnum;
        public Idinfo(int n){
            this.Idnum = n;
        }
    }
    class Program{
        static void Main(){
            Person p1 = new Person();
            p1.Age = 42;
            p1.birthday = Convert.ToDateTime("1977-01-01");
            p1.name = "Jack Daniels";
            p1.idinfo = new Idinfo(666);

            // Perform a shallow copy of p1 and assign it to p2.
            Person p2 = p1.shallowcopy();
            // Make a deep copy of p1 and assign it to p3.
            Person p3 = p1.deepcopy();

            // Display values of p1, p2 and p3.
            Console.WriteLine("Original values of p1, p2, p3:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values:");
            DisplayValues(p3);

            // Change the value of p1 properties and display the values of p1,
            // p2 and p3.
            p1.Age = 32;
            p1.birthday = Convert.ToDateTime("1900-01-01");
            p1.name = "Frank";
            p1.idinfo.Idnum = 7878;
            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values (reference values have changed):");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values (everything was kept the same):");
            DisplayValues(p3);
        }
        public static void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                p.name, p.Age, p.birthday);
            Console.WriteLine("      ID#: {0:d}", p.idinfo.Idnum);
        }
    }
}