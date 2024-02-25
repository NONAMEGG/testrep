#pragma once
#include <iostream>
using namespace std;

class Test
{
public:
    Test();
    ~Test();
    static int nCount;

    Test(const Test& other);
};

