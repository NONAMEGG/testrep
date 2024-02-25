#include <iostream>
#include "Test.h"
#include "Child.h"
#include "Agregate.h"
#include "AgregateT.h"

using namespace std;

Test globalTest;

void foo(Test t) {
    cout << "foo is running" << endl;
}

int main()
{
    Test* p = new Test;

    Test obj1;
    Test obj2;

    delete p;
    p = nullptr;

    const int size = 3;
    Test* testArray = new Test[size];

    for (int i = 0; i < size; i++) {
        foo(testArray[i]);
    }

    delete[] testArray;

    cout << endl;
    cout << endl;

    Test testObj;
    Child childObj;

    cout << endl;
    cout << endl;
    cout << endl;
    cout << endl;
    cout << endl;
    cout << endl;

    Agregate agregateObj;

    cout << endl;
    cout << endl;
    cout << endl;
    cout << endl;
    cout << endl;
    cout << endl;

    AgregateT<Test> agregateTest;
    AgregateT<Child> agregateChild;
}
