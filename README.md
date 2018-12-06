 # Csharp Design Patterns motivation to use.
 
------------

>  #### Creational:


------------


#### 1. BUILDER.
- When piecewise object construction is complicated provide an API for doing it succinctly.

#### 2. FACTORIES.
- Object creation logic becomes too convoluted.
- Constructor is not descriptive.
	-  Name mandated by name of containing type.
	- Cannot overload with same sets of arguments with different names
	- Can turn into 'optional parameter hell'
- Object creation (non-peicewise, unlike Builder) can be outsourced to
	- A separate function (Factory Method)
	- That may exist in a separate class. (Factory)

#### 3. PROTOTYPE.
- We make a copy (clone) the prototype and customize it
	- Requires 'deep copy' support.
- A partially or fully initialized object that you copy (clone) and make use of.


------------

> #### Behavioral :

------------


#### 1. CHAIN OF RESPONSIBILITY. (includes mediator pattern)
A chain of components who all get a chance to process a command or query, optionally having default processing implementation and an ability to terminate the processing chain.
Can be implemented as a chain of references of a centralized construct.
Enlist objects in the chain, possibly controlling their order.
Object removal from the chain. (e.g., in Dispose())

#### 2. COMMAND.
*An object which represents an instruction to perform a particular action. Contains all the information necessary for the action to be taken.*
Uses: want an object that represents operation, GUI commands, multi-level undo/redo, macro recording and more.

#### 2. INTERPRETER.
*A component that processes structured text data. Does so turning it into separate lexical token (lexing) and then interpreting sequences of said tokens (parsing).*

#### 3. ITERATOR.
*An object (or, in .NET, a method) that facilitates the traversal of a data structure.*
 - Iteration (traversal) is a core functionality of various data structures
 - An *iterator* is a class that facilitates the traversal
   - Keeps a reference to the current element
   - Knows how to move to a different element
 - Iterator is an implicit constract
   - .NET builds a state machine around your *yield return* statements

#### 4. OBSERVER.
*An observer is an object that wishes to be informed about events happening in the system. The entity generating the events is an observable.*
- We need to be informed when certain things happens.
	- Object's property changes.
	- Object does something.
	- Some external event occurs.
- We want to listen to events and notified when they occur.
- Build into C# with the *event*  keyword.
	- But then what is this `IObservable<T>` / `IObserver<T>` for?

#### 5. NULL OBJECT.
*A no-op object that conforms to the required interface, satisfying a dependency requirement of some other object.*
- When component `A` uses component `B`, it typically assumes that `B` is non-null.
	- You inject `B`, not `B`? or some `Option<B>`.
	-  You do not check for null (?.) on every call.
- There is no option of telling `A` not to use an instance of `B`.
	- Its use is hard coded
- Thus, we build a no-op, non-functioning inheritor of B and pass it into `A`.

------------


> #### Structural  :

------------


#### 1. ADAPTER.
- A construct which adapts an existing interface X to conform to the required interface Y.

#### 2. BRIDGE.
- A mechanism that decouples an interface (heirarchy) from an implementation (heirarchy).

#### 3. COMPOSITE.
- Object use other object through inheritance and composition
- Composition let us make compound objects
	- E.g, a mathematical expression composed of simple expressions; or
	- A rouping of shapes that consists of several shapes
- Composite design pattern is used to tread both single (scalar) and composite objects uniformly
	- I.e.' Foo and Collection of Foo have common APIs

#### 4. DECORATOR.
*(Facilitates the addition of behaviors to individual objects without inheriting from them.)*
- Want to augment an object with additional functionality
- Do not want to rewrite or alter existing code (OCP)
- Want to keep new functionality separate (SRP)
- Need to be able to interact with existing structures
- Two options:
	- Inherit from required object if possible; some objects are sealed
	- Build a Decorator, witch simply references the decorated object(s)

#### 5. FLYWEIGHT.
*A space optimization technique that lets us use less memory by storing externally the data associated with similar objects.*
- Avoid redundancy when storing data
- E.g., MMORPG
	- Plenty of users with identical first/last names
	- No sense in storing same first/last name over and over again
	- Store a list of names and pointers to them
- .NET performs string interning, so an identical string is stored only once

#### 6. PROXY.
*A class that functions as an interface to a particular resource. That resource may be remote, expensive to constract, or may require logging or some other added functionality.*
- Proxy to resource - same interface, entirely behavior
- Communication Proxy - logging, virtual, guarding
