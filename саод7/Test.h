#pragma once
#include <iostream>

class Test {
public:
    Test() : Val(0) {
        std::cout << "Test constructor" << std::endl;
    }

    ~Test() {
        std::cout << "Test destructor" << std::endl;
    }

    int Val;
};