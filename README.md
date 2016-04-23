# ILSpyMono

ILSpyMono is a demo project for compiling ILSpy as a CLI app for Mono framework.

Website: https://github.com/andreif/ILSpyMono

### How to build

You can build this project from my [ILSpy fork](https://github.com/andreif/ILSpy) which includes it as git submodule. After cloning the ILSpy fork, make sure `Mono.Cecil*` projects have proper configuration (e.g. `net_4_0_Debug`) referenced in the solution settings.

### Notes

I have not found a good way to use UpdateAssemblyInfo.exe so had to remove it from decompiler project. I guess one could have changed it to `mono path/to/UpdateAssemblyInfo.exe...` etc.

### Disclaimer

This is my first C# project ever and it was made quick-n-dirty, so you may not like the code. If you see how one can make it better, please submit an Issue or a Pull Request.

Copyright 2016 Andrei Fokau

License: ILSpyMono is distributed under the MIT License.
