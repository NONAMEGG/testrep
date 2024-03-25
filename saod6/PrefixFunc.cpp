#include <iostream>
#include "PF.h"
using namespace std;

int main()
{
    PF pff;
    pff.Init("rakaratrakarakarakatakarakara");

    int length = static_cast<int>(pff);
    for (int i = 0; i < length; ++i) {
        std::cout << pff[i];
    }
    std::cout << std::endl;

    const int N = 100;
    char s[N] = { 0 };
    for (int i = 0; i < N - 1; i++)
        s[i] = rand() % ('c' - 'a') + 'a';

    PF pf;
    pf.Init(s);

    int length1 = static_cast<int>(pf);
    for (int i = 0; i < length1; ++i) {
        std::cout << pf[i];
    }
    std::cout << std::endl;

    std::cout << pf.CmpCount() << std::endl;

}
