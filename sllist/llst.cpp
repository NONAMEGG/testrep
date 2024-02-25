#include "slinkedlist.cpp"
using namespace std;

int main()
{

	slinkedlist<int> list;
	cout << list.empty() << endl;

	list.push_back(4);
	list.push_back(5);
	list.push_front(22);
	list.insert(2, 7);
	list.insert(3, 21);
	list.pop_back();
	list.pop_front();
	list.remove_at(1);
	list[1] = 10;

	slinkedlist<int> b;
	b = list;
	cout << b[1] << endl;
	cout << b.back() << endl;
	cout << b.front() << endl;
	cout << b.empty() << endl;
}
