// AFTest.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <arrayfire.h>

int main()
{
	float x_buffer[] = {  1, 2, 3, 4 };
	af::array x(2, 2, x_buffer);
	
	auto y = af::sqrt(x);
	af::array dx, dy;
	af::grad(dx, dy, y);

	af::print("y", y);
	af::print("dx", dx);

	return 0;
}