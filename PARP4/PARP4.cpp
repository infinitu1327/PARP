// PARP4.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <omp.h>
#include <cstdio>
#include <iostream>
#include <string>
#include <future>

using namespace std;

int main() {
#ifdef _OPENMP
	printf("_OPENMP Defined\n");
#else
	printf("_OPENMP UnDefined\n");
#endif

	int cpu[4];

	__cpuid(cpu, 4);

	for (int i = 0; i < 4; i++)
	{
		cout << (char)cpu[i];
	}

	//cout << threads;
}