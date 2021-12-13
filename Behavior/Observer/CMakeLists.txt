set(CMAKE_C_COMPILER "C:/Program Files/mingw-w64/x86_64-8.1.0-win32-seh-rt_v6-rev0/mingw64/bin/x86_64-w64-mingw32-gcc.exe")
set(CMAKE_CXX_COMPILER "C:/Program Files/mingw-w64/x86_64-8.1.0-win32-seh-rt_v6-rev0/mingw64/bin/x86_64-w64-mingw32-g++.exe")
cmake_minimum_required(VERSION 3.0.0)
project(Observer VERSION 0.1.0)

include(CTest)
enable_testing()

add_executable(Observer main.cpp)

set(CPACK_PROJECT_NAME ${PROJECT_NAME})
set(CPACK_PROJECT_VERSION ${PROJECT_VERSION})
include(CPack)
