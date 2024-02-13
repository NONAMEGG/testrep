#include <iostream>
using namespace std;

void rotate(int a[], int n, bool clockwise) {
    int x = a[0];
    if (!clockwise) {
        for (int i = 1; i < n; i++)
            a[i - 1] = a[i];
        a[n - 1] = x;
    }
    else {
        for (int i = 0; i < n - 1; i++)
            a[i] = a[i + 1];
        a[n - 1] = x;
    }
    
}


int main()
{
    int a[5]{ 1,2,3,4,5 };
    for (int* p = a; p - a < (sizeof(a) / sizeof(*a)); p++)
        cout << *p << ' ';
    cout << endl;

    rotate(a, 3, true);
    for (int* p = a; p - a < (sizeof(a) / sizeof(*a)); p++)
        cout << *p << ' ';
    
    cout << endl;
}