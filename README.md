# LittleStateMachine
The LittleState is a state machine dll I've created in C#.

The library allows you to create Events which can use the following four different states.
Init
Idle
Done
Finish

Every state has to be used in your code and has to be attached to a object kind of "ReturnObject".

Functionality
--

Use instances of "LittleProgram" to create a main program and a while-loop to check the running state of the program.

Use instances of "LittleEvent" to create events which can be thrown by the program. Add this events into the que where they 
will be taken from by the while-loop.

It is recommended to use an instance of "LittleEvent" as main event which will be used while no other events appears. 
As example there is the menuEvent in the StateTester.


StateTester
--

To see how the machine works and how to use the states and enums there is a little project called "StateTester".
