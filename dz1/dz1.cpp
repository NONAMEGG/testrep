#include <iostream>
#include "utils.h"

using namespace std;
int main()
{
    cout << "Hello World!"<<endl;
    int x, y;
    cout << "x = ? "; cin >> x; 
    cout << "y = ? "; cin >> y; 
    cout << x << " + " << y << " = " << Plus(x,y) << endl;
}


