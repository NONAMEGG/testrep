#include "Test.h"
int Test::nCount = 0;

Test::Test() {
    ++nCount;
    cout << "Object created. Count: " << nCount << endl;
}

Test::~Test() {
    --nCount;
    cout << "Object destroyed. Count: " << nCount << endl;
}

Test::Test(const Test& other) { // copy constructor
    ++nCount;
    cout << "Copy constructor invoked" << endl;
}