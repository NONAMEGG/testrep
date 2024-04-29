#define _CRT_SECURE_NO_WARNINGS 1

template <typename T>
struct ILinkedList
{
	virtual void push_back(const T& data) = 0, push_front(const T& data) = 0;
	virtual void pop_back() = 0, pop_front() = 0;
	virtual T front() const = 0, back() const = 0;
	virtual size_t size() const = 0;
	virtual bool empty() const = 0;
	virtual ~ILinkedList() {}
};
