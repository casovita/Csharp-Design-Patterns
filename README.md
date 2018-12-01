# Csharp-Design-Patterns
**Motivation to use**

Behavioral: 
<ol>
<li>Chain of Responsibility <i>(includes mediator pattern)</i>
<p>A chain of components who all get a chance to process a command or query, optionally having default processing implementation and an ability to terminate the processing chain.</p>
<p>Can be implemented as a chain of references of a centralized construct.
Enlist objects in the chain, possibly controlling their order.
Object removal from the chain. (e.g., in Dispose())</p>
</li>
<li>Command
<p>An object which represents an instruction to perform a particular action. Contains all the information necessary for the action to be taken.<br>
Uses: want an object that represents operation, GUI commands, multi-level undo/redo, macro recording and more.</p></li>
</ol>