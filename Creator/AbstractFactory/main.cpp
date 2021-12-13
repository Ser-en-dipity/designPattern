#include <iostream>

class Button{
    public:
        ~Button(){}
        virtual std::string paint() const=0;
};
class WinButton:public Button{
    public:
        std::string paint() const override{
            return "win paint\n";
        }
};
class MacButton:public Button
{
    public:
        std::string paint() const override{
            return "mac paint\n";
    }
};
class CheckBox
{
public:
    ~CheckBox();
    virtual std::string paint() const =0;
    virtual std::string check() const =0;
};
class WinCheck:public CheckBox{
    std::string paint() const override{
        return "win check paint\n";
    }
    std::string check() const override{
        return "win check completed\n";
    }
};
class MacCheck:public CheckBox{
    std::string paint() const override{
        return "this is mac paint\n";
    }
    std::string check() const override{
        return "this is mac check\n";
    }
};
class AbstractFactory{
    public:
        ~AbstractFactory(){}
        virtual Button* CreateButton() const =0;
        virtual CheckBox* CreateCheck() const =0;

};
class WinFactory:public AbstractFactory{
    public:
        Button* CreateButton() const override{
            return new WinButton();
        }
        CheckBox* CreateCheck() const override{
            return new WinCheck();
        }
};
class MacFactory:public AbstractFactory{
    public:
        Button* CreateButton() const override{
            return new MacButton();
        }
        CheckBox* CreateCheck() const override{
            return new MacCheck();
        }
};
void ClientCode(const AbstractFactory &absfactory){
    const Button *button = absfactory.CreateButton();
    const CheckBox *check = absfactory.CreateCheck();
    std::cout<<button->paint()<<std::endl;
    std::cout<<check->paint()<<std::endl;
    std::cout<<check->check()<<std::endl;
}
int main(){
    std::cout << "Client: Testing client code with the first factory type:\n";
    WinFactory *win = new WinFactory();
    ClientCode(*win);
    std::cout << std::endl;
    std::cout << "Client: Testing the same client code with the second factory type:\n";
    MacFactory *mac = new MacFactory();
    ClientCode(*mac);
}