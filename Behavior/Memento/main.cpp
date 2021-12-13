#include <iostream>
#include<ctime>
#include<vector>
class Memento{
    public:
        virtual std::string GetName() const =0;
        virtual std::string state() const =0;
        virtual std::string date() const =0;
};
class ConcreteMento:public Memento{
    private:
        std::string _state;
        std::string _date;
    public:
        ConcreteMento(std::string state):_state(state){
            std::time_t now = std::time(0);
            this->_date = std::ctime(&now);
        }
        std::string GetName() const override{
            return this->_date + " / (" + this->_state.substr(0, 9) + "...)";
        }
        std::string date() const override{
            return this->_date;
        }
        std::string state() const override{
            return this->_state;
        }
};
class Originator{
    private:
        std::string state;
        std::string GenerateRandomString(int length = 10) {
        const char alphanum[] =
            "0123456789"
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            "abcdefghijklmnopqrstuvwxyz";
        int stringLength = sizeof(alphanum) - 1;

        std::string random_string;
        for (int i = 0; i < length; i++) {
        random_string += alphanum[std::rand() % stringLength];
        }
        return random_string;
  }
    public: 
        Originator(std::string s):state(s){
            std::cout << "Originator: My initial state is: " << this->state << "\n";
        }
        void DoSomething(){
             std::cout << "Originator: I'm doing something important.\n";
            this->state = this->GenerateRandomString(30);
            std::cout << "Originator: and my state has changed to: " << this->state << "\n";
        }
        Memento *Save(){
            return new ConcreteMento(this->state);
        }
        void Restore(Memento *mento){
            this->state = mento->state();
            std::cout << "Originator: My state has changed to: " << this->state << "\n";
        }

};  
class CareTaker{
    private:
        std::vector<Memento*> memo;
        Originator *orig;
    public:
        CareTaker(Originator *o):orig(o){}
        void Backup(){
            this->memo.push_back(this->orig->Save());
        }
        void Undo(){
            if (!this->memo.size()) {
                return;
            }
            Memento *memento = this->memo.back();
            this->memo.pop_back();
            std::cout << "Caretaker: Restoring state to: " << memento->GetName() << "\n";
            try {
            this->orig->Restore(memento);
            } catch (...) {
            this->Undo();
            }
        }
        void ShowHistory() const {
            std::cout << "Caretaker: Here's the list of mementos:\n";
            for (Memento *memento : this->memo) {
            std::cout << memento->GetName() << "\n";
            }
        }

};
void ClientCode() {
  Originator *originator = new Originator("Super-duper-super-puper-super.");
  CareTaker *caretaker = new CareTaker(originator);
  caretaker->Backup();
  originator->DoSomething();
  caretaker->Backup();
  originator->DoSomething();
  caretaker->Backup();
  originator->DoSomething();
  std::cout << "\n";
  caretaker->ShowHistory();
  std::cout << "\nClient: Now, let's rollback!\n\n";
  caretaker->Undo();
  std::cout << "\nClient: Once more!\n\n";
  caretaker->Undo();

  delete originator;
  delete caretaker;
}

int main() {
  std::srand(static_cast<unsigned int>(std::time(NULL)));
  ClientCode();
  return 0;
}