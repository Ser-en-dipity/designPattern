#include <iostream>

class Command
{
public:
    virtual void execute() const=0;
};
class SimpleCommand:public Command{
    private:
        std::string pay_load;
    public:
        explicit SimpleCommand(std::string pay):pay_load(pay){}
        void execute() const override{
            std::cout << "SimpleCommand: See, I can do simple things like printing (" << this->pay_load << ")\n";
        }
};
class Receiver{
    public:
        void Dosomething(const std::string &a){
            std::cout<<"Receiver: Working on (" << a << ".)\n";
        }
        void DoSomethingElse(const std::string &b){
            std::cout<<"Receiver: Also working on (" << b << ".)\n";
        }
};
class ComplexCommand:public Command{
    private:
        std::string a;
        std::string b;
        Receiver *rec;
    public:
        ComplexCommand(std::string _a,std::string _b,Receiver *r){
            this->a = _a;
            this->b = _b;
            this->rec = r;
        }
        void execute() const override{
            std::cout << "ComplexCommand: Complex stuff should be done by a receiver object.\n";
            this->rec->Dosomething(this->a);
            this->rec->DoSomethingElse(this->b);
        }
};
class Invoker{
    private:
        Command *start;
        Command *finish;
    public:
        ~Invoker(){
            delete start;
            delete finish;
        }
        void SetStart(Command *com){
            this->start = com;
        }
        void SetFinish(Command *com){
            this->finish = com;
        }
        void DoSomethingImportant(){
            if (this->start){
                this->start->execute();
            }
            if (this->finish){
                this->finish->execute();
            }
        }

};
int main(){
    Invoker *invoke = new Invoker();
    invoke->SetStart(new SimpleCommand("say hi"));
    std::cout<<"above is simple command\n";
    Receiver *rev = new Receiver;
    invoke->SetFinish(new ComplexCommand("say hi","goodby",rev));
    invoke->DoSomethingImportant();
}