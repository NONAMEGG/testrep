#pragma once
#define _CRT_SECURE_NO_WARNINGS 1

template <typename T>
struct IDeque
{
	virtual void push(const T& data) = 0;
	virtual void pop() = 0;
	virtual T top() const = 0;
	virtual size_t size() const = 0;
	virtual bool empty() const = 0;
	virtual ~IDeque() {};
};