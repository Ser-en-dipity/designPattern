#include <iostream>
#include <list>
#include <string>

class Iobserver{
    public:
        virtual ~Iobserver(){}
        virtual void update(const std::string &message)  =0;
};  
class Isubject{
    public:
        virtual ~Isubject(){}
        virtual void Attach(Iobserver *observer)  = 0;
        virtual void Detach(Iobserver *observer)  = 0;
        virtual void Notify()  = 0;
};
class Subject:public Isubject{
    private:
        std::list<Iobserver*> listOb;
        std::string s;
    public:
        virtual ~Subject() {
            std::cout << "Goodbye, I was the Subject.\n";
        }
        void Attach(Iobserver *ob) override {
            this->listOb.push_back(ob);
        }
        void Detach(Iobserver *ob)override{
            this->listOb.remove(ob);
        }
        void Notify() override{
            std::list<Iobserver*>::iterator it=this->listOb.begin();
            while (it != this->listOb.end()){
                (*it)->update(s);
                it++;
            }
        }
        void CreateMessage(std::string mes){
            this->s = mes;
            Notify();
        }
        void SomeBusinessLogic() {
            this->s = "change message message";
            Notify();
            std::cout << "I'm about to do some thing important\n";
        }
};
class Observer:public Iobserver{
    private:
        static int static_num;
        int num;
        std::string message;
        Subject &sub;
    public:
        Observer(Subject &s):sub(s){
            this->sub.Attach(this);
            std::cout << "Hi, I'm the Observer \"" << ++Observer::static_num << "\".\n";
            this->num = Observer::static_num;
        }
        virtual ~Observer(){
            std::cout << "Goodbye, I was the Observer \"" << this->num << "\".\n";
        }
        void update(const std::string &mes){
            this->message = mes;
            printinfo();
        }
        void RemoveFrom(){
            sub.Detach(this);
            std::cout << "Observer \"" << num << "\" removed from the list.\n";
        }
        void printinfo(){
            std::cout << "Observer \"" << this->num << 
            "\": a new message is available --> " << this->message << "\n";
        }
};
int Observer::static_num = 0;
int main(){
    Subject *subject = new Subject;
    Observer *observer1 = new Observer(*subject);
    Observer *observer2 = new Observer(*subject);
    Observer *observer3 = new Observer(*subject);
    Observer *observer4;
    Observer *observer5;

    subject->CreateMessage("Hello World! :D");
    observer3->RemoveFrom();

    subject->CreateMessage("The weather is hot today! :p");
    observer4 = new Observer(*subject);

    observer2->RemoveFrom();
    observer5 = new Observer(*subject);

    subject->CreateMessage("My new car is great! ;)");
    observer5->RemoveFrom();

    observer4->RemoveFrom();
    observer1->RemoveFrom();

    delete observer5;
    delete observer4;
    delete observer3;
    delete observer2;
    delete observer1;
    delete subject;
}