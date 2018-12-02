 # Csharp Design Patterns motivation to use.
 #### Creational:
 

------------


##### 1. Builder.
- When peicewise object construction is complicated provide an API for doing it succinctly.

##### 2. Factories.
- Object creation logic becomes too convoluted.
- Constructor is not descriptive
	-  Name mandated by name of containing type
	- Cannot overload with same sets of arguments with different names
	- Can turn into 'optional parameter hell'
- Object creation (non-peicewise, unlike Builder) can be outsourced to
	- A separate function (Factory Method)
	- That may exist in a separate class (Factory)

##### 3. Prototype.
- We make a copy (clone) the prototype and customize it
	- Requires 'deep copy' support.
- A partially or fully initialized object that you copy (clone) and make use of.


------------


#### Behavioral :

------------


###### 1. Chain of Responsibility .(includes mediator pattern)
A chain of components who all get a chance to process a command or query, optionally having default processing implementation and an ability to terminate the processing chain.
Can be implemented as a chain of references of a centralized construct.
Enlist objects in the chain, possibly controlling their order.
Object removal from the chain. (e.g., in Dispose())

##### 2. Command.
An object which represents an instruction to perform a particular action. Contains all the information necessary for the action to be taken.
Uses: want an object that represents operation, GUI commands, multi-level undo/redo, macro recording and more.


------------


#### Structural  :

------------


###### 1. Adapter.
- A construct which adapts an existing interface X to conform to the required interface Y.
