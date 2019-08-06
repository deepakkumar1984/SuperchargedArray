cmake_minimum_required(VERSION 3.14)
project(xtensor_nn)

find_package(xtl REQUIRED PATHS "xtl/lib/cmake")
find_package(xtensor REQUIRED PATHS "xtl/lib/cmake")
find_package(xsimd REQUIRED PATHS "xtl/lib/cmake")
set(CMAKE_CXX_STANDARD 14)
include_directories(${xtensor_INCLUDE_DIRS})


add_executable(xtensor_nn main.cpp variable.cpp variable.h enumerations.h functions.h functions.cpp)
#add_library(xtensor_nn SHARED main.cpp variable.cpp variable.h)