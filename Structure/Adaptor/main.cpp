#include <iostream>
#include<string>
#include<algorithm>
class Target{
    
    public:
        ~Target(){}
        virtual std::string SpecialRequest() const {
            return "Target: The default target's behavior.";
        }
};
class Adaptee{
    public:
        std::string Request() const {
            return ".eetpadA eht fo roivaheb laicepS";
        }
};
class Adaptor:public Target{
    private:
        Adaptee* _adaptee;
    public:
        Adaptor(Adaptee *adaptee) : _adaptee(adaptee) {}
        std::string SpecialRequest() const override{
            std::string result = this->_adaptee->Request();
            std::reverse(result.begin(),result.end());
            return "Adapter: (TRANSLATED) " + result;
        }

};
void ClientCode(const Target *target) {
  std::cout << target->SpecialRequest();
}

int main() {
  std::cout << "Client: I can work just fine with the Target objects:\n";
  Target *target = new Target;
  ClientCode(target);
  std::cout << "\n\n";
  Adaptee *adaptee = new Adaptee;
  std::cout << "Client: The Adaptee class has a weird interface. See, I don't understand it:\n";
  std::cout << "Adaptee: " << adaptee->Request();
  std::cout << "\n\n";
  std::cout << "Client: But I can work with it via the Adapter:\n";
  Adaptor *adapter = new Adaptor(adaptee);
  ClientCode(adapter);
  std::cout << "\n";

  delete target;
  delete adaptee;
  delete adapter;

  return 0;
}