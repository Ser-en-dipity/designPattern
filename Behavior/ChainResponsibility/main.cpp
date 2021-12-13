#include <iostream>
#include<vector>
class Handler{
    public:
        virtual Handler* SetNext(Handler *hand)  =0;
        virtual std::string handle(std::string request)  =0;
};
class AbstractHandler:public Handler{
    private:
        Handler *nextHand;
    public:
        AbstractHandler():nextHand(nullptr){}
        Handler *SetNext(Handler *hand) override {
            this->nextHand = hand;
            return hand;
        }  
        std::string handle(std::string request) override{
            if (this->nextHand)
                return this->nextHand->handle(request);
            else{
                return {};
            }
        }
};
class MonkeyHandler:public AbstractHandler{
    std::string handle(std::string request)override{
        if (request=="Banana"){
            return "Monkey: I'll eat the " + request + ".\n"; 
        }
        else{
            return AbstractHandler::handle(request);
        }
    }
};
class SquirrelHandler : public AbstractHandler {
 public:
  std::string handle(std::string request) override {
    if (request == "Nut") {
      return "Squirrel: I'll eat the " + request + ".\n";
    } else {
      return AbstractHandler::handle(request);
    }
  }
};
class DogHandler : public AbstractHandler {
 public:
  std::string handle(std::string request) override {
    if (request == "MeatBall") {
      return "Dog: I'll eat the " + request + ".\n";
    } else {
      return AbstractHandler::handle(request);
    }
  }
};
void ClientCode(Handler &handler) {
  std::vector<std::string> food = {"Nut", "Banana", "Cup of coffee"};
  for (const std::string &f : food) {
    std::cout << "Client: Who wants a " << f << "?\n";
    const std::string result = handler.handle(f);
    if (!result.empty()) {
      std::cout << "  " << result;
    } else {
      std::cout << "  " << f << " was left untouched.\n";
    }
  }
}
int main() {
  MonkeyHandler *monkey = new MonkeyHandler;
  SquirrelHandler *squirrel = new SquirrelHandler;
  DogHandler *dog = new DogHandler;
  monkey->SetNext(squirrel)->SetNext(dog);

  /**
   * The client should be able to send a request to any handler, not just the
   * first one in the chain.
   */
  std::cout << "Chain: Monkey > Squirrel > Dog\n\n";
  ClientCode(*monkey);
  std::cout << "\n";
  std::cout << "Subchain: Squirrel > Dog\n\n";
  ClientCode(*squirrel);

  delete monkey;
  delete squirrel;
  delete dog;

  return 0;
}