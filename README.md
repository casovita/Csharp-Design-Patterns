 # Csharp Design Patterns motivation to use.
>  #### Creational:


------------


####1. BUILDER.
- When peicewise object construction is complicated provide an API for doing it succinctly.

#### 2. FACTORIES.
- Object creation logic becomes too convoluted.
- Constructor is not descriptive
	-  Name mandated by name of containing type
	- Cannot overload with same sets of arguments with different names
	- Can turn into 'optional parameter hell'
- Object creation (non-peicewise, unlike Builder) can be outsourced to
	- A separate function (Factory Method)
	- That may exist in a separate class (Factory)

#### 3. PROTOTYPE.
- We make a copy (clone) the prototype and customize it
	- Requires 'deep copy' support.
- A partially or fully initialized object that you copy (clone) and make use of.


------------


> #### Behavioral :

------------


#### 1. CHAIN OF RESPONSIBILITY .(includes mediator pattern)
A chain of components who all get a chance to process a command or query, optionally having default processing implementation and an ability to terminate the processing chain.
Can be implemented as a chain of references of a centralized construct.
Enlist objects in the chain, possibly controlling their order.
Object removal from the chain. (e.g., in Dispose())

#### 2. COMMAND.
An object which represents an instruction to perform a particular action. Contains all the information necessary for the action to be taken.
Uses: want an object that represents operation, GUI commands, multi-level undo/redo, macro recording and more.


------------


> #### Structural  :

------------


##### 1. ADAPTER.
- A construct which adapts an existing interface X to conform to the required interface Y.

##### 2. BRIDGE.
- A mechanism that decuples an interface (heirarchy) from an implementation (heirarchy).

##### 3. COMPOSITE.
- Object use other object through inheritance and composition
- Composition let us make compound objects
	- E.g, a mathematical expression composed of simple expressions; or
	- A rouping of shapes that consists of several shapes
- Compositedesign pattern is used to tread both single (scalar) and composite objects uniformly
	- I.e.' Foo and Collection of Foo have common APIs

##### 4. DECORATOR.
*(Facilitates the addition of behaviors to individual objects without inheriting from them.)*
- Want to augment an object with additional functionality
- Do not want to rewrite or alter existing code (OCP)
- Want to keep new functionality separate (SRP)
- Need to be able to interact with existing structures
- Two options:
	- Inherit from required object if possible; some objects are sealed
	- Build a Decorator, witch simply references the decorated object(s)

##### 5. PROXY.
*A class that functions as an interface to a particular resource. That resurce may be remote, expensive to constract, or may require logging or some other added functionality.*
- Proxy to resource - same interface, entirely behavior
- Communication Proxy - logging, virtual, guarding
