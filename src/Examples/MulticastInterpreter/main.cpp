// Copyright (c) 2009, Object Computing, Inc.
// All rights reserved.
// See the file license.txt for licensing information.
//

#include <Examples/ExamplesPch.h>
#include <MulticastInterpreter/MulticastInterpreter.h>

using namespace QuickFAST;

int main(int argc, char* argv[])
{
  int result = -1;
  MulticastInterpreter application;
  if(application.init(argc, argv))
  {
    result = application.run();
    application.fini();
  }
  return result;
}
