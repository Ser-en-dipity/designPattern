#include <iostream>

class Subsystem1 {
 public:
  std::string Operation1() const {
    return "Subsystem1: Ready!\n";
  }
  // ...
  std::string OperationN() const {
    return "Subsystem1: Go!\n";
  }
};
/**
 * Some facades can work with multiple subsystems at the same time.
 */
class Subsystem2 {
 public:
  std::string Operation1() const {
    return "Subsystem2: Get ready!\n";
  }
  // ...
  std::string OperationZ() const {
    return "Subsystem2: Fire!\n";
  }
};
class Facade{
    protected:
        Subsystem1 *sub1;
        Subsystem2 *sub2;
    public:
        Facade(Subsystem1 *s1=NULL,Subsystem2 *s2=NULL){
            this->sub1 = s1? :new Subsystem1();
            this->sub2 = s2? :new Subsystem2();
        }
        ~Facade(){}
        std::string Operation(){
            std::string result = "Facade initializes subsystems:\n";
            result += this->sub1->Operation1();
            result += this->sub2->Operation1();
            result += "Facade orders subsystems to perform the action:\n";
            result += this->sub1->OperationN();
            result += this->sub2->OperationZ();
            return result;
        }
};
void ClientCode(Facade *facade) {
  // ...
  std::cout << facade->Operation();
  // ...
}

int main() {
  Subsystem1 *subsystem1 = new Subsystem1;
  Subsystem2 *subsystem2 = new Subsystem2;
  Facade *facade = new Facade(subsystem1, subsystem2);
  ClientCode(facade);

  delete facade;

  return 0;
}